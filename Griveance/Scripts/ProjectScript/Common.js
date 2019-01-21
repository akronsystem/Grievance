angular.module('GR').controller('UsersController', UsersController);

function UsersController($scope, Service) {

    var form = $(".m-form m-form--fit m-form--label");
    var form1 = $("#frmCRUD");
    
    $scope.ViewAllStaffInfoes = {};
    $scope.UserCredentialModel = {};
    $scope.UserName = sessionStorage.getItem('Email');

    $scope.GetInfo = function () {
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

        if (form1.valid()) {
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
    $scope.Initialize = function () {
        debugger;
        var data = sessionStorage.getItem('userid');
        var Password = sessionStorage.getItem('Password');
        var code = sessionStorage.getItem('emp-key');
        var email = sessionStorage.getItem('Email');
        var type = sessionStorage.getItem('Type');
        var name = sessionStorage.getItem('Name');
        var contact = sessionStorage.getItem('Contact');
        $scope.UserId = data
        $scope.email = email.replace(/"/g, '');
        $scope.name = name.replace(/"/g, '');
        $scope.contact = contact;
       
    }
    $scope.Setting = function () {
        debugger;
        var Data = {
            name:$scope.name,
            email:$scope.email,
            contact:$scope.contact,
            UserId: $scope.UserId,
            contact: $scope.newcontact,
            newpassword: $scope.newpassword,
            OldPassword: $scope.oldpassword,
            Password:$scope.conpassword

        };
        if ($scope.newcontact == undefined)
        {
            Data.contact = $scope.contact;
        }
        if ($scope.newpassword == $scope.conpassword)
        {
           
        }
        else {
            window.alert('Please Check Confirm Password')
            return false;
        }
        if (form1.valid()) {


            Service.Post("api/Common/UpdateUsers", JSON.stringify(Data)).then(function (result) {
                debugger;
                // $scope.ParamUserLogin.Name = result.data.Name 
                console.log(result.data);
                if (result.data.IsSucess) {
                    debugger;
                    console.log(result.data);
                    window.alert('Updated User')
                    //window.location = "./Index"
                }
                else {
                    ShowMessage(0, result.data.Message);
                    //window.location = "./Index"
                }
            })
        }
    }
    $scope.GetData = function () {
        debugger;
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

        })

    }
 

    $scope.clear = function () {
        $scope.GriveanceType = 0;
        $scope.Subject = '';
        $scope.PostDetails = '';
    } 
}

