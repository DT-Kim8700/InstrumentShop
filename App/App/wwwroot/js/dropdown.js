$(function () {
    var $hiddenMenus = $(".hidden-menu");

    //$(".navbar-nav").children().on("mouseenter", function () {

    //    if ($(this).children("ul").is(":hidden")) {
    //        $hiddenMenus.hide();
    //    }

    //    $(this).children("ul").toggle();
    //});

    $(".navbar-nav").children().hover(
        function () {
            $(this).children("ul").show();
        },
        function () {
            $(this).children("ul").hide();
        }
    );
});