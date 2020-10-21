$(document).ready(
    function () {
        var source = document.querySelector(".js-selected-seat-template").innerHTML;
        //var source_ = document.querySelector(".entry-template").innerHTML;
        var currentCost = $('.js-seat-container')[0].dataset.currentCost;
        var template = Handlebars.compile(source);
        //var template_ = Handlebars.compile(source_);

        var selectedSeats = {
            addedSeats: [],
            sum: 0
        };

        $(".js-seat-container").on("click", ".js-seat-selector",
            function (e) {
                var targetElement = e.currentTarget;
                var dataSet = targetElement.dataset;
                //var resultString = 'row:' + dataSet.seatRow + 'col:' + dataSet.seatCol;
                //console.log(resultString);

                var newSeat = {
                    row: dataSet.seatRow,
                    seat: dataSet.seatCol
                };

                var existingSeatIndex = -1;

                for (var i = 0; i < selectedSeats.addedSeats.length; i++) {
                    var currentSeat = selectedSeats.addedSeats[i];
                    if (currentSeat.row === newSeat.row && currentSeat.seat === newSeat.seat) {
                        existingSeatIndex = i;
                        break;
                    }
                }

                if (existingSeatIndex !== -1) {
                    selectedSeats.addedSeats.splice(existingSeatIndex, 1)
                } else {
                    selectedSeats.addedSeats.push(newSeat);
                }

                selectedSeats.sum = currentCost * selectedSeats.addedSeats.length;

                var resultHtml = template(selectedSeats);
                $(".js-seat-result-container").html(resultHtml);

                //$(".js-seat-result-container").append('<div>' + resultString + '</div>');

                //var context = { title: "Собаке Качалова", row: selectedSeats.addedSeats.seatRow };
                //var html = template_(context);
                //$(".entry").html(html);

            });
    }
)