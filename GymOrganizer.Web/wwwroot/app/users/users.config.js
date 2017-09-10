(function () {
    'use strict';

    angular
        .module('app')
        .config(routeConfig);

    routeConfig.$inject = ['$stateProvider'];
    function routeConfig($stateProvider) {
        $stateProvider
            .state('users', {
                parent: 'base',
                url: 'users',
                templateUrl: 'app/users/users.html',
                controller: 'UsersCtrl',
                controllerAs: 'vm',
                resolve:{
                    users: ['usersRepository', function (usersRepository) {
                        return usersRepository.getUsers();
                    }]
                }
            })
            .state('users.add', {                
                url: '/add',
                templateUrl: 'app/users/edit/edit.html',
                controller: 'EditUserCtrl',
                controllerAs: 'vm',
                data: {
                    isEdit: false
                },
                resolve: {
                    user: ['usersRepository', function (usersRepository) {
                        return {};
                    }]
                }
            })
            .state('users.edit', {                
                url: 'edit/:userId',
                templateUrl: 'app/users/edit/edit.html',
                controller: 'EditUserCtrl',
                controllerAs: 'vm',
                data: {
                    isEdit: true
                },
                resolve: {
                    user: ['usersRepository', '$stateParams', function (usersRepository, $stateParams) {
                        return usersRepository.getUserById($stateParams.userId);
                    }]
                }
            })
            .state('users.delete', {
                url: '/delete/:userId',
                // trigger the modal to open when this route is active
                onEnter: ['$stateParams', '$state', '$uibModal', function ($stateParams, $state, $uibModal) {
                    $uibModal.open({
                        templateUrl: 'app/users/delete/delete.html',
                        controller: 'DeleteUserCtrl',
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
                    fullName: undefined
                }
            })
            ;
    }
})();