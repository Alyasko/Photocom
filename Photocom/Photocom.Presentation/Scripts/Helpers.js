var Helpers = (function () {
    function Helpers() {
    }
    Helpers.makeRoute = function (controller, action) {
        return "/" + controller + "/" + action;
    };
    Helpers.centerPosition = function (selector) {
        var loginPopup = $(selector);
        var loginWidth = loginPopup.width();
        var windowWidth = $(window).width();
        loginPopup.css("left", (windowWidth / 2) - (loginWidth / 2) + "px");
    };
    return Helpers;
}());
//# sourceMappingURL=Helpers.js.map