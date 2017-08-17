/// <reference path="angular.js"/>
/// <reference path="appmodule.js"/>

app.controller("CategoryCtrl",
    function ($scope, api) {
        $scope.ad = "Kamil";
        $scope.kategoriler = [];
        $scope.getir = function () {
            api.getallcategories(function (response) {
                $scope.kategoriler = response;
                console.log(response);
            });
        }
    });
    //bower install angular-base64-upload
app.controller("KategoriGuncelleCtrl",
    function ($scope, api, $routeParams) {
        $scope.kategori = {};
        $scope.id = $routeParams.id;
        api.getcategorybyid($routeParams.id,
            function (data) {
                console.log(data);
                $scope.kategori = data;
            });
    });