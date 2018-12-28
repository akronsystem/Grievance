﻿angular.module('GR').controller('UsersController', UsersController);

function UsersController($scope, Service) {

    var form = $(".student-admission-wrapper");
    $scope.ViewGetFacultyInfoes = {};
    $scope.UserCredentialModel = {};
    $scope.btnUpdate = false;
    $scope.IsVisible = false;


    $scope.Initialize = function () {
        $scope.UserCredentialModel.UserId = "";
        $scope.UserCredentialModel.Password = "";
        Service.Post("api/Users/GetFacultyInfo").then(function (result) {

            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.ViewGetFacultyInfoes = result.data;
            $scope.Faculty = result.data.ResultData;
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

        Service.Post("api/Users/GetSingleFaculty", JSON.stringify(data), $scope.UserCredentialModel).then(function (result) {



            $scope.ViewGetStudentInfoes = result.data;
            $scope.NameOfTheFaculty = result.data.name;
            $scope.EmployeeCode = result.data.code;
            $scope.Department = result.data.department;
            $scope.ContactNumber = result.data.contact;
            $scope.Email = result.data.email;
            $scope.Gender = result.data.gender;
            $scope.Designation = result.data.designation;
            $scope.UserId = result.data.UserId;
            $scope.Type = result.data.type;

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


    $scope.AddUpdate = function (NameOfTheFaculty, EmployeeCode, Gender, Department, Designation, Email, ContactNumber, UserId, Type) {
        debugger;
        var data = {

            name: NameOfTheFaculty,
            code: EmployeeCode,
            Department: Department,
            contact: ContactNumber,
            email: Email,
            Designation: Designation,
            gender: Gender,
            UserId: UserId,
            type: Type
        };
        Service.Post("api/Register/UpdateFacultyInfo", JSON.stringify(data)).then(function (response) {

            if (response.data)

                window.alert('Student Data Updated Successfully!')

            $scope.Clear();
            $scope.IsVisible = false;
            $scope.Initialize();
        });
    }


}
