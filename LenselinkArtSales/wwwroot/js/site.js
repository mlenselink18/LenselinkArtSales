// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
"use strict";
var $ = jQuery.noConflict();

$(document).ready(() => {
    function ShowAlertBubble() {
        alert("Hello! I am an alert box!");
    }

    function AlertUpdate() {
        alert('About to update!');
    }

    var slidePosition = 1;
    SlideShow(slidePosition);

    // forward/Back controls
    function plusSlides(n) {
        SlideShow(slidePosition += n);
    }

    //  images controls
    function currentSlide(n) {
        SlideShow(slidePosition = n);
    }

    function SlideShow(n) {
        var i;
        var slides = document.getElementsByClassName("Containers");
        var circles = document.getElementsByClassName("dots");
        if (n > slides.length) { slidePosition = 1 }
        if (n < 1) { slidePosition = slides.length }
        for (i = 0; i < slides.length; i++) {
            slides[i].style.display = "none";
        }
        for (i = 0; i < circles.length; i++) {
            circles[i].className = circles[i].className.replace(" enable", "");
        }
        slides[slidePosition - 1].style.display = "block";
        circles[slidePosition - 1].className += " enable";
    }
});