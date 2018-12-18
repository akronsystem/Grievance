angular.module('GR').controller('LoginController', LoginController);

function LoginController($scope, Service) {
    var form = $(".login100-form");
    $scope.UserCredentialModel = {};
    
    $scope.Initialize = function () {
        
        Service.Get("api/Login/GetUser").then(function (result) { 
           
            $scope.UserCredentialModel.UserName = result.data.UserName
            $scope.UserCredentialModel.type = result.data.type
           
        })
    }

    $scope.SetRememberme = function () {
        $("#hdRememberme").val() === "True" ? $scope.UserCredentialModel.Rememberme = true : $scope.UserCredentialModel.Rememberme = false;        
        $scope.UserCredentialModel.Email = $("#hdEmail").val();
        $scope.UserCredentialModel.RandomSeed = $("#hdRandomSeed").val();
    };

    $scope.ValidateUser = function () {
         
        /*if (form.valid())*/ {

            //if ($scope.UserCredentialModel.Password !== "" && $scope.UserCredentialModel.Password !== null) {
            //    var hash = md5($scope.UserCredentialModel.RandomSeed + md5($scope.UserCredentialModel.Password).toUpperCase());
            //    $scope.UserCredentialModel.Password = hash.toUpperCase();
            //}

            Service.Post("api/Login/ValidateUserLogin", $scope.UserCredentialModel).then(function (rd) {
               
                if (rd.data.IsSucess)
                { 
                    console.log(rd.data.ResultData);
                    if (rd.data.ResultData.type == "Admin")
                    {
                         location.href = baseURL +"Admin/Dashboard/Index"
                    }
                    else if (rd.data.ResultData.type == "Student") 
                    {
                        location.href = baseURL + "Student/Student/Index"
                    }
                    else if (rd.data.ResultData.type == "Parent")
                    {
                        location.href = baseURL + "Parent/Parent/Index"
                    }
                    else if (rd.data.ResultData.type == "Member")
                    {
                        location.href = baseURL + "Member/Member/Index"
                    }
                    else if (rd.data.ResultData.type == "Faculty")
                    {
                        location.href = baseURL + "Faculty/Faculty/Index"

                    }
                    else if (rd.data.ResultData.type == "Staff")
                    {
                        location.href = baseURL + "Staff/Staff/Index"

                    }
                    else {
                        alert('Check your Username');
                    }

                }
                else { 
                    alert(rd.data.Message);
                }
            });
        }
    };

    $scope.ValidateAndSendMail = function () {        
        Service.Post("Login/ValidateAndSendMail", { email: $("#forgorPasswordEmail").val() }).then(function (rd) {
            if (rd.data.result) {
                $("#forgorPasswordEmail").val('');
                alert("Reset password link sent your email, please reset your password using this link");               
            } else {
                var error = "";
                angular.forEach(rd.data.ErrorList, function (value, key) {
                    error = error + "<span>" + value + "</span><br>";
                });
                alert(error);            
            }
        });
    };
}