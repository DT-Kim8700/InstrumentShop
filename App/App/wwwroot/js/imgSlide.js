$(function () {
    // 변수 정리
    var $slide = $("#slide");
    var intervalId;

    // 메서드 정리
    var moveImg = function () {       // interval 등록
        intervalId = window.setInterval(function () {
            $slide.addClass("move");

            window.setTimeout(function () {
                $slide.removeClass("move").append($slide.children(":first"));
            }, 1000);
        }, 2000);
    };

    // 실행 로직
    moveImg();

    $slide.hover(
        function () {     // mouseenter
            window.clearInterval(intervalId);
        },
        function () {     // mouseleave 
            moveImg();
        },
    );
});