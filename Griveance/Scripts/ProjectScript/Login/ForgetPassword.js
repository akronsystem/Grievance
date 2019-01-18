angular.module('GR').controller('LoginController', LoginController);

function LoginController($scope, Service) {
    var form = $(".m-login__form m-form");
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
        Service.Post("api/Login/ForgetPassword",Info).then(function (result) {
            debugger;
            
        })
    }
    $scope.Close = function () {    
        $scope.ContactNumber = {};
        location.href = baseURL + "Home/Index";
    }
}
