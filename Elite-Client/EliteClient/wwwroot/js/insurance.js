var insurance = {
    companies: [],
    baseUrl: "http://elite-insurance-api.ca-central-1.elasticbeanstalk.com/api",
    //baseUrl: "https://localhost:44374/api",

    onLoad: function () {
        insurance.getAllRegions();
        insurance.getAllMakes();
    },

    getAllRegions: function () {
        $.ajax({
            type: "GET",
            url: insurance.baseUrl + "/base/regions",
            data: null,
            dataType: "json",
            success: function (data) {
                data.forEach(function (element) {
                    $("#region_dropdown").append('<option value="' + element.id + '">' + element.name + '</option>');
                });
            }
        });
    },

    getAllCompanies: function () {
        var regionId = $("select#region_dropdown option").filter(":selected").val();
        $.ajax({
            type: "GET",
            url: insurance.baseUrl + "/base/companies/" + regionId,
            data: null,
            dataType: "json",
            success: function (data) {
                insurance.companies = data;
                $('#company_dropdown').empty();
                var newOption = $('<option value="0">Select Company</option>');
                $('#company_dropdown').append(newOption);
                $('#company_dropdown').trigger("chosen:updated");
                $('#company_dropdown').val("");
                data.forEach(function (element) {
                    $("#company_dropdown").append('<option value="' + element.id + '">' + element.name + '</option>');
                });
            }
        });
    },

    getAllMakes: function () {
        $.ajax({
            type: "GET",
            url: insurance.baseUrl + "/base/makes",
            data: null,
            dataType: "json",
            success: function (data) {
                $('#make_dropdown').empty();
                var newOption = $('<option value="0">Select Make</option>');
                $('#make_dropdown').append(newOption);
                $('#make_dropdown').trigger("chosen:updated");
                $('#make_dropdown').val("");
                data.forEach(function (element) {
                    $("#make_dropdown").append('<option value="' + element.id + '">' + element.name + '</option>');
                });
            }
        });
    },

    getAllModels: function () {
        var makeId = $("select#make_dropdown option").filter(":selected").val();
        $.ajax({
            type: "GET",
            url: insurance.baseUrl + "/base/models/" + makeId,
            data: null,
            dataType: "json",
            success: function (data) {
                $('#model_dropdown').empty();
                var newOption = $('<option value="0">Select Model</option>');
                $('#model_dropdown').append(newOption);
                $('#model_dropdown').trigger("chosen:updated");
                $('#model_dropdown').val("");
                data.forEach(function (element) {
                    $("#model_dropdown").append('<option value="' + element.id + '">' + element.name + '</option>');
                });
            }
        });
    },

    create: function () {
        var comapanyId = Number($("select#company_dropdown option").filter(":selected").val())
        var amount = Number($('#amount').val());
        var modelId = Number($("select#model_dropdown option").filter(":selected").val());
        if (amount == null || amount == 0) {
            alert("Amount is required");
        }
        else if (comapanyId == null || modelId == null){
            alert("Select company and model");
        }
        else {
            var rate = insurance.companies.filter(c => c.id == comapanyId)[0].rate;
            var anualFee = Math.round(Number(amount * rate));
            $('#annualFee').val(anualFee);
            var ins = {
                AccountId: Number(localStorage.getItem('userId')),
                CompanyId: comapanyId,
                Year: Number($('#year').val()),
                ModelId: modelId,
                Phone: $('#phone').val(),
                Amount: amount,
                Note: $('#note').val(),
                AnnualFee: anualFee
            };

            var data = JSON.stringify(ins);

            $.ajax({
                type: "POST",
                url: insurance.baseUrl + "/insurance",
                data: data,
                contentType: "application/json",
                success: function (data) {
                    if (data) {
                        alert("Create successfully.Your insurance annual fee is : " + anualFee);
                        //document.location.reload();
                    }
                    else {
                        alert("Error in while creating insurance");
                    }
                },
                error: function () {
                    alert("Error in while creating");
                }
            });
        }
    },
};

$(document).ready(function () {
    insurance.onLoad();
    $("#btn_create").click(function () {
        insurance.create();
    });
});