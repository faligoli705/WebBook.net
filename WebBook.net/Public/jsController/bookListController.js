app.controller("bookListController", function ($scope, $location, $window, $q, BookService, ShareData) {

    var list = BookService.ListBook();
    list.then(function (res) {
        console.log(res)
        $scope.book = res.data;

    });

    $scope.deleteBook = function (id) {
        $q.when($window.confirm("آیا برای حذف مطمئن هستید؟"))
            .then((confirm) => {
                var res = BookService.DeleteBook(id);
                res.then(function () {
                    ShareData.value = 0;
                    $location.path("/");
                })
            });
    }
    

    $scope.specifications = function (id) {
        var b = $scope.book;
        ShareData.value = id;
        $location.path("/specifications");
    }
    $scope.EditBook = function (id) {
        ShareData.value = id;
        $location.path("/Edit");
    }

    $scope.AddBook = function (Id) {
        ShareData.value = Id;
        $location.path("/List");
    }
});
