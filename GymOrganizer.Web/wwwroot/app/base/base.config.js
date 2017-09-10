(function () {
    'use strict';

    angular
        .module('app')
        .config(routeConfig);

    routeConfig.$inject = ['$stateProvider'];
    function routeConfig($stateProvider) {
        $stateProvider
            .state('base', {
                url: '/',
                templateUrl: 'app/base/base.html',
                controller: 'BaseCtrl',
                controllerAs: 'vm'
            });       
    }
})();