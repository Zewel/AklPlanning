$(document).ready(function () {

    // enable fileuploader plugin
    //$('input[name="files"]').fileuploader({
    //	addMore: true
    //});
    CurrentYear();
});

var currentYear;
function CurrentYear() {
    LoadCurrentYear();

    var filterData = allYears.find(x => x.CurrentYear == true).YearId;
    currentYear = allYears.find(x => x.CurrentYear == true).YearId;
    $('#dllCurrentYear').val(filterData).trigger('change');

}
var allYears = [];
function LoadCurrentYear() {
    $.ajax({
        url: apiHeader + 'api/Common/GetallYear',
        type: "GET",
        crossDomain: true,
        dataType: "json",
        async: false,

        success: function (result) {

            allYears = result
            if (result.length > 0) {
                $('#dllCurrentYear').empty();
                for (var i = 0; i < result.length; i++) {

                    $('#dllCurrentYear').append($("<option></option>").val(result[i].YearId).html(result[i].YearName));
                }
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}

function LoadProductionYear(element) {
    $.ajax({
        url: apiHeader + 'api/Common/GetallYear',
        type: "GET", crossDomain: true,
        dataType: "json",
        async: false,
        success: function (result) {

            allYears = result
            if (result.length > 0) {
                $('#' + element + '').empty();
                $('#' + element + '').append("<option value=''>--Select Year--</option>");
                for (var i = 0; i < result.length; i++) {

                    $('#' + element + '').append($("<option></option>").val(result[i].YearId).html(result[i].YearName));
                }
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}

function LoadMarchantHead(element) {
    $.ajax({
        url: apiHeader + 'api/Common/GetAllMarchantHead',
        type: "GET", crossDomain: true,
        dataType: "json",
        async: false,
        success: function (result) {

            allYears = result
            if (result.length > 0) {
                $('#' + element + '').empty();
                $('#' + element + '').append("<option value=''>--Select Marchandizer--</option>");
                //$('#' + element + '').append("<option value='0'>All</option>");
                for (var i = 0; i < result.length; i++) {

                    $('#' + element + '').append($("<option></option>").val(result[i].MarchantId).html(result[i].MarchantName));
                }
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}

function GetAllocationYear(elamentName) {
    $.ajax({
        url: apiHeader + 'api/Common/GetAllocateYear',
        type: "GET", crossDomain: true,
        dataType: "json",
        async: false,
        success: function (result) {

            if (result.length > 0) {
                $('#' + elamentName + '').empty();
                $('#' + elamentName + '').append("<option value=''>--Select Allocate Year--</option>");
                for (var i = 0; i < result.length; i++) {

                    $('#' + elamentName + '').append($("<option></option>").val(result[i].YearId).html(result[i].YearName));
                }
            }
            debugger;
            var filterData = result.find(x => x.CurrentYear == true).YearId;
            $('#' + elamentName + '').val(filterData).trigger('change');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}


function LoadFactory(element) {
    $.ajax({
        url: apiHeader + 'api/Common/GetFactory',
        type: "GET",
        dataType: "json",
        async: false,
        success: function (result) {
            debugger;
            if (result.length > 0) {
                $('#' + element + '').empty();
                $('#' + element + '').append("<option value=''>--Select Factory--</option>");
                for (var i = 0; i < result.length; i++) {
                    $('#' + element + '').append($("<option></option>").val(result[i].FactoryId).html(result[i].FactoryName));
                }
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
