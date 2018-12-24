angular.module('GR').controller('GrievanceController', GrievanceController);

function GrievanceController($scope, Service) {

    var form = $(".student-admission-wrapper");
    $scope.tbl_grievance_list = {};
    $scope.UserCredentialModel = {};
    $scope.IsVisible = false;
    $scope.btnSave = false;


    $scope.Initialize = function () {
        $scope.UserCredentialModel.UserId = "";
        $scope.UserCredentialModel.Password = "";
        Service.Post("api/Grievance/GriveanceTypeInfo").then(function (result) {

            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.tbl_grievance_list = result.data;
            $scope.GrievanceType = result.data.ResultData;
            console.log(result.data);

        })

    }
    $scope.ShowHide = function () {
        //If DIV is visible it will be hidden and vice versa.
        $scope.IsVisible = true;
        $scope.btnSave = true;
    }
    $scope.Save = function () {

    }

    
}
