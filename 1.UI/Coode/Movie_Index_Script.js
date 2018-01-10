//onLoad paging in JQ.
$(function () {

     //dinamic register to the event 'change'.
    $("#filter_category").change(function () {

        var category = $("#filter_category").val();

         //jason object the send to the controoler.
        var dataToSend = {
            category: category,
        };

         //Alax call.
        $.get("/Movie/GetCarsByFilter", dataToSend, function (response) {
            $("#container").empty().html(response);

        }).error(function (error) { alert(error = "Ajax שגיאת"); });
    });

});