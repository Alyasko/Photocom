class Auth {
    constructor() {
        
    }

    public login() {
        var login = $("#tb-login").val();
        var password = $("#tb-pass").val();

        var loginData = {
            Login: login,
            Password: password
        };

        var self = this;

        $.ajax(Helpers.makeRoute("Auth", "Login"), {
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(loginData)
        }).then(function(data) {
            if (data.Result === "Successful") {
                self.loadUserLoginToolbar();
                App.authView.toggleAuthView();

                // Debug
                location.reload();
                
                // Check for MS IE.
                if (window.navigator.userAgent.indexOf("Trident") !== -1) {
                    location.reload();
                }
            } else {
                alert(data.Result);
            }
        }, function(a, b) {
            alert("Fail: " + b);
        });
    }

    public signup() {
        var firstName = $("#tb-first-name").val();
        var lastName = $("#tb-last-name").val();
        var email = $("#tb-email").val();
        var pass = $("#tb-pass").val();
        var confirmPass = $("#tb-pass-confirm").val();
        var about = $("#ta-about").val();
        var login = $("#tb-login").val();

        // Validation.
        if (login !== "" &&
            firstName !== "" &&
            lastName !== "" &&
            email !== "" &&
            pass !== "" &&
            confirmPass !== "" &&
            pass === confirmPass &&
            about.length >= 10) {

            var self = this;

            var signupData = {
                FirstName: firstName,
                LastName: lastName,
                Login: login,
                Password: pass,
                ConfirmationPassword: confirmPass,
                AboutUser: about,
                Email: email
            }

            $.ajax(Helpers.makeRoute("Auth", "Signup"), {
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(signupData)
            }).then(function (data) {
                if (data.Result === "Successful") {
                    self.loadUserLoginToolbar();
                    App.authView.toggleAuthView();

                    alert("User created!");
                } else {
                    alert(data.Result);
                }
            }, function (a, b) {
                alert("Fail: " + b);
            });

        } else {
            alert("Fill all fields");
        }
    }

    public loadUserLoginToolbar() {
        $.ajax(Helpers.makeRoute("Partial", "GetUserToolbar"), {
            type: "GET",
            contentType: "application/html; charset=utf-8"
        }).then(function (data) {
            $("#user-toolbar-wrapper").html(data);
            var authView = App.authView;

            $(".toolbar-btn#user").click(function () {
                if (authView.loadingState === AuthLoadedView.NotLoaded ||
                    authView.loadingState === AuthLoadedView.Signup) {
                    authView.loadLogin();
                }
                authView.toggleAuthView();
            });

        }, function (a, b) {
            alert("Fail: " + b);
        });
    }
}