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
    $scope.SavePost = function () {
        var data = sessionStorage.getItem('userid');
        var Password = sessionStorage.getItem('Password');
        var code = sessionStorage.getItem('emp-key');
        var email = sessionStorage.getItem('Email');
        var type = sessionStorage.getItem('Type');
        PostGr = {
            GriveanceType: $scope.GriveanceType,
            Subject: $scope.Subject,
            PostDetails: $scope.PostDetails,
            UserId:data,
            Password: Password,
            Code:code,
            Email: email,
            Type:type
        };
        Service.Post("api/Grievance/PostGrievance", JSON.stringify(PostGr)).then(function (result) {
            debugger;
            // $scope.ParamUserLogin.Name = result.data.Name

            console.log(result.data);

        })
    }

}