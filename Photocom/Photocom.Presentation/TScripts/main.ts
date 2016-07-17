/// <reference path="jquery.d.ts" />

$(document).ready(function () {
    var main = new Main();
    main.run();
});

class Main {

    constructor() {
        this.createInstances();
    }

    run() {
        this.initHandlers();
        App.auth.loadUserLoginToolbar();
    }

    private createInstances() {
        var search = App.search;
    }

    private initHandlers() {
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
    }
}
