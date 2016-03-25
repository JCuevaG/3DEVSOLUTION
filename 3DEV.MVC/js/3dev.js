var myApp = angular.module("3devApp", ["ngRoute"]);

myApp.config(function ($routeProvider) {
    $routeProvider
        .when('/home',
        {
            templateUrl: 'js/home.html'
        })
        .when('/product',
        {
            templateUrl: 'js/product/product.html',
            controller: 'productController'
        })
        .when('/newProduct',
        {
            templateUrl: 'js/product/newProduct.html',
            controller: 'productController'
        })
        .otherwise({
            redirectTo: "/home"
        });
});