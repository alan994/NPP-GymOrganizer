(function () {
    'use strict';

    angular
        .module('app')
        .factory('usersRepository', users);

    users.$inject = ['$http', '$q'];

    function users($http, $q) {
        var service = {
            getUsers: getUsers,
            getUserById: getUserById,
            addUser: addUser,
            editUser: editUser,
            deleteUser: deleteUser,
            getAllCoaches: getAllCoaches
        };

        return service;

        function getUsers() {
            return $http.get("api/users").then(function (data) {
                return data.data;
            }, function (data, status, headers, config) {
                if (data) { return $q.reject({ exception: data.data, status: data.status }); } else { return $q.reject(); }
            })
        }


        function getUserById(id) {
            return $http.get("api/users/" + id).then(function (data) {
                return data.data;
            }, function (data, status, headers, config) {
                if (data) { return $q.reject({ exception: data.data, status: data.status }); } else { return $q.reject(); }
            })
        }


        function addUser(user) {
            return $http.post("api/users", user).then(function (data) {
                return data.data;
            }, function (data, status, headers, config) {
                if (data) { return $q.reject({ exception: data.data, status: data.status }); } else { return $q.reject(); }
            })
        }

        function editUser(user) {
            return $http.put("api/users", user).then(function (data) {
                return data.data;
            }, function (data, status, headers, config) {
                if (data) { return $q.reject({ exception: data.data, status: data.status }); } else { return $q.reject(); }
            })
        }


        function deleteUser(id) {
            return $http.delete("api/users/" + id).then(function (data) {
                return data.data;
            }, function (data, status, headers, config) {
                if (data) { return $q.reject({ exception: data.data, status: data.status }); } else { return $q.reject(); }
            })
        }

        function getAllCoaches() {
            return getUsers().then(function (data) {
                angular.forEach(data, function (user, index) {
                    if (user.type == 1) {
                        data.splice(index, 1);
                    }
                });
                return data;
            }, function (error) {
                $q.reject(error);
            });
        }
    }
})();