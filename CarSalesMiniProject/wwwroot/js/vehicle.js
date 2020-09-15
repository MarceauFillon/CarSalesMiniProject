$(document).ready(function () {
    var request_pending = false;

    $('#choice-make').change(function () {
    var selectedMake = $("#choice-make").val();
    var modelsSelect = $('#choice-model');
    modelsSelect.empty();
        if (selectedMake != null && selectedMake != '') {
            $.getJSON('GetModels', { makeId: selectedMake }, function (models) {
                if (models != null && !jQuery.isEmptyObject(models)) {
                    modelsSelect.append($('<option/>', {
                        value: "",
                        text: "Select Model"
                    }));
                    $.each(models, function (index, model) {
                        modelsSelect.append($('<option/>', {
                            value: model.value,
                            text: model.text
                        }));
                    });
                };
            });
        }
        else if (selectedMake == "") {
            modelsSelect.append($('<option/>', {
                value: "",
                text: "Select Model"
            }));
        }
    });

    $(window).scroll(function () {
        if (request_pending) {
            return;
        }

        loaded_cars_number = $(".vehicle-abstract").length;
        console.log(loaded_cars_number);
        if (($(window).scrollTop() + $(window).height() > $(document).height() - 100) &&
            (loaded_cars_number % 10 == 0)) {
            request_pending = true;

            $.getJSON('Get10MoreCars', { numberOfLoadedCars: loaded_cars_number }, function (cars) {
                if (cars != null && !jQuery.isEmptyObject(cars)) {
                    more_loaded_cars(cars);
                    request_pending = false;
                };
            });
        }
    });
});

function more_loaded_cars(cars) {
    container = $("#vehicles-abstracts")
    var row_string = ""
    $.each(cars, function (index, car) {
        console.log(car)
        if (index % 2 == 0) {
            row_string = "<div class=\"row mt-3\">"
        }
        row_string = row_string + "<a class=\"py-2 col-5 container-fluid vehicle-abstract rounded\" asp-controller=\"Vehicle\" asp-action=\"ViewVehicle\" asp-route-VehicleId=\"" + car.id + "\">"
            + "<div class=\"row justify-content-center\">"
            + "<div class=\"col-10 car-image py-5 text-center\">"
            + "<span class=\"fa fa-car\"></span>"
            + "</div> </div>"
            + "<div class=\"row\">"
            + "<div class=\"col-6 font-weight-bold\">"
            + car.make + " " + car.model
            + "</div>"
            + "<div class=\"col-6 text-right\">"
            + car.creationElapsedTime
            + "</div>"
            + "</div>" 
            + "</a>"
        if (index % 2 != 0 || (index == cars.length - 1 && cars.length %2 != 0)) {
            row_string = row_string + "</div>"
            container.append(row_string)
        }
    });   
}
