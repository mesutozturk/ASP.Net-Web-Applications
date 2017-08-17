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
        $scope.message = null;
        api.getcategorybyid($routeParams.id,
            function (data) {
                console.log(data);
                $scope.kategori = data;
                if ($scope.kategori.Picture == null) return;

            });
        $scope.guncelle = function () {
            //$scope.resim.base64;
            if ($scope.resim != null)
                $scope.kategori.Picture = $scope.resim.base64;
            api.updatecategory($scope.kategori,
                function (data) {
                    console.log(data);
                    $scope.message = data.message;
                });
        };
    });

app.controller("KategoriEkleCtrl",
    function ($scope, api) {
        
    });