app.controller("addBookController", function ($scope, $location, BookService, ShareData) {



    $scope.FileName = {};
    $scope.save = function () {
        var uploadUrl = '/upload';
        var book = {
            FileNameDoc: $scope.FileNameDoc,
            FileSubject: $scope.FileSubject,
            Publisher: $scope.Publisher,
            Editor: $scope.Editor,
            Printery: $scope.Printery,
            PublicationYear: $scope.PublicationYear,
            BibliographyNumber: $scope.BibliographyNumber,
            ISBN: $scope.ISBN,
            Price: $scope.Price,
            NumberOfPages: $scope.NumberOfPages,
            Link: $scope.Link,
            Extension: $scope.Extension,
            FileSize: $scope.FileSize,
            UploadDate: $scope.UploadDate,
            Other: $scope.Other,
            Author: $scope.Author,
            ForeignAuthorName: $scope.ForeignAuthorName,
            Translator: $scope.Translator,
            FileName: $scope.uploadUrl,
            FileSize: $scope.FileName
        }
        $scope.save = function () {
            var res = BookService.AddBook(book);
            res.then(function () {
                $location.path("#/");
            });
        }

    }
});