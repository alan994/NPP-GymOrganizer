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
            })
            .state('schedules.add', {                
                url: '/add',
                templateUrl: 'app/schedules/edit/edit.html',
                controller: 'EditScheduleCtrl',
                controllerAs: 'vm',
                data: {
                    isEdit: false
                },
                resolve: {
                    schedule: ['schedulesRepository', function (schedulesRepository) {
                        return {};
                    }],
                    users: ['usersRepository', function (usersRepository) {
                        return usersRepository.getAllCoaches();
                    }]
                }
            })
            .state('schedules.edit', {
                url: '/edit/:scheduleId',
                templateUrl: 'app/schedules/edit/edit.html',
                controller: 'EditScheduleCtrl',
                controllerAs: 'vm',
                data: {
                    isEdit: true
                },
                resolve: {
                    schedule: ['schedulesRepository', '$stateParams', function (schedulesRepository, $stateParams) {
                        return schedulesRepository.getScheduleById($stateParams.scheduleId);
                    }],
                    users: ['usersRepository', function (usersRepository) {
                        return usersRepository.getAllCoaches();
                    }]
                }
            })
            .state('schedules.delete', {
                url: '/delete/:scheduleId',
                // trigger the modal to open when this route is active
                onEnter: ['$stateParams', '$state', '$uibModal', function ($stateParams, $state, $uibModal) {
                    $uibModal.open({
                        templateUrl: 'app/schedules/delete/delete.html',
                        controller: 'DeleteScheduleCtrl',
                        controllerAs: 'vm'
                    })
                        // change route after modal result
                        .result.then(function () {
                            // change route after clicking OK button
                            $state.go('^', undefined, { reload: true });
                        }, function () {
                            // change route after clicking Cancel button or clicking background
                            $state.go('^');
                        });
                }],
                params: {
                    date: undefined
                }
            })
            ;
    }
})();