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

    public switchAuth() {
        if (this.loadingState === AuthLoadedView.Login) {
            this.loadSignup();
            this.loadingState = AuthLoadedView.Signup;
        }
        else if (this.loadingState === AuthLoadedView.Signup) {
            this.loadLogin();
            this.loadingState = AuthLoadedView.Login;
        }
    }

    public toggleAuthView() {
        $("header").toggleClass("header-collapsed");
        $("#overlapping-shadow").fadeToggle();
        $("#login-popup").fadeToggle();
    }

    public loadLogin() {
        this.makeXhr(AuthViewType.Login);
    }

    public loadSignup() {
        this.makeXhr(AuthViewType.Signup);
    }

    // "Partial/Signup"
    // "Partial/Login"
    private makeXhr(viewType: AuthViewType) {
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
            }
        }, function fail(data, status) {
            alert("Error " + status);
        });
    }

    private initLoginFormHandlers() {
        var authView = App.authView;
        
        $("#sign-up").click(function () {
            authView.switchAuth();
        });

        $("#login-btn").click(function(e) {
            App.auth.login();
            e.preventDefault();
        });
    }

    private displayAuth(content: string) {
        $("#form-wrapper").html(content);
    }

    private updateAuthPosition() {
        var loginPopup = $("#login-popup");
        var loginWidth = loginPopup.width();
        var windowWidth = $(window).width();
        loginPopup.css("left", (windowWidth / 2) - (loginWidth / 2) + "px");
    }
}
