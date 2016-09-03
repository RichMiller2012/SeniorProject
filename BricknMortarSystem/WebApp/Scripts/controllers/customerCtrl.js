/// <reference path="../angular.min.js" />
var app = angular.module('app');

app.controller("customerCtrl", function ($scope, $http) {
    $http.get(app.baseURL + 'customer/allcompanycustomers')
            .then(function (response) {
                $scope.people = response.data;
            });

    $scope.message = "All Store Customers";
});

app.controller("customerFormCtrl", function ($scope, $http) {

    $scope.send = function () {

        var data = $.param({
            firstName: $scope.firstName,
            lastName: $scope.lastName,
            phoneNumber: $scope.phoneNumber,
            total: $scope.total
        });

        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        $http.post('customer/addcustomertostore', data, config)
            .success(function (data, status, header, config) {
                $scope.response = data;
            });
    }


});