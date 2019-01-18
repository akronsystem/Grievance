var app = angular.module('GR' ).controller('UsersController', UsersController);

function UsersController($scope, Service, DTOptionsBuilder) {

    var form = $(".student-admission-wrapper");
    $scope.ViewGetStudentInfoes = {};
    $scope.UserCredentialModel = {};

    $scope.btnUpdate = false;
    $scope.IsVisible = false;
    $scope.btnDelete = false;
    $scope.Students = [];
   


    $scope.Initialize = function () { 
        debugger;

        
        $scope.dtOptions = DTOptionsBuilder.newOptions()
            .withPaginationType('full_numbers').withDisplayLength(10)
 
        $scope.UserCredentialModel.UserId = "";
        $scope.UserCredentialModel.Password = "";
        $scope.UserCredentialModel.DisplayStatus = $scope.btnactive;
        Service.Post("api/Users/GetStudentInfo", $scope.UserCredentialModel).then(function (result) {

           
            $scope.ViewGetStudentInfoes = result.data;
            $scope.Students = result.data.ResultData;
            //console.log(result.data);

        })

    }

    $scope.ShowHide = function (UserId) {
        debugger;
        var data = {
           
            UserId: UserId

        };
       
        Service.Post("api/Users/GetSingleStudentInfo", JSON.stringify(data), $scope.UserCredentialModel).then(function (result)
        {
          
            debugger;
         
            

           
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
        if ($scope.form.$valid) {
            Service.Post("api/Register/UpdateStudents", JSON.stringify(data)).then(function (response) {

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

        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to deactive the student ?");
            
        }
        else {
            var confirm =   window.confirm("Do you want to active the student ?");
        }
        if (confirm == true) {
            Service.Post("api/Register/DeleteStudents", JSON.stringify(data)).then(function (response) {


                if (response.data)

                    window.alert('Student Deactive Successfully!')

               

            });
        }
        $scope.Clear();
        $scope.IsVisible = false;
        $scope.Initialize();
        
        
    }
        
        
    
}
UsersController.$inject = ['$scope', 'Service'];
UsersController.$inject = ['$scope', 'Service','DTOptionsBuilder'];



   
    

  
