(function () {
    'use strict';

    angular
        .module('app')
        .controller('DeleteUserCtrl', deleteUserCtrl);

    deleteUserCtrl.$inject = ['$state', '$scope', '$stateParams', 'usersRepository'];

    function deleteUserCtrl($state, $scope, $stateParams, usersRepository) {
        var vm = this;        
        vm.formData = {
            fullName: $stateParams.fullName
        }

        vm.cancel = cancel;
        vm.ok = ok;
                
        function cancel() {
            $scope.$dismiss();
        };

        function ok() {
            usersRepository.deleteUser($stateParams.userId).then(function (result) {                
                //TODO: log something
                $scope.$close(true);
            }, function (error) {
                //TODO: log something
            });
        };               
    }
})();
