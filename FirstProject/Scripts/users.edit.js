$(document).ready(function () {
    $("#ddlCountries").change(function () {
        var SelectCountry = $('#ddlCountries').val();
        $.ajax({
            url: "http://localhost/MVCWebProject/Users/Edit/",
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