/// <reference path="jquery-3.1.1.js"/>

$("#txtara").keyup(function () {
    var key = this.value;
    console.log(key);
    $.ajax({
        url: "../Urun/Bul?key=" + key,
        method: "GET"
    }).done(function (response) {
        console.log(response);
    });
})

