$(document).ready(function () {
    updateLoginPosition();
    $(window).resize(function () {
        updateLoginPosition();
    });
});
function updateLoginPosition() {
    var loginPopup = $("#login-popup");
    var loginWidth = loginPopup.width();
    var windowWidth = $(window).width();
    loginPopup.css("left", (windowWidth / 2) - (loginWidth / 2) + "px");
}
//# sourceMappingURL=login.js.map