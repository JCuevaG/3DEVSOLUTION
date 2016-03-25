myApp.controller("productController", function ($scope, productRepository,$location) {
    productRepository.get().then(function (products) {        
        $scope.products = products;
    });

    $scope.addNewProduct = function () {
        $location.path('/newProduct');
    };
});
