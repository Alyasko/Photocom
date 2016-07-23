/// <reference path="jquery.d.ts" />
$(document).ready(function () {
    var main = new Main();
    main.run();
});
var Main = (function () {
    function Main() {
        this.createInstances();
    }
    Main.prototype.run = function () {
        this.initHandlers();
        App.auth.loadUserLoginToolbar();
    };
    Main.prototype.createInstances = function () {
        var search = App.search;
    };
    Main.prototype.initHandlers = function () {
        var authView = App.authView;
        var photo = App.photo;
        $(window).resize(function () {
            Helpers.centerPosition("#login-popup");
            Helpers.centerPosition("#opened-photo-wrapper");
        });
        $(".photo").hover(function () {
            $(this).children(".photo-info").toggleClass("hide-info");
        });
        $(".photo").click(function () {
            var id = $(this).find(".photo-image").attr("data-id");
            photo.openPhoto(parseInt(id));
        });
        $(".toolbar-btn#user").click(function () {
            if (authView.loadingState === AuthLoadedView.NotLoaded ||
                authView.loadingState === AuthLoadedView.Signup) {
                authView.loadLogin();
            }
            authView.toggleAuthView();
        });
        $("#overlapping-shadow").click(function () {
            if (authView.isShown === true) {
                authView.toggleAuthView();
            }
            else {
                photo.closePhoto();
            }
        });
    };
    return Main;
}());
//# sourceMappingURL=Main.js.map