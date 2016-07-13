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
    };
    Main.prototype.createInstances = function () {
        var search = App.search;
    };
    Main.prototype.initHandlers = function () {
        var authView = App.authView;
        $(".photo").hover(function () {
            $(this).children(".photo-info").toggleClass("hide-info");
        });
        $(".toolbar-btn#user").click(function () {
            if (authView.loadingState === AuthLoadedView.NotLoaded ||
                authView.loadingState === AuthLoadedView.Signup) {
                authView.loadLogin();
            }
            authView.toggleAuthView();
        });
        $("#overlapping-shadow").click(function () {
            authView.toggleAuthView();
        });
    };
    return Main;
}());
//# sourceMappingURL=main.js.map