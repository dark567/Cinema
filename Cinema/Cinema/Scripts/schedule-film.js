$(document).ready(
    function () {
        var source = document.querySelector(".js-selected-seat-template").innerHTML;
        var currentCost = $('.js-seat-container')[0].dataset.currentCost;
        var currentTimeSlotId = $('.js-seat-container')[0].dataset.currentTimeslotId;
        var template = Handlebars.compile(source);
        var selectedSeats = {
            addedSeats: [],
            sum: 0
        };

        $(".js-seat-container").on("click", ".js-seat-selector",
            function (e) {
                var targetElement = e.currentTarget;
                var dataSet = targetElement.dataset;
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
            });

        $(".js-seat-container").on("click", ".js-reserve-seats",
            function (e) {
                sendSeatsToServer('reserve');
            });
        $(".js-seat-container").on("click", ".js-buy-seats",
            function (e) {
                sendSeatsToServer('buy');
            });

        
        function sendSeatsToServer(status) {
            var resultModel = {
                seatsRequest: selectedSeats,
                selectedStatus: status,
                timeSlotId: currentTimeSlotId
            };
            $.ajax(
                {
                    url: "/tickets/processRequest",
                    type: 'POST',
                    dataType: 'json',
                    contentType: 'application/json;charset=utf-8',
                    data: JSON.stringify(resultModel)
                }).done(function() {
                    alert("Order processed successfully");
                }).fail(function () {
                    alert("Order processing failed. Please, contact administrator!")
                })
        }
    }
)