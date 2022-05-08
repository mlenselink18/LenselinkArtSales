"use strict";
var $ = jQuery.noConflict();

$(document).ready(() => {
    document.getElementById("btnAddNew").addEventListener("click", function () {
        ShowAlertBubble();
    });

    document.getElementById("btnRemoveImage").addEventListener("click", function () {
        DeleteUpdate();
    });

    function ShowAlertBubble() {
        alert("Hello! I am an alert box!");
    }

    function DeleteUpdate() {
        alert('Delete Image?');
    }
});