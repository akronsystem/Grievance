angular.module('GR').controller('LoginController', LoginController);

function LoginController($scope, Service) {
    var form = $(".m-login__form m-form");
    var form1 = $("#frmCRUD");
    $scope.UserCredentialModel = {};
    $scope.Verify = function () {
        var Info = {
            ContactNumber: $scope.ContactNumber
        }
        if ($scope.ContactNumber == undefined)
        {
            $("#error").text("Contact Number Required");
            $("#error").css({ 'color': 'red' });
            return false;
        }
       
        Service.Post("api/Login/ForgetPassword", Info).then(function (result) {
            debugger;
                if (result.data.IsSucess) {
                   
                    ShowMessage(1, "Email Send successfully");

                }
                else
                {
                    ShowMessage(0, result.data.Message);

                }


            })
        
    }
    $scope.Close = function () {    
        $scope.ContactNumber = {};
        location.href = baseURL + "Home/Index";
    }
}
