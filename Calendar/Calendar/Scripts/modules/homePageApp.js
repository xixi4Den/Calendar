angular.element(document).ready(function () {

    angular.module('homePageApp', []).controller('homePageCtrl', function ($scope) {

        $scope.calendar = angular.element('#calendar').calendario(
            {
                onDayClick: function($el, $content, dateProperties) {
                    
                }
            }
        );

        $scope.switchToNextMonth = function() {
            $scope.calendar.gotoNextMonth();
        };

        $scope.switchToPreviousMonth = function () {
            $scope.calendar.gotoPreviousMonth();
        };

        $scope.switchToToday = function () {
            $scope.calendar.gotoNow();
        };

        $scope.formattedMonthAndYear = function () {
            var currentMonth = $scope.calendar.getMonthName();
            var currentYear = $scope.calendar.getYear();
            return currentMonth + " " + currentYear;
        }
    });

    angular.bootstrap(angular.element('#homePageContent'), ['homePageApp']);
});