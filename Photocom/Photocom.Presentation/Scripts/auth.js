var Auth = (function () {
    function Auth() {
    }
    Auth.prototype.login = function () {
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
        }).then(function (data) {
            alert(data.Message);
        }, function (a, b) {
            alert("Fail: " + b);
        });
    };
    Auth.prototype.signup = function () {
    };
    return Auth;
}());
//# sourceMappingURL=Auth.js.map