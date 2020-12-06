app.controller("addBookController", function ($scope, $location, BookService) {

     $scope.save = function () {
         var bookData = {
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
            //UploadDate: $scope.UploadDate,
            Other: $scope.Other,
            Author: $scope.Author,
            ForeignAuthorName: $scope.ForeignAuthorName,
            Translator: $scope.Translator,
            FileName: $scope.FileName
        }
        
            var res = BookService.save(bookData);
         res.then(function () {
             if (res == "1") {
                 $window.alert("شابک تکراری است")
             }
             if (res == "2")
                 $window.alert("شناسه ملی تکراری است")
             else
                $location.path("#/");
            });
       

    }
});