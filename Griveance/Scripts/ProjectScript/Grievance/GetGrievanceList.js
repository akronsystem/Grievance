angular.module('GR').controller('MemberController', MemberController);

function MemberController($scope, Service) {

    var form = $(".m-form m-form--fit m-form--label");
    $scope.ViewGrievanceLists = {};
    $scope.UserCredentialModel = {};

    $scope.GetInfo = function () {

        Service.Post("api/Grievance/GriveanceTypeInfo").then(function (result) {
            debugger;
            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.tbl_grievance_list = result.data;
            $scope.Grievance = result.data.ResultData;
            console.log(result.data);

        })

    }
  


}