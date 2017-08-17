/// <reference path="angular.js"/>
var app = angular.module("northapp", ["ngRoute", 'naif.base64']); // dependecy injection

app.factory("api", function ($http) {
    var apiurl = "http://localhost:2148/api/";
    return {
        getallcategories: function (success) {
            $http({
                url: apiurl + 'Category',
                method: 'GET',
                dataType: 'JSON'
            }).then(function (response) {
                success(response.data);
            });
        },
        getcategorybyid: function (id, success) {
            $http({
                url: apiurl + 'Category/' + id,
                method: 'GET',
                dataType: 'JSON'
            }).then(function (response) {
                success(response.data);
            });
        },
        updatecategory:function(model, success) {
            $http({
                url: apiurl + 'Category',
                data:model,
                method: 'PUT',
                dataType: 'JSON'
            }).then(function (response) {
                success(response.data);
            });
        },
        insertcategory: function (model, success) {
            $http({
                url: apiurl + 'Category',
                data: model,
                method: 'POST',
                dataType: 'JSON'
            }).then(function (response) {
                success(response.data);
            });
        }
    }
});

app.config(function ($routeProvider) {
    $routeProvider
        .when('/', {
            templateUrl: 'Views/category.html',
            controller: 'CategoryCtrl',
            controllerAs: 'category'
        })
        .when('/kategoriguncelle/:id', {
            templateUrl: 'views/kategoriguncelle.html',
            controller: 'KategoriGuncelleCtrl',
            controllerAs: 'kategoriguncelle'
        })
        .when('/kategoriekle', {
            templateUrl: 'views/kategoriekle.html',
            controller: 'KategoriekleCtrl',
            controllerAs: 'kategoriekle'
        })
        .otherwise({
            redirectTo: '/'
        });
});