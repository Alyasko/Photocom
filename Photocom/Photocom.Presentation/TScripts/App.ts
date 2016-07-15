
class App {
    private static _authView: AuthView;
    private static _auth: Auth;
    private static _search: Search;

    constructor() {
        App._authView = null;
        App._search = null;
        App._auth = null;
    }

    static get authView(): AuthView {
        if (App._authView == null) {
            App._authView = new AuthView();
        }
        return App._authView;
    }

    static get auth(): Auth {
        if (App._auth == null) {
            App._auth = new Auth();
        }
        return App._auth;
    }

    static get search(): Search {
        if (App._search == null) {
            App._search = new Search();
        }
        return App._search;
    }
}