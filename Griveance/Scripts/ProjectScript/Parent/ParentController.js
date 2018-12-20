angular.module('GR').controller('UsersController', UsersController);

function UsersController($scope, Service) {

    var form = $(".student-admission-wrapper");
    $scope.ViewGetSingleParentInfoes = {};

    $scope.Initialize = function () {

        Service.Get("api/Users/GetParentInfo").then(function (result) {

            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.ViewGetSingleParentInfoes = result.data;
            $scope.Parents = result.data.ResultData;
            console.log(result.data);

        })

    }

    
}
