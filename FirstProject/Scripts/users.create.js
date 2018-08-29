$(document).ready(function () {
    var removedTitles = false;
    var removedCountries = false;
    $("#ddlTitles").change(function () {
        if (!removedTitles) {
            $(this).children().first().remove();
            removedTitles = true;
        }
    });
    $("#ddlCountries").change(function () {
        var SelectCountry = $('#ddlCountries').val();
        if (!removedCountries) {
            $(this).children().first().remove();
            removedCountries = true;
        }
        $.ajax({
            url: "http://localhost/MVCWebProject/Users/Create/",
            datatype: "json",
            data: { "selectCountry": SelectCountry },
            type: "POST",
            contenttype: 'application/json; charset=utf-8',
            success: function (partionalView) {
                $("#divCities").html(partionalView);
                $('@Html.ValidationMessageFor(model => model.City, "")').insertAfter('#divValidation');
                $('form').removeData("validator");
                $("form").removeData("unobtrusiveValidation");
                $.validator.unobtrusive.parse(document);
            },
            error: function (xhr) {
                alert('error');
            }
        });
    });
});
