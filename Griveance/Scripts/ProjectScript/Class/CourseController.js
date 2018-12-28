﻿angular.module('GR').controller('ClassYearController', ClassYearController);

function ClassYearController($scope, Service) {

    var form = $(".m-form m-form--fit m-form--label");
    $scope.ViewGetCourseInfoes = {};
    $scope.ViewGetClassLists = {};


    $scope.Initialize = function () {

        Service.Get("api/Course/GetCourseInfo").then(function (result) {

            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.ViewGetCourseInfoes = result.data;
            $scope.Course = result.data.ResultData;
            console.log(result.data);

        })

    }
    $scope.GetData = function () {

        Service.Get("api/ClassYear/GetClassInfo").then(function (result) {
            debugger;
            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.ViewGetClassLists = result.data;
            $scope.Class = result.data.ResultData;
            console.log(result.data);

        })

    }
    $scope.GetInfo = function () {

        Service.Get("api/ClassYear/GetAllClassInfo").then(function (result) {
            debugger;
            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.ViewGetClassLists = result.data;
            $scope.Class = result.data.ResultData;
            console.log(result.data);

        })

    }

    //$scope.Save = function (data) {

    //    $scope.ParamRegistration.name = data.name;
    //    $scope.ParamRegistration.code = data.code;
    //    $scope.ParamRegistration.type = data.type;
    //    $scope.ParamRegistration.gender = data.gender;
    //    $scope.ParamRegistration.email = data.email;
    //    $scope.ParamRegistration.contact = data.contact;
    //    $scope.ParamRegistration.password = data.password;

    //}
    $scope.Add = function () {
        debugger;
        var Employee = {
            email:$scope.email,
            name: $scope.name,
            code: $scope.code,
            type: $scope.type,
            gender: $scope.gender,
            contact: $scope.contact,
            password: $scope.password,
            CourseName: $scope.CourseName,
            ClassName: $scope.ClassName,
            designation: $scope.designation,
            relationship: $scope.relationship
           
        };
       
        Service.Post("api/Register/SaveRegistration", JSON.stringify(Employee)).then(function (result) {
            debugger;
            // $scope.ParamUserLogin.Name = result.data.Name
            if (result.data.IsSucess)
            {
                debugger;
                console.log(result.data);
                window.location = "./Index"
            }
            else
            {
                window.alert('Record Not Inserted.')
                window.location = "./Register"
            }
           
        })
       
       
    }
    $scope.Cancel = function () {
        window.location = "./Index";
    }
    $scope.CourseAdd = function () {
        debugger;
        var Course = {
            CourseName: $scope.CourseName
        };

        Service.Post("api/Course/CreateCourse", JSON.stringify(Course)).then(function (result) {
            debugger;
            // $scope.ParamUserLogin.Name = result.data.Name
            if (result.data.IsSucess) {
                debugger;
                console.log(result.data);
                window.location = "./NAdminDashboard"
            }
            else {
                window.alert('Not Created Course')
                window.location = "./NAdminDashboard"
            }

        })


    }
    $scope.ClassAdd = function () {
        debugger;
        var Class = {
            CourseName: $scope.CourseName,
            ClassName: $scope.ClassName
        };

        Service.Post("api/ClassYear/CreateClass", JSON.stringify(Class)).then(function (result) {
            debugger;
            // $scope.ParamUserLogin.Name = result.data.Name
            if (result.data.IsSucess) {
                debugger;
                console.log(result.data);
                window.location = "./NAdminDashboard"
            }
            else {
                window.alert('Not Created Class')
                window.location = "./NAdminDashboard"
            }

        })


    }
}

