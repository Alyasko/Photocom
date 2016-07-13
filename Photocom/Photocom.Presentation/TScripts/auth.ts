enum AuthLoadedView {
    Login,
    Signup,
    NotLoaded
}

enum AuthViewType {
    Login,
    Signup
}

class AuthView {
    loadingState: AuthLoadedView;

    constructor() {
        this.loadingState = AuthLoadedView.NotLoaded;
        this.updateAuthPosition();

        var self = this;

        $(window).resize(function () {
            self.updateAuthPosition();
        });
    }

    switchAuth() {
        if (this.loadingState === AuthLoadedView.Login) {
            this.loadSignup();
            this.loadingState = AuthLoadedView.Signup;
        }
        else if (this.loadingState === AuthLoadedView.Signup) {
            this.loadLogin();
            this.loadingState = AuthLoadedView.Login;
        }
    }

    toggleAuthView() {
        $("header").toggleClass("header-collapsed");
        $("#overlapping-shadow").fadeToggle();
        $("#login-popup").fadeToggle();
    }

    loadLogin() {
        this.makeXhr(AuthViewType.Login);
    }

    loadSignup() {
        this.makeXhr(AuthViewType.Signup);
    }

    // "Partial/Signup"
    // "Partial/Login"
    private makeXhr(viewType: AuthViewType) {
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
    }

    private displayAuth(content: string) {
        $("#auth-form").html(content);
    }

    private updateAuthPosition() {
        var loginPopup = $("#login-popup");
        var loginWidth = loginPopup.width();
        var windowWidth = $(window).width();
        loginPopup.css("left", (windowWidth / 2) - (loginWidth / 2) + "px");
    }
}
