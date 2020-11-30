app.service("BookService", function ($http) {

    this.ListBook = function () {
        return $http.get("/Api/ListBook");

    }
    //this.BookFindGetById = function (id) {
    //    return $http.get("Api/Book/" + 2);
    //}

    this.AddBook = function (bookdetail) {
        var res = $http({
            url: "/Api/Book",
            method: "post",
            data: bookdetail
        });
        return res;
    }

    this.EditBook = function (id, book) {
        var res = $http({
            url: "Api/EditBook/" + id,
            method: "put",
            data: book
        });
        return res;
    }
    this.DeleteBook = function (book) {
        console.log(book);
        var res = $http({
            url: '/Api/book/' + book,
            method: 'delete',
            data:book
        });
        return res;
    }
    this.GetBookFindGetById = function (book) {
        var res = $http({
            url: 'Api/GetBookFindGetById/' + book,
            method: 'get',
            data: book
        });
        return res;
    }

    this.post = function (uploadUrl, data) {
        var fd = new FormData();
        for (var key in data)
            fd.append(key, data[key]);
        $http.post(uploadUrl, fd, {
            transformRequest: angular.identity,
            headers: { 'Conten-Type': undefined }
        })
    }
})

