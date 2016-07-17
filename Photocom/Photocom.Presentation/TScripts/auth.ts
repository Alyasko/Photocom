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
        
    }

    public loadUserLoginToolbar() {
        $.ajax(Helpers.makeRoute("Partial", "GetLoggedInUser"), {
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