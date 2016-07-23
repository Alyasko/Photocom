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
    public loadingState: AuthLoadedView;
    public isShown: Boolean;

    constructor() {
        this.loadingState = AuthLoadedView.NotLoaded;
        this.isShown = false;

        Helpers.centerPosition("#login-popup");

        var self = this;
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
        this.isShown = !this.isShown;
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

                self.initSigninFormHandlers();
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

    private initSigninFormHandlers() {
        var authView = App.authView;

        $("#login-btn").click(function (e) {
            App.auth.signup();
            e.preventDefault();
        });
    }

    private displayAuth(content: string) {
        $("#form-wrapper").html(content);
    }
}
