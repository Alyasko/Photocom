var Photo = (function () {
    function Photo() {
        this.initHandlers();
        // TODO: Remove.
        Helpers.centerPosition("#opened-photo-wrapper");
    }
    Photo.prototype.initHandlers = function () {
    };
    Photo.prototype.openPhoto = function (id) {
        $.get(Helpers.makeRoute("Partial", "LoadPhoto"), { id: id }).done(function (data) {
            $("#opened-photo-wrapper").html(data);
            Helpers.centerPosition("#opened-photo-wrapper");
            $("#overlapping-shadow").show();
            $("#opened-photo-wrapper").show();
        });
    };
    Photo.prototype.closePhoto = function () {
        $("#overlapping-shadow").fadeOut();
        $("#opened-photo-wrapper").fadeOut();
    };
    Photo.prototype.like = function (id) {
        var self = this;
        $.ajax(Helpers.makeRoute("Photo", "Like"), {
            type: "POST",
            dataType: "json",
            data: JSON.stringify({ id: id }),
            contentType: "application/json; charset=utf-8"
        })
            .done(function (data) {
            if (data.Result === "Success") {
                $(".likes-count-" + id).html(data.LikesCount);
            }
            else if (data.Result === "Login") {
                $("#opened-photo-wrapper").hide();
                $("#overlapping-shadow").hide();
                var authView = App.authView;
                if (authView.loadingState === AuthLoadedView.NotLoaded ||
                    authView.loadingState === AuthLoadedView.Signup) {
                    authView.loadLogin();
                }
                authView.toggleAuthView();
            }
            else {
                alert(data.Result);
            }
        }).fail(function () {
            alert("Like ajax failed.");
        });
    };
    return Photo;
}());
//# sourceMappingURL=Photo.js.map