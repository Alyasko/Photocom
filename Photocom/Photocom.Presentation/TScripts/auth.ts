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

        $.ajax(Helpers.makeRoute("Auth", "Login"), {
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(loginData)
        }).then(function(data) {
            alert(data.Message);
        }, function(a, b) {
            alert("Fail: " + b);
        });
    }

    public signup() {
        
    }
}