angular.module('GR').controller('MemberController', MemberController);

function MemberController($scope, Service) {

    var form = $(".m-form m-form--fit m-form--label");
    $scope.Add = function () {
        debugger;
        var Member = {
            EmailId: $scope.EmailId,
            Name: $scope.Name,
            Code: $scope.Code,
            Type: $scope.Type,
            GriType: $scope.GriType,
            Gender: $scope.Gender,
            MobileNo: $scope.MobileNo,
            Password: $scope.Password,
            Designation: $scope.Designation
           

        };

        Service.Post("api/Member/MemberSave", JSON.stringify(Member)).then(function (result) {
            debugger;
            // $scope.ParamUserLogin.Name = result.data.Name

            console.log(result.data);

        })


    }
    $scope.GetData = function () {

        Service.Post("api/Grievance/GriveanceTypeInfo").then(function (result) {
            debugger;
            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.tbl_grievance_list = result.data;
            $scope.Grievance = result.data.ResultData;
            console.log(result.data);

        })

    }
    $scope.Cancel = function () {
        Member={};
    }


}