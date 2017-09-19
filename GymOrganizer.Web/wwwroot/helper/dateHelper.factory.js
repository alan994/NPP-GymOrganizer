(function () {
    'use strict';

    angular
        .module('app')
        .factory('dateHelper', dateHelper);

    dateHelper.$inject = ['$http'];

    function dateHelper($http) {
        var service = {
            convertFromDateToString: convertFromDateToString,
            convertFromStringToDate: convertFromStringToDate
        };

        return service;

        function convertFromDateToString(date) {
            if (date && date instanceof Date) {

                if (date.getHours() === 0 && date.getMinutes() === 0) {
                    var currentEndTimeZoneOffsetInHours = Math.abs(date.getTimezoneOffset() / 60);
                    date.setHours(date.getHours() + currentEndTimeZoneOffsetInHours);
                }

                date = date.toISOString();
            }
            return date;
        }



        function convertFromStringToDate(dateStr) {
            if (dateStr && (typeof dateStr === 'string' || dateStr instanceof String)) {
                if (dateStr[dateStr.length - 1] === 'Z' || dateStr[dateStr.length - 1] === 'z') {
                    dateStr = new Date(dateStr);
                }
                else {
                    dateStr = new Date(dateStr + 'Z');
                }
            }
            return dateStr;
        }
    }
})();