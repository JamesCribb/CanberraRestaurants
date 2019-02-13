
$(document).ready(function () {

    // Restaurants Page: Highlight restaurant div on mouseover

    $(".black-border").on({
        mouseenter: function () {
            $(this).css("border-color", "#f8bd08");
        },
        mouseleave: function () {
            $(this).css("border-color", "black");
        }
    });

    // Prices Page: Highlight Price Options on mouseover

    $(".pricelist").on({
        mouseenter: function () {
            $(this).css("background-color", "#428bca");
            $(this).css("color", "white");
        },
        mouseleave: function () {
            $(this).css("background-color", "white");
            $(this).css("color", "black");
        }
    });

    // Prices Page: Shrink and fade restaurants outside the selected price point, and restore relevant restaurants to full size and opacity

    $("#cheap-selector").click(function () {
        $(".mid-range, .fine-dining").animate({
            width: '100px',
            height: '100px',
            margin: '50px',
            opacity: '0.2'
        }, 1000);
        $(".cheap-eats").animate({
            width: '200px',
            height: '200px',
            margin: '0',
            opacity: '1'
        }, 1000);
    });

    $("#mid-selector").click(function () {
        $(".cheap-eats, .fine-dining").animate({
            width: '100px',
            height: '100px',
            margin: '50px',
            opacity: '0.2'
        }, 1000);
        $(".mid-range").animate({
            width: '200px',
            height: '200px',
            margin: '0',
            opacity: '1'
        }, 1000);
    });

    $("#fine-selector").click(function () {
        $(".cheap-eats, .mid-range").animate({
            width: '100px',
            height: '100px',
            margin: '50px',
            opacity: '0.2'
        }, 1000);
        $(".fine-dining").animate({
            width: '200px',
            height: '200px',
            margin: '0',
            opacity: '1'
        }, 1000);
    });

    // Prices Page: Highlight Restaurant Images on mouseover

    $(".cheap-eats, .mid-range, .fine-dining").on({
        mouseenter: function () {
            $(this).css("border", "3px solid #f8bd08");
        },
        mouseleave: function () {
            $(this).css("border-color", "white");
        }
    });

});