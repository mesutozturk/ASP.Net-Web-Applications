/// <reference path="angular.js"/>
/// <reference path="appmodule.js"/>

app.controller("categoryCtrl",
    function ($scope,api) {
        $scope.ad = "Kamil";
        $scope.kategoriler = [];
        $scope.getir = function () {
            api.getallcategories(function(response) {
                $scope.kategoriler = response;
                console.log(response);
            });
        }
    });