$( document ).ready(function() {

    //$.when(DnbAuthenticate()).then(
    //    function (data, textStatus, jqXHR) {
    //        authenticationToken = data.authToken;
    //        intitializeApp();
    //    },
    //    function (jqXHR, textStatus, errorThrown) {
    //        $('#content').html("D&B Authentication Failure");
    //    }
    //);
});

var authenticationToken = null;

function DnbAuthenticate() {
    return $.ajax({
        url: "/dnb/auth",
        type: "POST",
        dataType: "json"
    });
}

function intitializeApp() {
    $.ajax({
        url: "/dnb/sample",
        data: {
            authToken: authenticationToken
        },
        type: "GET",
        dataType: "json",
        success: function (data, textStatus, jqXHR) {
            $('#content').html("<table id='sampleTable'></table>");
            $('#sampleTable').dataTable({
                "aaData": data,
                "aoColumns": [
                    { "sTitle": "DUNS Number", "mData": "dunsNumber" },
                    { "sTitle": "Name", "mData": "organizationPrimaryName.organizationName._" },
                    { "sTitle": "City", "mData": "primaryAddress.primaryTownName" },
                    { "sTitle": "State", "mData": "primaryAddress.territoryAbbreviatedName" }
                ]
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("FAIL:  GET /dnb/sample");
        }
    });
}