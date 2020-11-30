app.controller("specificationsController", function ($scope,$location,BookService, ShareData) {
    var bookData = BookService.GetBookFindGetById(ShareData.value);
    console.log("ShareData" + ShareData)
    bookData.then(function myfunction(res) {
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
});