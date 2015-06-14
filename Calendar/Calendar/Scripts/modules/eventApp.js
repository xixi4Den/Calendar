angular.element(document).ready(function () {
    var eventApp = angular.module('eventApp', ['ui.bootstrap']);

    eventApp.controller('eventCtrl', function($scope, $modal, $log) {
        $scope.init = function (data) {
            $scope.userId = data.userId;
            $scope.day = data.day;
            $scope.events = data.events;
        }

        $scope.removeEvent = function(id) {
            _.findWhere($scope.events, { id: id }).isRemoved = true;
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

            modalInstance.result.then(function (id) {
                $log.info('Ок. Modal dismissed at: ' + new Date());
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
                        return {
                            startDate: nowDate.setHours(nowDate.getHours() + 1),
                            endDate: nowDate.setHours(nowDate.getHours() + 2),
                        }
                    },
                    title: function () {
                        return "Add";
                    }
                }
            });

            modalInstance.result.then(function (id) {
                $log.info('Ок. Modal dismissed at: ' + new Date());
            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        }
    });

    eventApp.controller('AddEditEventModalCtrl', ['$scope', '$modalInstance', 'event', 'title', function ($scope, $modalInstance, event, title) {
        $scope.title = title;
        $scope.event = event;
        $scope.noStartDate = event.startDate ? false : true;
        $scope.noEndDate = event.endDate ? false : true;
        $scope.clickOk = function () {
            $modalInstance.close();
        };
        $scope.clickCancel = function () {
            $modalInstance.dismiss('cancel');
        };
    }]);

    //eventApp.config(function($timepickerProvider) {
    //    angular.extend($timepickerProvider.defaults, {
    //        arrowBehavior: 'picker',
    //        timeFormat: 'HH:mm',
    //        length: 1,
    //        timezone: 'UTC'
    //    });
    //});

    angular.bootstrap(angular.element('#eventContent'), ['eventApp']);
});