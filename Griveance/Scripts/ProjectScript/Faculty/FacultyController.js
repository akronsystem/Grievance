angular.module('GR').controller('UsersController', UsersController);

function UsersController($scope, Service) {

    var form = $(".student-admission-wrapper");
    $scope.ViewGetFacultyInfoes = {};
    $scope.UserCredentialModel = {};


    $scope.Initialize = function () {
        $scope.UserCredentialModel.UserId = "";
        $scope.UserCredentialModel.Password = "";
        Service.Post("api/Users/GetFacultyInfo").then(function (result) {

            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.ViewGetFacultyInfoes = result.data;
            $scope.Faculty = result.data.ResultData;
            console.log(result.data);

        })

    }

    $scope.GetData = function () {

        $scope.UserCredentialModel.UserId = "";
        $scope.UserCredentialModel.Password = "";
        Service.Post("api/Common/GetMyGrievance", $scope.UserCredentialModel).then(function (result) {

            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.ViewGetStudentInfoes = result.data;
            $scope.Student = result.data.ResultData;
            console.log(result.data);

        })

    }

}
