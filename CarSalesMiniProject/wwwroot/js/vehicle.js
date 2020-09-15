$(document).ready(function () {
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
});