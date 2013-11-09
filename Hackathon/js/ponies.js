var authenticationToken = null;

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
                            "<button id='searchsubmit' type='button' class='btn btn-default'>Submit</button>" +
                       "</div>" +
                       "<table id='sampleTable'></table>");
    $('#sampleTable').dataTable({
        "aaData": [],
        "aoColumns": [
            { "sTitle": "DUNS Number", "mData": "dunsNumber" },
            { "sTitle": "Name", "mData": "organizationPrimaryName.organizationName._" },
            { "sTitle": "City", "mData": "primaryAddress.primaryTownName" },
            { "sTitle": "State", "mData": "primaryAddress.territoryAbbreviatedName" }
        ],
        "bFilter": false,
        "bLengthChange": false,
        "iDisplayLength": 25
    });

    $('#searchsubmit').click(doSearch);
}

function doSearch() {
    alert("click!!")
}