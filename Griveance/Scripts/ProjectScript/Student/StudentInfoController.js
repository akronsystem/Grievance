angular.module('GR').controller('UsersController', UsersController);

function UsersController($scope, Service) {

    var form = $(".student-admission-wrapper");
    $scope.ViewGetStudentInfoes = {};
    $scope.UserCredentialModel = {};

    $scope.btnUpdate = false;
    $scope.IsVisible = false;
    $scope.Students = {};



    $scope.Initialize = function () {

        $scope.UserCredentialModel.UserId = "";
        $scope.UserCredentialModel.Password = "";
        Service.Post("api/Users/GetStudentInfo", $scope.UserCredentialModel).then(function (result) {

           
            $scope.ViewGetStudentInfoes = result.data;
            $scope.Students = result.data.ResultData;
            console.log(result.data);

        })

    }

    $scope.ShowHide = function (studentcode) {

        var data = {
            StudentCode: studentcode

        };
       
        Service.Post("api/Users/GetSingleStudentInfo", JSON.stringify(data), $scope.UserCredentialModel).then(function (result)
        {
       
               
            debugger;
            $scope.IsVisible = true;
            $scope.btnUpdate = true;
            $scope.Initialize();
                $scope.ViewGetStudentInfoes = result.data;

                $scope.StudentName = result.data.name;
                $scope.StudentCode = result.data.code;
                $scope.Type = result.data.type;
                $scope.Gender = result.data.gender;
                $scope.email = result.data.email;
                $scope.Contact = result.data.contact;
                $scope.Students = result.data.ResultData;
             
                
            })
    }
    $scope.Clear = function ()
    {
       
        $scope.StudentName = null;
        $scope.StudentCode = null;
        $scope.Type = null;
        $scope.Gender = null;
        $scope.email = null;
        $scope.Contact = null;
        $scope.IsVisible = false;
        $scope.Initialize();
    }


    $scope.AddUpdate = function (StudentName, StudentCode, Type, Gender, email, Contact) {
        var data = {
            name: StudentName,
            code: StudentCode,
            type: Type,
            gender: Gender,
            email: email,
            contact: Contact
        };
        Service.Post("api/Register/UpdateStudents", JSON.stringify(data)).then(function (response) {

            if (response.data)
                $scope.Initialize();
            window.alert('Student Data Updated Successfully!')
          
            $scope.Clear();
            $scope.IsVisible = false;
        });
    }
}



   
    

  
