class Helpers {
    static makeRoute(controller: string, action: string): string {
        return "/" + controller + "/" + action;
    }
}