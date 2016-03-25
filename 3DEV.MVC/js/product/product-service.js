myApp.factory('productRepository', function ($resource, $q) {
    function getAll() {        
        return $resource('api/ProductsAPI').query();        
    }

    function getById(id) {
        return $resource('api/ProductsAPI/:id', {id: "@id"}).get({id: id});
    }


    function save(product) {
        return $resource('api/ProductsAPI').save(product);
    }

    return {
        getAll: getAll,
        getById : getById,
        save: save
    }
    
});


