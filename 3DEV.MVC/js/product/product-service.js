'use strict';

myApp.factory('productRepository', function ($resource, $q) {
    function getAll() {        
        return $resource('api/ProductsAPI').query();
        
    }


    function save(product) {
        return $resource('api/ProductsAPI').save(product);
    }

    return {
        getAll: getAll,        
        save: save
    }
    
});


