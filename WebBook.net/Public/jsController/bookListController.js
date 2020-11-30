app.controller("bookListController", function ($scope, $location, $window, BookService, ShareData) {

     var list = BookService.ListBook();
    list.then(function (res) {
        console.log(res)
        $scope.book = res.data;
 
    });

    $scope.deleteBook = function (id) {
        ShareData.value = id;
        console.log(ShareData.value)
        var deleteBook = $window.confirm("آیا برای حذف مطمئن هستید؟");
        if (deleteBook) {
            console.log(ShareData.value)
            console.log(deleteBook)
            var res = BookService.DeleteBook(ShareData.value);
            res.then(function () {
                ShareData.value = 0;
                $location.path("/");
            });
        }
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
