(function () {
    'use strict';

    angular
        .module('app')
        .controller('BaseCtrl', baseCtrl);

    baseCtrl.$inject = [];

    function baseCtrl() {        
        var vm = this;        
    }
})();
