

//script to stop propagation on dropdown 
!function ($) {
    $('.dropdown input, .dropdown label').click(function (e) {
        e.stopPropagation();
    });

//transform something in a datepicker

    $('.datepicker').datepicker();

}

