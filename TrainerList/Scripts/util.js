

//script to stop propagation on dropdown 


$(document).ready(function () {


    $('.dropdown input, .dropdown label').click(function (e) {
        e.stopPropagation();
    });

    $('#datetimepicker1').datetimepicker();
});

