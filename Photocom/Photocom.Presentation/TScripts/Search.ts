
class Search {
    constructor() {
        this.initHandlers();
    }

    initHandlers() {
        $("#search").click(this.toggleSearchInput);
    }

    toggleSearchInput() {
        $("#search-bar").toggle();
    }

}
