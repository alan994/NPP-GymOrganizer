(function () {
    'use strict';

    angular
        .module('app')
        .controller('HomeCtrl', homeCtrl);

    homeCtrl.$inject = ['schedules'];

    function homeCtrl(schedules) {
        var vm = this;
        vm.formData = {
            schedules: schedules
        };
                
    }
})();
