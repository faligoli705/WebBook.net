app.controller("editController", function ($scope, $location, BookService, ShareData) {

    var book = BookService.GetBookFindGetById(ShareData.value);
    book.then(function (res) {
        $scope.Id = res.data.Id;
        $scope.FileNameDoc = res.data.FileNameDoc;
        $scope.FileSubject = res.data.FileSubject;
        $scope.Publisher = res.data.Publisher;
        $scope.Editor = res.data.Editor;
        $scope.Printery = res.data.Printery;
        $scope.PublicationYear = res.data.PublicationYear;
        $scope.BibliographyNumber = res.data.BibliographyNumber;
        $scope.ISBN = res.data.ISBN;
        $scope.Price = res.data.Price;
        $scope.NumberOfPages = res.data.NumberOfPages;
        $scope.Link = res.data.Link;
        $scope.Extension = res.data.Extension;
        $scope.FileSize = res.data.FileSize;
        $scope.UploadDate = res.data.UploadDate;
        $scope.Other = res.data.Other;
        $scope.Author = res.data.Author;
        $scope.ForeignAuthorName = res.data.ForeignAuthorName;
        $scope.Translator = res.data.Translator;
        $scope.FileName = res.data.FileName;

    });
    $scope.EditBook = function () {
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
            FileName: $scope.FileName
        }
        var res = BookService.EditBook(ShareData.value, book);
        res.then(function () {
            ShareData.value = 0;
            $location.path("#/");
        });
    }
});