(function () {
    'use strict';

    angular
        .module('app')
        .controller('SchedulesCtrl', schedulesCtrl);

    schedulesCtrl.$inject = ['schedules'];

    function schedulesCtrl(schedules) {        
        var vm = this;
        vm.formData = {
            schedules: schedules
        };
    }
})();
