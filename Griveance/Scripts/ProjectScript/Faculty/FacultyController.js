angular.module('GR').controller('UsersController', UsersController);

function UsersController($scope, Service) {

    var form = $(".student-admission-wrapper");
    $scope.ViewGetFacultyInfoes = {};

    $scope.Initialize = function () {

        Service.Get("api/Users/GetFacultyInfo").then(function (result) {

            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.ViewGetFacultyInfoes = result.data;
            $scope.Faculty = result.data.ResultData;
            console.log(result.data);

        })

    }

 
}
