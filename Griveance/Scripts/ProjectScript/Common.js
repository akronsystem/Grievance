angular.module('GR').controller('UsersController', UsersController);

function UsersController($scope, Service) {

    var form = $(".m-form m-form--fit m-form--label");


    $scope.ViewAllStaffInfoes = {};
    $scope.UserCredentialModel = {};

    $scope.GetInfo = function () {
        $scope.dtOptions = "";
        Service.Post("api/Grievance/GriveanceTypeInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.tbl_grievance_list = result.data;
            $scope.Grievance = result.data.ResultData;
            console.log(result.data);

        })

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
            UserId: data,
            Password: Password,
            Code: code,
            Email: email,
            Type: type
        };

        if ($scope.form.$valid) {
            Service.Post("api/Grievance/PostGrievance", JSON.stringify(PostGr)).then(function (result) {
                debugger;
                // $scope.ParamUserLogin.Name = result.data.Name 
                console.log(result.data); 
                if (result.data.IsSucess) {
                    debugger;
                    CustomizeApp.AddMessage();
                    $scope.clear();
                    //console.log(result.data);
                    // window.location = "./ParentGrievance"
                }
                else {
                    ShowMessage(0, result.data.Message);
                    //$scope.clear();
                    //window.location = "./PostGrievance"
                }
            })
        }
    }

    $scope.clear = function () {
        $scope.GriveanceType = 0;
        $scope.Subject = '';
        $scope.PostDetails = '';
    }
}
