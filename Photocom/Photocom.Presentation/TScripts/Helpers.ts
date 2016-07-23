class Helpers {
    static makeRoute(controller: string, action: string): string {
        return "/" + controller + "/" + action;
    }

    public static centerPosition(selector: string) {
        var loginPopup = $(selector);
        var loginWidth = loginPopup.width();
        var windowWidth = $(window).width();
        loginPopup.css("left", (windowWidth / 2) - (loginWidth / 2) + "px");
    }
}