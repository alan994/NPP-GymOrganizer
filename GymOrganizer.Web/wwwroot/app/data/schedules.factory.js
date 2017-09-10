(function () {
    'use strict';

    angular
        .module('app')
        .factory('schedulesRepository', schedules);

    schedules.$inject = ['$http', '$q'];

    function schedules($http, $q) {
        var service = {
            getSchedules: getSchedules,
            getScheduleById: getScheduleById,
            addSchedule: addSchedule,
            editSchedule: editSchedule,
            deleteSchedule: deleteSchedule
        };

        return service;

        function getSchedules() {
            return $http.get("api/schedules").then(function (data) {
                return data.data;
            }, function (data, status, headers, config) {
                if (data) { return $q.reject({ exception: data.data, status: data.status }); } else { return $q.reject(); }
            })
        }


        function getScheduleById(id) {
            return $http.get("api/schedules/" + id).then(function (data) {
                return data.data;
            }, function (data, status, headers, config) {
                if (data) { return $q.reject({ exception: data.data, status: data.status }); } else { return $q.reject(); }
            })
        }


        function addSchedule(schedule) {
            return $http.post("api/schedules", schedule).then(function (data) {
                return data.data;
            }, function (data, status, headers, config) {
                if (data) { return $q.reject({ exception: data.data, status: data.status }); } else { return $q.reject(); }
            })
        }

        function editSchedule(schedule) {
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