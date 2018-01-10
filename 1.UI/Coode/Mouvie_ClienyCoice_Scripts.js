//onLoad paging in JQ.
$(function () {

    //dinamic register to the event 'click'.
    $("#confirm").click(function () {

        var movieid = $("#movieid").text();
        var startdate = $("#startDate").text();

        //jason object the send to the controoler.
        var dataToSend = {
            movieId: movieid,
            startDate: startdate
        }

        //Alax call.
        $.get("/Movie/CreateNewOrder", dataToSend, function (response) {
            $("#container").empty().html(response);

        }).error(function (error) { alert(error = "Ajax שגיאת"); });
    });

});