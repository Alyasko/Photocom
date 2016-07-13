
class App {
    private static _authView: AuthView;
    private static _search: Search;

    constructor() {
        App._authView = null;
        App._search = null;
    }

    static get authView(): AuthView {
        if (App._authView == null) {
            App._authView = new AuthView();
        }
        return App._authView;
    }

    static get search(): Search {
        if (App._search == null) {
            App._search = new Search();
        }
        return App._search;
    }

}