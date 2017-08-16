/// <reference path="angular.js"/>
var app = angular.module("northapp", []);

app.factory("api", function ($http) {
    var apiurl = "http://localhost:2148/api/";
    return {
        getallcategories: function (success) {
            $http({
                url: apiurl + 'Category',
                method: 'GET',
                dataType: 'JSON'
            }).then(function(response) {
                success(response.data);
            });
        }
    }

});