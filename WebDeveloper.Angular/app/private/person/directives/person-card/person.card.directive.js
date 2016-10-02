﻿(function () {
    'use strict';
    angular.module('app')
        .directive('personCard', personCard);

    function personCard() {
        return {
            templateUrl: 'app/private/person/directives/person-card/person-card.html',
            restrict: 'E',
            transclude: true,
            scope: {
                personId: '@',
                firstName: '@',
                lastName: '@',
                modifiedDate: '@'
            }
        };
    }
})();