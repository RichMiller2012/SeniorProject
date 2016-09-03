/// <reference path="../angular.min.js" />
var app = angular.module('app');

app.controller("inventoryCtrl", function ($scope, $http) {
    $http.get('inventory/allcompanyitems')
        .then(function (response) {
            $scope.items = response.data;

        });

    $scope.message = "All Items in Your Company";
});