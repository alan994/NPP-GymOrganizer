(function () {
    'use strict';

    angular
        .module('app')
        .filter('userType', userTypeFilter);

    userTypeFilter.$inject = [];

    function userTypeFilter() {
        return function (input) {
            var value = input;
            if (value == 1){
                return 'Član';
            }
            else if (value == 2) {
                return 'Trener';
            }
        };
    }
})();
