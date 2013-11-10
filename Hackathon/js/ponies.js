var authenticationToken = null;
var searchTable = null;

$(document).ready(function () {

    $.when(DnbAuthenticate()).then(
        function (data, textStatus, jqXHR) {
            authenticationToken = data.authToken;
            console.log(data.authToken);
            intitializeSearchPage();
        },
        function (jqXHR, textStatus, errorThrown) {
            $('#content').html("D&B Authentication Failure");
        }
    );
});

function DnbAuthenticate() {
    return $.ajax({
        url: "/dnb/auth",
        type: "POST",
        dataType: "json"
    });
}

function intitializeSearchPage() {

    $('#content').html("<div id='searchform' class='form-group'>" + 
                            "<input id='searchbox' type='text' class='form-control' placeholder='Enter Company Name' />" +
                            "<button id='searchsubmit' type='submit' class='btn btn-default'>Submit</button>" +
                            "<img id='searchspinner' style='display:none;'/>" +
                       "</div>" +
                       "<table id='sampleTable'></table>");
    searchTable = $('#sampleTable').dataTable({
        "aaData": [],
        "aoColumns": [
            { "sTitle": "DUNS Number", "mData": "DUNSNumber", "mRender": renderDunsLinks },
            { "sTitle": "Organization Name", "mData": "OrganizationPrimaryName.OrganizationName.$", "sDefaultContent": "" },
            { "sTitle": "City", "mData": "PrimaryAddress.PrimaryTownName", "sDefaultContent": "" },
            { "sTitle": "State", "mData": "PrimaryAddress.TerritoryAbbreviatedName", "sDefaultContent": "" }
        ],
        "bFilter": false,
        "bLengthChange": false,
        "iDisplayLength": 20
    });

    $('#searchsubmit').click(doSearch);
}

function renderDunsLinks(data, type, full) {
    if (type === 'display') {
        return "<a class='dunslink' href='" + data + "'>" + data + "</a>";
    }
    return data;
}

function doSearch() {
    var searchTerm = $('#searchbox').val();
    if ($.trim(searchTerm) === "") {
        return;
    }
    $('#searchspinner').show();
    searchTable.fnClearTable();
    $.ajax({
        url: "/dnb/entity/company/" + searchTerm,
        type: "GET",
        dataType: "json",
        data: {
            authToken: authenticationToken
        },
        success: function (data, textStatus, jqXHR) {
            if (data.FindCompanyResponse.FindCompanyResponseDetail) {
                searchTable.fnAddData(data.FindCompanyResponse.FindCompanyResponseDetail.FindCandidate);
            }
            $('#searchspinner').hide();
            $('.dunslink').click(dunsLinkClick);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Error on search");
            $('#searchspinner').hide();
        }
    });
}

function dunsLinkClick(e) {
    e.preventDefault();

    initializeGraphPage();
}


function name(d) { return d.name; }
function group(d) { return d.group; }

var color = d3.scale.category10();
function colorByGroup(d) {
    switch (d.group) {
        case 1:
            return "#ff0000";
        case 2:
            return "#00ff00";
        case 3:
            return "#0000ff";
        default:
            return "#00ff00";
    }
}
function getSize(d) {
    switch(d.size)
    {
        case 1:
            return 20;
        case 2:
            return 25;
        case 3:
            return 30;
        case 4:
            return 35;
        case 5:
            return 40;
        default:
            return 40;
    }
}

var width = 1260,
    height = 800;

//var svg = d3.select('#viz')
//    .append('svg')
//    .attr('width', width)
//    .attr('height', height);
var svg = null;

var node, link;

var voronoi = d3.geom.voronoi()
    .x(function (d) { return d.x; })
    .y(function (d) { return d.y; })
    .clipExtent([[-10, -10], [width + 10, height + 10]]);

function recenterVoronoi(nodes) {
    var shapes = [];
    voronoi(nodes).forEach(function (d) {
        if (!d.length) return;
        var n = [];
        d.forEach(function (c) {
            n.push([c[0] - d.point.x, c[1] - d.point.y]);
        });
        n.point = d.point;
        shapes.push(n);
    });
    return shapes;
}

var force = d3.layout.force()
    .charge(-3000)
    .friction(0.3)
    .linkDistance(120)
    .size([width, height]);


function registerTick() {
    force.on('tick', function () {
        node.attr('transform', function (d) { return 'translate(' + d.x + ',' + d.y + ')'; })
            .attr('clip-path', function (d) { return 'url(#clip-' + d.index + ')'; });

        link.attr('x1', function (d) { return d.source.x; })
            .attr('y1', function (d) { return d.source.y; })
            .attr('x2', function (d) { return d.target.x; })
            .attr('y2', function (d) { return d.target.y; });

        var clip = svg.selectAll('.clip')
            .data(recenterVoronoi(node.data()), function (d) { return d.point.index; });

        clip.enter().append('clipPath')
            .attr('id', function (d) { return 'clip-' + d.point.index; })
            .attr('class', 'clip');
        clip.exit().remove()

        clip.selectAll('path').remove();
        clip.append('path')
            .attr('d', function (d) { return 'M' + d.join(',') + 'Z'; });
    });
}


var mouseOverEventHandler = function (event) {

    //alert('bam');
    var x = 5;
}

function initializeGraphPage() {

    // add loading graphic AND graphics container
    $('#content').html("<div id='loading'><img /></div><div id='viz'></div>");
    svg = d3.select('#viz')
            .append('svg')
            .attr('width', width)
            .attr('height', height);
    registerTick();
    d3.json('/miserable', function (err, data) {

        // remove loading
        $('#loading').remove();

        data.nodes.forEach(function (d, i) {
            d.id = i;
        });

        link = svg.selectAll('.link')
            .data(data.links)
          .enter().append('line')
            .attr('class', 'link')
            .style("stroke-width", function (d) { return d.value; });
        //.style("stroke-width", function(d) { return Math.sqrt(d.value); });

        node = svg.selectAll('.node')
            .data(data.nodes)
          .enter().append('g')
            .attr('title', name)
            .attr('class', 'node')
            .call(force.drag)


        //  breast
        node.append('circle')
            .attr('r', getSize)
            .attr('fill', colorByGroup)
            .attr('fill-opacity', 0.9)
            .attr('onmouseover', 'mouseOverEventHandler(this)');

        //  nipple
        node.append('circle')
            .attr('r', 8)
            .attr('stroke', 'black');

        force
            .nodes(data.nodes)
            .links(data.links)
            .start();


        $('.node').popover({
            content: "This is a test.",
            trigger: "hover",
            container: $("#viz")
        });

    });
}