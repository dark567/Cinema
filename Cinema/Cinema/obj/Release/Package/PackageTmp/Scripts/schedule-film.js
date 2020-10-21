$(document).ready(
    function () {
        $(".js-seat-container").on("click", ".js-seat-selector",
            function (e) {
                var targetElement = e.currentTarget;
                var dataSet = targetElement.dataset;
                var resultString = 'row:' + dataSet.seatRow + 'col:' + dataSet.seatCol;
                //console.log(resultString);
                $(".js-seat-result-container").append('<div>' + resultString + '</div>');

            });
    }
)