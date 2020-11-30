var app = angular.module("BookApp", ["ngRoute"]);

 app.factory("ShareData", function () {
    return { value: 0 }
});


app.config(["$routeProvider", function ($routeProvider) {

        $routeProvider.when("/", {
        templateUrl: "Home/ListBook",
        controller: "bookListController"
    });

    $routeProvider.when("#/List", {
        templateUrl: "Home/ListBook",
        controller: "bookListController"
    });

    $routeProvider.when("/Add", {
        templateUrl: "Home/AddBook",
        controller: "addBookController"
    });

    $routeProvider.when("/Edit", {
        templateUrl: "Home/EditBook/",
        controller: "editController"
    }); 

    $routeProvider.when("/specifications", {
        templateUrl: "Home/Specifications/",
        controller: "specificationsController"
    });
}]);