var myApp = angular.module("3devApp", ["ngRoute", "ngResource"]);

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
            templateUrl: 'js/product/productForm.html',
            controller: 'productController'
        })
        .when('/updateProduct/:id',
        {
            templateUrl: 'js/product/productForm.html',
            controller: 'productController'
        })
        .otherwise({
            redirectTo: "/home"
        });
});

