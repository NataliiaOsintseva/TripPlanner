// simpleControls.js

(function () {
    "use strict";

    // Creating module, therefore []
    angular.module("simpleControls", [])
    .directive("waitCursor", waitCursor);

    function waitCursor() {
        return {
            scope: {
                show: "=displayWhen"
            },
            restrict: "E",
            templateUrl: "/views/waitCursor.html"
        };
    }

})();