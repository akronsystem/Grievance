angular.module('GR').controller('UsersController', UsersController);

function UsersController($scope, Service) {

    var form = $(".student-admission-wrapper");
    $scope.ViewGetSingleParentInfoes = {};
    $scope.UserCredentialModel = {};
    $scope.btnUpdate = false;
    $scope.IsVisible = false;

    $scope.Initialize = function () {
        $scope.UserCredentialModel.UserId = "";
        $scope.UserCredentialModel.Password = "";
       
        $scope.Students = {};

        Service.Post("api/Users/GetParentInfo").then(function (result) {

            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.ViewGetSingleParentInfoes = result.data;
            $scope.Parents = result.data.ResultData;
            console.log(result.data);

        })

    }
    $scope.GetData = function () {

        $scope.UserCredentialModel.UserId = "";
        $scope.UserCredentialModel.Password = "";
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

        Service.Post("api/Users/GetSingleParentInfo", JSON.stringify(data), $scope.UserCredentialModel).then(function (result) 

            {
         
          
           
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


    $scope.AddUpdate = function (NameOfTheParent, StudentCode, RelationWithStudent, ContactNumber, Gender, Email, UserId) {
        debugger;
        var data = {
          
            name: NameOfTheParent,
            code: StudentCode,
            relationship: RelationWithStudent,
            contact:ContactNumber,
            email: Email,
            gender: Gender,
            UserId:UserId
        };
        Service.Post("api/Register/UpdateParentInfo", JSON.stringify(data)).then(function (response) {

            if (response.data)

                window.alert('Student Data Updated Successfully!')

            $scope.Clear();
            $scope.IsVisible = false;
            $scope.Initialize();
        });
    }
    
}
