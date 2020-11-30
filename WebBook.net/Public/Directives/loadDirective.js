app.directive("mApLoading", function ($animated) {
    return ({
        link: link,
        restrict: "C"
    });
    function link(scope, element, attributes) {
        $animate.Leave(element.children().eq(1)).then(
            function cleanAfterAnimation() {
                element.remove();
                scope = element = attributes = null;
            }
    )}
})