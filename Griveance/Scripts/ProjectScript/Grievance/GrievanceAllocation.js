angular.module('GR').controller('GrievanceController', GrievanceController);

function GrievanceController($scope, Service) {

    var form = $(".student-admission-wrapper");
    $scope.ViewGrievanceList = {};

    $scope.Initialize = function () {

        Service.Get("api/Grievance/GrievanceAllocation").then(function (result) {

            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.ViewGrievanceList = result.data;
            $scope.GrievanceAllocation = result.data.ResultData;
            console.log(result.data);

        })

    }

  
}
