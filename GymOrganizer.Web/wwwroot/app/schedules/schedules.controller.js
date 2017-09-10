(function () {
    'use strict';

    angular
        .module('app')
        .controller('SchedulesCtrl', schedulesCtrl);

    schedulesCtrl.$inject = ['$location'];

    function schedulesCtrl($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'schedules';

        activate();

        function activate() { }
    }
})();
