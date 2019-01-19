angular.module('GR').controller('GrievanceController', GrievanceController);

function GrievanceController($scope, Service, DTOptionsBuilder) {

    var form = $(".m-form m-form--fit m-form--label-align-right");
    $scope.ViewGrievanceList = {};
    $scope.UserCredentialModel = {};
    $scope.dtOptions = {};

    $scope.Initialize = function () {
        if (!$scope.dtOptions)

        $scope.dtOptions = DTOptionsBuilder.newOptions()
            .withPaginationType('full_numbers').withDisplayLength(10)
        $scope.UserCredentialModel.UserId = "";
        $scope.UserCredentialModel.Password = "";
        Service.Post("api/Grievance/GrievanceAllocation").then(function (result) {

            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.ViewGrievanceList = result.data;
            $scope.GrievanceAllocation = result.data.ResultData;
            console.log(result.data);

        })

    }

    $scope.GetData = function () {

        var data = sessionStorage.getItem('emp-key');
        $scope.UserCredentialModel.StudentCode = data;
        var userid = sessionStorage.getItem('userid');
        $scope.UserCredentialModel.UserId = userid;
        var password = sessionStorage.getItem('Password');
        $scope.UserCredentialModel.Password = password;
        Service.Post("api/Common/GetMyGrievance", $scope.UserCredentialModel).then(function (result) {

            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.ViewGetStudentInfoes = result.data;
            $scope.Student = result.data.ResultData;
            console.log(result.data);
            if (result.data.IsSucess) {
                debugger;
                console.log(result.data);

            }
            else {
                alert(result.data.Message);

            }

        })

    }

    $scope.GetInfo = function () {

        Service.Post("api/Grievance/GriveanceTypeInfo").then(function (result) {
            debugger;
            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.tbl_grievance_list = result.data;
            $scope.Grievance = result.data.ResultData;
            console.log(result.data);

        })

    }

    $scope.ShowHide = function (UserId) {

     
        $scope.btnUpdate = true;
        $scope.IsVisible = true;
        var data = {
            UserId: UserId
        };

        Service.Post("api/Grievance/GetSingleGrievance", JSON.stringify(data), $scope.UserCredentialModel).then(function (result) {

            debugger;

            $scope.ViewGetStudentInfoes = result.data;
            $scope.name = result.data.name;
            $scope.code = result.data.code;
            $scope.designation = result.data.designation;
            $scope.griType = result.data.griType;
            $scope.email = result.data.email;
            $scope.contact = result.data.contact;
            $scope.UserId = result.data.UserId;
            $scope.id = result.data.id;

            $scope.Initialize();
        })

    }

    $scope.Clear = function () {
        debugger;
        $scope.ViewGetStudentInfoes = null;
        $scope.name = null;
        $scope.code = null;
        $scope.designation = null;
        $scope.griType = null;
        $scope.email = null;
        $scope.contact = null;
        $scope.UserId = null;
        $scope.id = null;
        $scope.btnUpdate = false;
        $scope.IsVisible = false;
        $scope.Initialize();
    }


    $scope.AddUpdate = function (name, code, designation, griType, email, contact, UserId, Expr1) {
        debugger;
        var data = {

            name: name,
            code: code,
            designation: designation,
            griType: griType,
            email: email,
            contact: contact,
            UserId: UserId,
            Expr1: Expr1
        };
        if (griType == undefined)
        {
            ShowMessage(0, response.data.Message);
        }
        Service.Post("api/Grievance/UpdateGrievanceAllocation", JSON.stringify(data)).then(function (response) {


            if (response.data.IsSucess) {
                debugger;
                CustomizeApp.UpdateMessage();
               
            }
            else {
                ShowMessage(0, response.data.Message);
                //$scope.clear();
                //window.location = "./PostGrievance"
            }
         
        });
    }
}
