myApp.factory('productRepository', function ($http,$q) {
    return {
        get: function () {            
            var deferred = $q.defer();
            $http.get('/Product/getProducts').success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});