myApp.controller("productController", function ($scope, productRepository) {
    productRepository.get().then(function (products) {        
        $scope.products = products;
    });
});
