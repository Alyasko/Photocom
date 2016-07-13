var AuthLoadedView;
(function (AuthLoadedView) {
    AuthLoadedView[AuthLoadedView["Login"] = 0] = "Login";
    AuthLoadedView[AuthLoadedView["Signup"] = 1] = "Signup";
    AuthLoadedView[AuthLoadedView["NotLoaded"] = 2] = "NotLoaded";
})(AuthLoadedView || (AuthLoadedView = {}));
var AuthViewType;
(function (AuthViewType) {
    AuthViewType[AuthViewType["Login"] = 0] = "Login";
    AuthViewType[AuthViewType["Signup"] = 1] = "Signup";
})(AuthViewType || (AuthViewType = {}));
var AuthView = (function () {
    function AuthView() {
        this.loadingState = AuthLoadedView.NotLoaded;
        this.updateAuthPosition();
        var self = this;
        $(window).resize(function () {
            self.updateAuthPosition();
        });
    }
    AuthView.prototype.switchAuth = function () {
        if (this.loadingState === AuthLoadedView.Login) {
            this.loadSignup();
            this.loadingState = AuthLoadedView.Signup;
        }
        else if (this.loadingState === AuthLoadedView.Signup) {
            this.loadLogin();
            this.loadingState = AuthLoadedView.Login;
        }
    };
    AuthView.prototype.toggleAuthView = function () {
        $("header").toggleClass("header-collapsed");
        $("#overlapping-shadow").fadeToggle();
        $("#login-popup").fadeToggle();
    };
    AuthView.prototype.loadLogin = function () {
        this.makeXhr(AuthViewType.Login);
    };
    AuthView.prototype.loadSignup = function () {
        this.makeXhr(AuthViewType.Signup);
    };
    // "Partial/Signup"
    // "Partial/Login"
    AuthView.prototype.makeXhr = function (viewType) {
        var self = this;
        var host = viewType === AuthViewType.Login ? Helpers.makeRoute("Partial", "Login") : Helpers.makeRoute("Partial", "Signup");
        var authView = App.authView;
        $.ajax(host, {
            type: "GET",
            dataType: "text"
        }).then(function success(data) {
            self.displayAuth(data);
            if (viewType === AuthViewType.Login) {
                self.loadingState = AuthLoadedView.Login;
                $("#sign-up").click(function () {
                    authView.switchAuth();
                });
            }
            else if (viewType === AuthViewType.Signup) {
                self.loadingState = AuthLoadedView.Signup;
            }
        }, function fail(data, status) {
            alert("Error " + status);
        });
    };
    AuthView.prototype.displayAuth = function (content) {
        $("#auth-form").html(content);
    };
    AuthView.prototype.updateAuthPosition = function () {
        var loginPopup = $("#login-popup");
        var loginWidth = loginPopup.width();
        var windowWidth = $(window).width();
        loginPopup.css("left", (windowWidth / 2) - (loginWidth / 2) + "px");
    };
    return AuthView;
}());
//# sourceMappingURL=auth.js.map