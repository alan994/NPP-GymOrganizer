(function () {
    'use strict';

    angular
        .module('app')
        .controller('DeleteScheduleCtrl', deleteScheduleCtrl);

    deleteScheduleCtrl.$inject = ['$state', '$scope', '$stateParams', 'schedulesRepository'];

    function deleteScheduleCtrl($state, $scope, $stateParams, schedulesRepository) {        
        var vm = this;
        vm.formData = {
            fullName: $stateParams.date
        }

        vm.cancel = cancel;
        vm.ok = ok;

        function cancel() {
            $scope.$dismiss();
        };

        function ok() {
            schedulesRepository.deleteSchedule($stateParams.scheduleId).then(function (result) {
                //TODO: log something
                $scope.$close(true);
            }, function (error) {
                //TODO: log something
            });
        };          
    }
})();
