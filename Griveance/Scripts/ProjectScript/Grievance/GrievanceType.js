angular.module('GR').controller('GrievanceController', GrievanceController);

function GrievanceController($scope, Service) {

    var form = $(".student-admission-wrapper");
    $scope.tbl_grievance_list = {};

    $scope.Initialize = function () {

        Service.Get("api/Grievance/GriveanceTypeInfo").then(function (result) {

            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.tbl_grievance_list = result.data;
            $scope.GrievanceType = result.data.ResultData;
            console.log(result.data);

        })

    }

    
}
