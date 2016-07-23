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
            } else {
                photo.closePhoto();
            }
        });
    }
}
