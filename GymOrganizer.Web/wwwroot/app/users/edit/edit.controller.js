(function () {
    'use strict';

    angular
        .module('app')
        .controller('EditUserCtrl', editUserCtrl);

    editUserCtrl.$inject = ['user', 'usersRepository', '$state'];

    function editUserCtrl(user, usersRepository, $state) {
        
        var vm = this;
        vm.isEdit = $state.current.data.isEdit;
        vm.item = user;

        vm.add = add;
        vm.edit = edit;

        function add() {
            usersRepository.addUser(vm.item).then(function (data) {
                //TODO: log something
                $state.go("^", undefined, { reload: true });
            }, function (error) {
                //TODO: log something
                $state.go("^", undefined, { reload: true });
            });
        }

        function edit() {
            usersRepository.editUser(vm.item).then(function (data) {
                //TODO: log something
                $state.go("^", undefined, { reload: true });
            }, function (error) {
                //TODO: log something
                $state.go("^", undefined, { reload: true });
            });
        }
                
    }
})();
