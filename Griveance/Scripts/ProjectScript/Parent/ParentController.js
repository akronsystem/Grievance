angular.module('GR').controller('UsersController', UsersController);

function UsersController($scope, Service, DTOptionsBuilder) {

    var form = $(".student-admission-wrapper");
    $scope.ViewGetSingleParentInfoes = {};
    $scope.UserCredentialModel = {};
    $scope.btnUpdate = false;
    $scope.IsVisible = false;
    $scope.btnactive = 'Active'

    $scope.Initialize = function () {
        $scope.dtOptions = DTOptionsBuilder.newOptions()
            .withPaginationType('full_numbers').withDisplayLength(10)

        $scope.UserCredentialModel.UserId = "";
        $scope.UserCredentialModel.Password = "";
        $scope.UserCredentialModel.DisplayStatus = $scope.btnactive;
        $scope.Students = {};
        debugger;
       

       Service.Post("api/Users/GetParentInfo", $scope.UserCredentialModel).then(function (result) {
           
            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.ViewGetSingleParentInfoes = result.data;
            $scope.Parents = result.data.ResultData;
            console.log(result.data);

        })

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



    $scope.ShowHide = function (UserId) {

        debugger;
        $scope.btnUpdate = true;
        $scope.IsVisible = true;
        var data = {


            UserId: UserId

        };

        Service.Post("api/Users/GetSingleParentInfo", JSON.stringify(data), $scope.UserCredentialModel).then(function (result) {



            $scope.ViewGetStudentInfoes = result.data;
            $scope.NameOfTheParent = result.data.name;
            $scope.StudentCode = result.data.code;
            $scope.RelationWithStudent = result.data.relationship;
            $scope.ContactNumber = result.data.contact;
            $scope.Email = result.data.email;
            $scope.Gender = result.data.gender;
            $scope.UserId = result.data.UserId;

            $scope.Initialize();
        })

    }
    $scope.Clear = function () {
        debugger;
        $scope.ViewGetStudentInfoes = null;
        $scope.NameOfTheParent = null;
        $scope.StudentCode = null;
        $scope.RelationWithStudent = null;
        $scope.ContactNumber = null;
        $scope.Email = null;
        $scope.Gender = null;
        $scope.UserId = null;
        $scope.btnUpdate = false;
        $scope.IsVisible = false;
    }
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

    $scope.AddUpdate = function (NameOfTheParent, StudentCode, RelationWithStudent, ContactNumber, Gender, Email, UserId) {
        debugger;
        var data = {

            name: NameOfTheParent,
            code: StudentCode,
            relationship: RelationWithStudent,
            contact: ContactNumber,
            email: Email,
            gender: Gender,
            UserId: UserId
        };
        if ($scope.form.$valid) {
            Service.Post("api/Register/UpdateParentInfo", JSON.stringify(data)).then(function (response) {

                if (response.data)

                    window.alert('Student Data Updated Successfully!')

                $scope.Clear();
                $scope.IsVisible = false;
                $scope.Initialize();
            });
        }

    }

    $scope.Delete = function (UserId, Type) {
        debugger;
        var data = {

            UserId: UserId,
            type: Type
        };
        var deactivestatus = 1;
        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive this Entry ?");
            var deactivestatus = 0;
        }
        else
        {
            var confirm = window.confirm("Do you want to active this Entry ?");
           
        }
        if (confirm == true) {
            Service.Post("api/Register/DeleteParentInfo", JSON.stringify(data)).then(function (response) {
                debugger;

               
                if (deactivestatus == 0) 
                    {
                        window.alert('Entry Deactive Successfully!')
                        
                    }
                    else
                    {
                        window.alert('Entry Active Successfully!')
                        
                    }
                   

                debugger;
                $scope.Clear();
                $scope.IsVisible = false;
                $scope.Initialize();

            });
        }
    
        $scope.Initialize();

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

            Service.Post("api/Grievance/PostGrievance", JSON.stringify(PostGr)).then(function (result) {
                 
                // $scope.ParamUserLogin.Name = result.data.Name

                console.log(result.data);
                if (result.data.IsSucess) {
                    debugger;
                    CustomizeApp.AddMessage();
                    //console.log(result.data);
                   // window.location = "./ParentGrievance"
                }
                else {
                    ShowMessage(0, 'Record Not Inserted.'); 
                    //window.location = "./PostGrievance"
                }

            })
    }



   
}
UsersController.$inject = ['$scope', 'Service'];
UsersController.$inject = ['$scope', 'Service','DTOptionsBuilder'];

