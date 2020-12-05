app.service("BookService", function ($http) {

    this.ListBook = function () {
        return $http.get("/Api/ListBook");

    } 

    this.save = function (bookData) {
         var res = $http({
            url: "/Api/AddBook",
            method: "post",
            data: bookData
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

    this.DeleteBook = function (id) {
         var res = $http({
            url: "/Api/DeleteBook/" + id,
             method: "delete",
             data: id
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

