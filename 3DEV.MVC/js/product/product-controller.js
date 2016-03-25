myApp.controller("productController", function ($scope, productRepository, $location,$routeParams) {

    $scope.products = productRepository.getAll();

    if ($routeParams.id) {
        $.each(productRepository.getAll(), function (i, product) {
            debugger;
            if (product.id == $routeParams.id) {
                $scope.product = product;
            }
        });
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

