var app = angular.module('GR' ).controller('UsersController', UsersController);

function UsersController($scope, Service, DTOptionsBuilder) {

    var form = $(".student-admission-wrapper");
    $scope.ViewGetStudentInfoes = {};
    $scope.UserCredentialModel = {};

    $scope.btnUpdate = false;
    $scope.IsVisible = false;
    $scope.Students = [];



    $scope.Initialize = function () { 
        debugger;
 
        $scope.dtOptions = DTOptionsBuilder.newOptions()
            .withPaginationType('full_numbers').withDisplayLength(10)
 
        $scope.UserCredentialModel.UserId = "";
        $scope.UserCredentialModel.Password = "";
        Service.Post("api/Users/GetStudentInfo", $scope.UserCredentialModel).then(function (result) {

           
            $scope.ViewGetStudentInfoes = result.data;
            $scope.Students = result.data.ResultData;
            //console.log(result.data);

        })

    }

    $scope.ShowHide = function (UserId) {

        var data = {
           
            UserId: UserId

        };
       
        Service.Post("api/Users/GetSingleStudentInfo", JSON.stringify(data), $scope.UserCredentialModel).then(function (result)
        {
       
               
            debugger;
            $scope.IsVisible = true;
            $scope.btnUpdate = true;
           
                $scope.ViewGetStudentInfoes = result.data;

                $scope.StudentName = result.data.name;
                $scope.StudentCode = result.data.code;
                $scope.Type = result.data.type;
                $scope.Gender = result.data.gender;
                $scope.email = result.data.email;
                $scope.Contact = result.data.contact;
               
                $scope.UserId = result.data.UserId;
               // $scope.Students = result.data.ResultData;
             
                $scope.Initialize();
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

    $scope.AddUpdate = function (StudentName, StudentCode, Type, Gender, email, Contact, UserId) {
        var data = {
            name: StudentName,
            code: StudentCode,
            type: Type,
            gender: Gender,
            email: email,
            contact: Contact,
            UserId: UserId
        };
        Service.Post("api/Register/UpdateStudents", JSON.stringify(data)).then(function (response) {

            if (response.data)
             
            window.alert('Student Data Updated Successfully!')
          
            $scope.Clear();
            $scope.IsVisible = false;
            $scope.Initialize();
        });
    }

   
}
UsersController.$inject = ['$scope', 'Service'];
UsersController.$inject = ['$scope', 'Service','DTOptionsBuilder'];



   
    

  
