(function () {
    'use strict';

    angular
        .module('app')
        .factory('schedulesRepository', schedules);

    schedules.$inject = ['$http', '$q', 'dateHelper'];

    function schedules($http, $q, dateHelper) {
        var service = {
            getSchedules: getSchedules,
            getUpcomingSchedules: getUpcomingSchedules,
            getScheduleById: getScheduleById,
            addSchedule: addSchedule,
            editSchedule: editSchedule,
            deleteSchedule: deleteSchedule
        };

        return service;

        function getSchedules() {
            return $http.get("api/schedules").then(function (data) {
                angular.forEach(data.data, function (element, index) {
                    element.date = dateHelper.convertFromStringToDate(element.date);
                });

                return data.data;
            }, function (data, status, headers, config) {
                if (data) { return $q.reject({ exception: data.data, status: data.status }); } else { return $q.reject(); }
            })
        }

        function getUpcomingSchedules() {
            return $http.get("api/schedules/upcoming").then(function (data) {
                angular.forEach(data.data, function (element, index) {
                    element.date = dateHelper.convertFromStringToDate(element.date);
                });

                return data.data;
            }, function (data, status, headers, config) {
                if (data) { return $q.reject({ exception: data.data, status: data.status }); } else { return $q.reject(); }
            })
        }


        function getScheduleById(id) {
            return $http.get("api/schedules/" + id).then(function (data) {
                data.data.date = dateHelper.convertFromStringToDate(data.data.date);
                return data.data;
            }, function (data, status, headers, config) {
                if (data) { return $q.reject({ exception: data.data, status: data.status }); } else { return $q.reject(); }
            })
        }


        function addSchedule(schedule) {
            if (schedule.date) {
                schedule.date = dateHelper.convertFromDateToString(schedule.date);
            }

            return $http.post("api/schedules", schedule).then(function (data) {
                return data.data;
            }, function (data, status, headers, config) {
                if (data) { return $q.reject({ exception: data.data, status: data.status }); } else { return $q.reject(); }
            })
        }

        function editSchedule(schedule) {
            if (schedule.date) {
                schedule.date = dateHelper.convertFromDateToString(schedule.date);
            }

            return $http.put("api/schedules", schedule).then(function (data) {
                return data.data;
            }, function (data, status, headers, config) {
                if (data) { return $q.reject({ exception: data.data, status: data.status }); } else { return $q.reject(); }
            })
        }


        function deleteSchedule(id) {
            return $http.delete("api/schedules/" + id).then(function (data) {
                return data.data;
            }, function (data, status, headers, config) {
                if (data) { return $q.reject({ exception: data.data, status: data.status }); } else { return $q.reject(); }
            })
        }
    }
})();