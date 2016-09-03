var app = angular.module('app');

app.baseURL = "http://localhost:8080/";

app.config(function ($routeProvider) {
    $routeProvider

    .when("/", {
        templateUrl: "WebApp/Templates/home.html"
    })

    //customer templates
    .when("/customers", {
        templateUrl: "WebApp/Templates/customer/customers.html",
        controller: "customerCtrl"
    })

    .when("/addcustomer", {
        templateUrl: "WebApp/Templates/customer/add-customer.html",
        controller: "customerCtrl"
    })

    //point of sale routes
    .when("/pos", {
        templateUrl: "WebApp/Templates/pos.html",
        controller: "posCtrl"
    })

     //inventory and item routes
    .when("/inventory", {
        templateUrl: "WebApp/Templates/items.html",
        controller: "inventoryCtrl"
    })

    .when("/reports", {
        templateUrl: "WebApp/Templates/reports.html",
        controller:"reportsCtrl"
    })

    //transaction routes
    .when("/transactions", {
        templateUrl: "WebApp/Templates/transactions.html",
        controller:"transactionsCtrl"
    })

    .when("/discounts", {
        templateUrl: "WebApp/Templates/discounts.html",
        controller:"discountsCtrl"
    })
});