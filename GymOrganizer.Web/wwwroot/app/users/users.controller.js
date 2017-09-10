(function () {
    'use strict';

    angular
        .module('app')
        .controller('UsersCtrl', usersCtrl);

    usersCtrl.$inject = ['$location', 'users'];

    function usersCtrl($location, users) {
        /* jshint validthis:true */
        var vm = this;
        vm.formData = {
            users: users
        };
    }
})();
