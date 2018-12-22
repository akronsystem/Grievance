angular.module('GR').controller('UsersController', UsersController);

function UsersController($scope, Service) {

    var form = $(".student-admission-wrapper");
    $scope.ViewGetStudentInfoes = {};
    $scope.UserCredentialModel = {};


    $scope.IsVisible = false;
    $scope.Students = {};



    $scope.Initialize = function () {

        $scope.UserCredentialModel.UserId = "";
        $scope.UserCredentialModel.Password = "";
        Service.Post("api/Users/GetStudentInfo", $scope.UserCredentialModel).then(function (result) {

            // $scope.ParamUserLogin.Name = result.data.Name
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
        //    if (result.data)
        //        $scope.msg = "Data Fetch Successfully!";
        //},
            //function (result) {
                window.alert('hi');
                debugger;
                $scope.IsVisible = $scope.IsVisible ? false : true;
                $scope.ViewGetStudentInfoes = result.data;

                $scope.StudentName = result.data.name;
                $scope.StudentCode = result.data.code;
                $scope.Type = result.data.type;
                $scope.Gender = result.data.gender;
                $scope.email = result.data.email;
                $scope.Contact = result.data.contact;
                $scope.Students = result.data.ResultData;
                $scope.headers = response.headers();
            })
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
                $scope.msg = "Post Data Submitted Successfully!";

        });
    }
}



   
    

  
