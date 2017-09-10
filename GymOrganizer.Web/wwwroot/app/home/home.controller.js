(function () {
    'use strict';

    angular
        .module('app')
        .controller('HomeCtrl', homeCtrl);

    homeCtrl.$inject = ['$location'];

    function homeCtrl($location) {
        var vm = this;
        vm.title = "Home"
                
    }
})();
