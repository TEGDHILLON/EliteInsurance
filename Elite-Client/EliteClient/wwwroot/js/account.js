

var account = {

    baseUrl: "http://elite-insurance-api.ca-central-1.elasticbeanstalk.com/api",
    //baseUrl: "https://localhost:44374/api",

    login: function () {
        var phone = $('#login_phone').val();
        var password = $('#login_password').val();
        if (phone == null || phone == '' || password == null || password == '') {
        alert("Phone and Password is required");
        }
        else {
            var user = {
                Phone: phone,
                Password: password
            };
            var data = JSON.stringify(user);
            $.ajax({
                type: "POST",
                url: account.baseUrl + "/account/login",
                data: data,
                contentType: "application/json",
                success: function (data) {
                    if (data != null) {
                        localStorage.setItem('userId', data.toString());
                        window.location.replace("/Home/Home");
                    }
                    else {
                        alert("Invalid phone or password");
                    }
                    console.log("data", data);
                },
                error: function () {
                    alert("Login failure");
                }
            });
        }   
    },

    register: function () {
        var name = $('#reg_name').val();
        var email = $('#reg_email').val();
        var phone = $('#reg_phone').val();
        var password = $('#reg_password').val();
        var password2 = $('#reg_password2').val();
        if (phone == null || phone == '') {
            alert("Phone is required");
        }
        else if (password == null || password == '' || password2 == null || password2 == '') {
            alert("Password is required");
        }
        else if (password != password2) {
            alert("Password and confirm pasword doesn't match");
        }
        else {
            var user = {
                Name: name,
                Email: email,
                Phone: phone,
                Password: password
            };

            var data = JSON.stringify(user);
            $.ajax({
                type: "POST",
                url: account.baseUrl + "/account/register",
                data: data,
                contentType: "application/json",
                success: function (data) {
                    if (data != null) {
                        localStorage.setItem('userId', data.toString());
                        window.location.replace("/Home/Home");
                    }
                    else {
                        alert("Error while registering");
                    }
                },
                error: function () {
                    alert("Register failure");
                }
            });
        }
    }
};

$(document).ready(function () {
    $("#btn_login").click(function () {
        account.login();
    });
    $("#btn_register").click(function () {
        account.register();
    });
});