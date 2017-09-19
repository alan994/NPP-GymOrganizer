(function () {
    'use strict';

    angular
        .module('app')
        .controller('EditScheduleCtrl', editScheduleCtrl);

    editScheduleCtrl.$inject = ['schedule', 'schedulesRepository', '$state', 'users', '$locale'];

    function editScheduleCtrl(schedule, schedulesRepository, $state, users, $locale) {
        var vm = this;
        vm.isEdit = $state.current.data.isEdit;
        vm.item = schedule;
        vm.formData = {
            users: users,
            format: $locale.DATETIME_FORMATS.shortDate
        };

        vm.isDatePickerOpen = false;

        vm.add = add;
        vm.edit = edit;
        vm.toggleDatePicker = toggleDatePicker;

        function toggleDatePicker() {
            vm.isDatePickerOpen = !vm.isDatePickerOpen;
        }


        function add() {
            schedulesRepository.addSchedule(vm.item).then(function (data) {
                //TODO: log something
                $state.go("^", undefined, { reload: true });
            }, function (error) {
                //TODO: log something
                $state.go("^", undefined, { reload: true });
            });
        }

        function edit() {
            schedulesRepository.editSchedule(vm.item).then(function (data) {
                //TODO: log something
                $state.go("^", undefined, { reload: true });
            }, function (error) {
                //TODO: log something
                $state.go("^", undefined, { reload: true });
            });
        }
    }
})();
