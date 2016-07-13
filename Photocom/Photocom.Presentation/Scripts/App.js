var App = (function () {
    function App() {
        App._authView = null;
        App._search = null;
    }
    Object.defineProperty(App, "authView", {
        get: function () {
            if (App._authView == null) {
                App._authView = new AuthView();
            }
            return App._authView;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(App, "search", {
        get: function () {
            if (App._search == null) {
                App._search = new Search();
            }
            return App._search;
        },
        enumerable: true,
        configurable: true
    });
    return App;
}());
//# sourceMappingURL=App.js.map