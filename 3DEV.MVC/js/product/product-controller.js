myApp.controller("productController", function ($scope, productRepository, $location,$routeParams) {

    $scope.products = productRepository.getAll();

    if ($routeParams.id) {        
        $scope.product = productRepository.getById($routeParams.id);
    }

    $scope.addNewProduct = function () {
        $location.path('/newProduct');
    };

    $scope.saveProduct = function (product) {        
        productRepository.save(product).$promise.then(
            function () {                
                toastr.success('Se Registro Correctamente');
                $location.path('/product');
            },
            function () {
                toastr.error('Ocurrio Error');
            });
    };

    $scope.cancelarProduct = function () {
        $location.path('/product');
    };
});

