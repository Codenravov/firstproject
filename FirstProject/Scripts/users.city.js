$(document).ready(function () {
    var removedCities = false;
    $("#ddlCities").change(function () {
        if (!removedCities) {
            $(this).children().first().remove();
            removedCities = true;
        };
    });
});