(function () {
    'use strict';

    angular
        .module('app')
        .config(routeConfig);

    routeConfig.$inject = ['$stateProvider', '$urlRouterProvider'];
    function routeConfig($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('base', {
                url: '/',
                templateUrl: 'app/base/base.html',
                controller: 'BaseCtrl',
                controllerAs: 'vm'
            });       

        $urlRouterProvider.otherwise('/home');

    }
})();