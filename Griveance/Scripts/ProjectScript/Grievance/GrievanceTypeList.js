angular.module('GR').controller('GrievanceController', GrievanceController);

function GrievanceController($scope, Service) {

    var form = $(".student-admission-wrapper");
    $scope.ViewGrievanceLists = {};
    $scope.UserCredentialModel = {};
    
    $scope.Initialize = function () {
        debugger;
        $scope.UserCredentialModel.UserId = "";
        $scope.UserCredentialModel.Password = "";
       // Service.Post("api/Grievance/GetAllGrievanceList").then(function (result) {
        Service.Post("api/Grievance/GetAllPostGrevience").then(function (result) {
            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.ViewGetAllPostGrievanceList = result.data;
            $scope.GrievanceList = result.data.ResultData;
            console.log(result.data);

        })

    }

  
}
