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
    var selectedDuns = $(e.target).attr('href');

    $('#content').html('<div id="loading"><img /></div>');
    $('<div>' + selectedDuns + '</div>').appendTo($('#content'));
}