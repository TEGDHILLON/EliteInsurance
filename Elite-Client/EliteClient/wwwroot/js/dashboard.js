var dashboard = {

    baseUrl: "http://elite-insurance-api.ca-central-1.elasticbeanstalk.com/api",
    //baseUrl: "https://localhost:44374/api",

    onLoad: function () {
        dashboard.getAll();
    },

    getAll: function () {
        $.ajax({
            type: "GET",
            url: dashboard.baseUrl + "/insurance",
            data: null,
            dataType: "json",
            success: function (data) {
                data.forEach(function (element) {
                    $("#insurance_dropdown").append('<option value="' + element.id + '">' +
                        element.id + "-" +
                        element.make + "-" +
                        element.model + "-" +
                        element.phone +
                        '</option>');
                });
            }
        });
    },

    getById: function () {
        var id = $("select#insurance_dropdown option").filter(":selected").val();
        $.ajax({
            type: "GET",
            url: dashboard.baseUrl + "/insurance/" + Number(id),
            data: null,
            dataType: "json",
            success: function (data) {
                dashboard.clearTextFields();
                $('#make').val(data["make"]);
                $('#model').val(data["model"]);
                $('#company').val(data["company"]);
                $('#phone').val(data["phone"]);
                $('#note').val(data["note"]);
                $('#amount').val(data["amount"]);
                $('#annualFee').val(data["annualFee"]);
            }
        });
    },

    update: function () {
        var amount = Number($('#amount').val());
        var annualFee = Number($('#annualFee').val());
        var phone = Number($('#phone').val());
        if (amount == null || amount == 0 || annualFee == null || annualFee == 0 || phone == null || phone == 0) {
            alert("Amount, annualFee, phone cannot be empty or zero");
        }
        else {
            var ins = {
                Id: Number($("select#insurance_dropdown option").filter(":selected").val()),
                Phone: $('#phone').val(),
                Note: $('#note').val(),
                Amount: amount,
                AnnualFee: annualFee
            };

            var data = JSON.stringify(ins);

            $.ajax({
                type: "PUT",
                url: dashboard.baseUrl + "/insurance",
                data: data,
                contentType: "application/json",
                success: function () {
                    alert("Update successfully.");
                    document.location.reload();
                }
            });
        }
    },

    delete: function () {

        var id = $("select#insurance_dropdown option").filter(":selected").val();

        $.ajax({
            type: "DELETE",
            url: dashboard.baseUrl + "/insurance/" + Number(id),
            data: null,
            contentType: "application/json",
            success: function (data) {
                if (data) {
                    alert("Delete successfully.");
                    document.location.reload();
                }
                else {
                    alert("Error in deleting");
                }
            }
        });
    },

    clearTextFields: function () {
        $('#make').val("");
        $('#model').val("");
        $('#company').val("");
        $('#phone').val("");
        $('#note').val("");
        $('#amount').val("");
        $('#annualFee').val("");
    }
};

$(document).ready(function () {
    dashboard.onLoad();
    $("#btn_update").click(function () {
        dashboard.update();
    });
    $("#btn_delete").click(function () {
        dashboard.delete();
    });
});