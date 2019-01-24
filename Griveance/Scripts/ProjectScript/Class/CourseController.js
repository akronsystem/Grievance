angular.module('GR').controller('ClassYearController', ClassYearController);

function ClassYearController($scope, Service) {

    var form = $(".m-form m-form--fit m-form--label");
    var form1 = $("#frmCRUD");

    $scope.ViewGetCourseInfoes = {};
    $scope.ViewGetClassLists = {};
    $scope.chartContainer = {};


    $scope.UserCredentialModel = {};

    $scope.Initialize = function () {

        Service.Get("api/Course/GetCourseInfo").then(function (result) {
            // $scope.ParamUserLogin.Name = result.data.Name


            $scope.ViewGetCourseInfoes = result.data;
            $scope.Course = result.data.ResultData;

            console.log(result.data);

        })

    }
    $scope.GetData = function () {

        Service.Post("api/ClassYear/GetClassInfo").then(function (result) {

            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.ViewGetClassLists = result.data;
            $scope.Class = result.data.ResultData;
            console.log(result.data);

        })

    }
    $scope.GetInfo = function () {

        Service.Post("api/ClassYear/GetAllClassInfo").then(function (result) {

            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.ViewGetClassLists = result.data;
            $scope.Class = result.data.ResultData;
            console.log(result.data);

        })

    }


    $scope.Add = function () {
        debugger;
        var Employee = {
            email: $scope.email,
            name: $scope.name,
            code: $scope.code,
            type: $scope.type,
            gender: $scope.gender,
            contact: $scope.contact,
            password: $scope.password,
            Confirmpassword: $scope.Confirmpassword,
            CourseName: $scope.CourseName,
            ClassName: $scope.ClassName,
            designation: $scope.designation,
            relationship: $scope.relationship

        };
        if ($scope.password == $scope.Confirmpassword) {
            //var reg = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            ////if (!$scope.password.test(reg))
            ////{
            ////    alert('Password must be 8 Characters');
            ////    return false;
            ////}
            //errors = [];
            //if ($scope.password.length < 8) {
            //    alert("Your password must be at least 8 characters");
            //    return false;
            //}
            //if ($scope.password.search(/[a-z]/i) < 0) {
            //    alert("Your password must contain at least one letter.");
            //    return false;
            //}
            //if ($scope.password.search(/[0-9]/) < 0) {
            //    alert("Your password must contain at least one digit.");
            //    return false;
            //}
        }
        else {
            alert('Please Check ConfirmPassword')
            return false;
        }
        if (form1.valid()) {
            Service.Post("api/Register/SaveRegistration", JSON.stringify(Employee)).then(function (result) {
                debugger;
                if (result.data.IsSucess) {
                    debugger;
                    CustomizeApp.AddMessage();
                    window.location = "./Index"
                    //console.log(result.data);
                    // window.location = "./ParentGrievance"
                }
                else {
                    ShowMessage(0, result.data.Message);
                    //$scope.clear();
                    //window.location = "./PostGrievance"
                }
                // $scope.ParamUserLogin.Name = result.data.Name


            })
        }

    }
    $scope.Cancel = function () {
        window.location = "./Index";
    }
    $scope.CourseAdd = function () {
        $scope.UserId = sessionStorage.getItem('userid').replace(/"/g, '');
        $scope.password = sessionStorage.getItem('Password').replace(/"/g, '');

        var Course = {
            CourseName: $scope.CourseName,
            UserId: $scope.UserId,
            Password: $scope.password
        };


        if (form1.valid()) {
            Service.Post("api/Course/CreateCourse", JSON.stringify(Course)).then(function (result) {


                // $scope.ParamUserLogin.Name = result.data.Name
                if (result.data.IsSucess) {
                    CustomizeApp.AddMessage();
                    $scope.Initialize();
                }
                else {
                    ShowMessage(0, result.data.Message);
                    $scope.Initialize();
                    //$scope.clear();
                }

            })
        }
    }


    $scope.ClassAdd = function () {

        var Class = {
            CourseName: $scope.CourseName1,
            ClassName: $scope.ClassName,
            UserId: sessionStorage.getItem('userid').replace(/"/g, ''),
            Password: sessionStorage.getItem('Password').replace(/"/g, '')
        };
        if ($scope.ClassName == undefined) {
            ShowMessage(0, 'Reqired Class Name');
        }
        else {
            Service.Post("api/ClassYear/CreateClass", JSON.stringify(Class)).then(function (result) {


                // $scope.ParamUserLogin.Name = result.data.Name
                if (result.data.IsSucess) {
                    CustomizeApp.AddMessage();
                    $scope.Close();
                }
                else {
                    ShowMessage(0, result.data.Message);
                    //$scope.clear();
                    //window.location = "./PostGrievance"
                }

            })

        }

    }
    $scope.Close = function () {
        $scope.CourseName1 = null;
        $scope.ClassName = null;
        $scope.GetInfo();
    }
    $scope.GetUserCount = function () {
        Service.Get("api/Grievance/GetUserList").then(function (result) {
            if (result.data) {

                $scope.studcount = result.data[0][1];
                $scope.parentcount = result.data[1][1];
                $scope.staffcount = result.data[2][1];
                $scope.facultycount = result.data[3][1];
            }
        });

    }



    $scope.ShowGraph = function () {


        Service.Get("api/Grievance/ShowGraph").then(function (result) {

            // $scope.ParamUserLogin.Name = result.data.Name
            if (result.data) {

                var pendingper, closedper;
                var pending, closed;

                pending = result.data[0][0];
                pendingper = result.data[0][1];
                closed = result.data[1][0];
                closedper = result.data[1][1];

                var DoughnutChartData =
                    {
                        labels: [pending, closed],
                        datasets: [{
                            label: 'Grievance Status',
                            backgroundColor: [
                                "#f990a7",
                                "#aad2ed",
                                "#9966FF",
                                "#99e5e5",
                                "#f7bd83",
                            ],
                            borderWidth: 1,
                            data: [pendingper, closedper]
                        }]
                    };


                var ctx1 = document.getElementById("Doughnutcanvas").getContext("2d");
                window.myBar = new Chart(ctx1,
                    {
                        type: 'doughnut',

                        data: DoughnutChartData,
                        options:
                        {
                            title:
                            {
                                display: true,
                                text: "Grievance Status",
                                fontSize: "20"
                            },
                            responsive: true,
                            maintainAspectRatio: true,
                            cutoutPercentage: 70,


                            legend: {
                                position: 'bottom'

                            }
                        }
                    });
            }
            else {
                window.alert('Not Created Class')
                window.location = "./NAdminDashboard"
            }

        })
    }
}



