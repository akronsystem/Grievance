angular.module('GR').controller('GrievanceController', GrievanceController);

function GrievanceController($scope, Service) {

    var form = $(".student-admission-wrapper");
    $scope.ViewGrievanceLists = {};

    $scope.Initialize = function () {

        Service.Get("api/Grievance/GetAllGrievanceList").then(function (result) {

            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.ViewGrievanceLists = result.data;
            $scope.GrievanceList = result.data.ResultData;
            console.log(result.data);

        })

    }

  
}
