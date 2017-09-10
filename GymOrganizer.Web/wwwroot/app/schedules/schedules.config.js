(function () {
    'use strict';

    angular
        .module('app')
        .config(routeConfig);

    routeConfig.$inject = ['$stateProvider'];
    function routeConfig($stateProvider) {
        $stateProvider
            .state('schedules', {
                parent: 'base',
                url: 'schedules',
                templateUrl: 'app/schedules/schedules.html',
                controller: 'SchedulesCtrl',
                controllerAs: 'vm',
                resolve: {
                    schedules: ['schedulesRepository', function (schedulesRepository) {
                        return schedulesRepository.getSchedules();
                    }]
                }
            });
    }
})();