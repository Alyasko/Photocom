var Search = (function () {
    function Search() {
        this.initHandlers();
    }
    Search.prototype.initHandlers = function () {
        $("#search").click(this.toggleSearchInput);
    };
    Search.prototype.toggleSearchInput = function () {
        $("#search-bar").toggle();
    };
    return Search;
}());
//# sourceMappingURL=Search.js.map