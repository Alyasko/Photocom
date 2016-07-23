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
        this.isShown = false;
        Helpers.centerPosition("#login-popup");
        var self = this;
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
        this.isShown = !this.isShown;
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
        $.ajax(host, {
            type: "GET",
            dataType: "text"
        }).then(function success(data) {
            self.displayAuth(data);
            if (viewType === AuthViewType.Login) {
                self.loadingState = AuthLoadedView.Login;
                self.initLoginFormHandlers();
            }
            else if (viewType === AuthViewType.Signup) {
                self.loadingState = AuthLoadedView.Signup;
                self.initSigninFormHandlers();
            }
        }, function fail(data, status) {
            alert("Error " + status);
        });
    };
    AuthView.prototype.initLoginFormHandlers = function () {
        var authView = App.authView;
        $("#sign-up").click(function () {
            authView.switchAuth();
        });
        $("#login-btn").click(function (e) {
            App.auth.login();
            e.preventDefault();
        });
    };
    AuthView.prototype.initSigninFormHandlers = function () {
        var authView = App.authView;
        $("#login-btn").click(function (e) {
            App.auth.signup();
            e.preventDefault();
        });
    };
    AuthView.prototype.displayAuth = function (content) {
        $("#form-wrapper").html(content);
    };
    return AuthView;
}());
//# sourceMappingURL=AuthView.js.map