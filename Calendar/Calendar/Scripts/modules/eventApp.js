angular.element(document).ready(function () {
    var eventApp = angular.module('eventApp', ['ui.bootstrap']);

    eventApp.controller('eventCtrl', function($scope, $modal, $log, $http) {
        $scope.init = function (data) {
            $scope.userId = data.userId;
            $scope.day = data.day;
            $scope.events = data.events;
        }

        $scope.noEvents = function() {
            return $scope.events.length === 0;
        }

        $scope.resolveDates = function(event)
        {
            event.startDate = event.noStartDate ? null : event.startDate;
            event.endDate = event.noEndDate ? null : event.endDate;
        }

        $scope.switchToNextDay = function () {
            var today = new Date($scope.day);
            var tomorrow = new Date(today.getTime());
            tomorrow.setDate(today.getDate() + 1);
            var month = tomorrow.getMonth() + 1;
            window.location.href = "List?year=" + tomorrow.getFullYear() + "&month=" + month + "&day=" + tomorrow.getDate();
        }

        $scope.switchToPreviousDay = function () {
            var today = new Date($scope.day);
            var tomorrow = new Date(today.getTime());
            tomorrow.setDate(today.getDate() - 1);
            var month = tomorrow.getMonth() + 1;
            window.location.href = "List?year=" + tomorrow.getFullYear() + "&month=" + month + "&day=" + tomorrow.getDate();
        }

        $scope.removeEvent = function(id) {
            var event = _.findWhere($scope.events, { id: id });
            event.isRemoved = true;
            $http.post("/Event/Edit", event).then(function () {
                $.notify("Event has been removed", "success");
            }, function () {
                $.notify("Event has not been removed", "error");
            });
        }

        $scope.editEvent = function(id) {
            var modalInstance = $modal.open({
                animation: true,
                templateUrl: 'addEditEvent.html',
                controller: 'AddEditEventModalCtrl',
                scope: $scope,
                resolve: {
                    event: function () {
                        return _.findWhere($scope.events, { id: id });
                    },
                    title: function() {
                        return "Edit";
                    }
                }
            });

            modalInstance.result.then(function (event) {
                $scope.resolveDates(event);
                $http.post("/Event/Edit", event).then(function () {
                    $.notify("Event has been modified", "success");
                }, function () {
                    $.notify("Event has not been modified", "error");
                });
            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        }

        $scope.addEvent = function () {
            var modalInstance = $modal.open({
                animation: true,
                templateUrl: 'addEditEvent.html',
                controller: 'AddEditEventModalCtrl',
                scope: $scope,
                resolve: {
                    event: function () {
                        var nowDate = new Date();
                        var selectedDate = new Date($scope.day);
                        var currentDate = new Date(selectedDate.setHours(nowDate.getHours(), nowDate.getMinutes()));
                        return {
                            startDate: new Date(currentDate.setHours(currentDate.getHours() + 1)),
                            endDate: new Date(currentDate.setHours(currentDate.getHours() + 1)),
                            userId: $scope.userId,
                        }
                    },
                    title: function () {
                        return "Add";
                    },
                }
            });

            modalInstance.result.then(function (event) {
                $scope.resolveDates(event);
                $http.post("/Event/Create", event).then(function() {
                    $scope.events.push(event);
                    $.notify("Event has been added", "success");
                }, function() {
                    $.notify("Event has not been added", "error");
                });
            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        }
    });

    eventApp.controller('AddEditEventModalCtrl', ['$scope', '$modalInstance', 'event', 'title',
        function ($scope, $modalInstance, event, title) {
            $scope.title = title;
            $scope.event = event;
            $scope.event.noStartDate = event.startDate ? false : true;
            $scope.event.noEndDate = event.endDate ? false : true;
            $scope.clickOk = function () {
                $modalInstance.close(event);
            };
            $scope.clickCancel = function () {
                $modalInstance.dismiss('cancel');
            };
    }]);

    angular.bootstrap(angular.element('#eventContent'), ['eventApp']);
});