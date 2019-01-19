angular.module('GR').controller('ClassYearController', ClassYearController);

function ClassYearController($scope, Service) {

    var form = $(".m-form m-form--fit m-form--label");
    $scope.ViewGetCourseInfoes = {};
    $scope.ViewGetClassLists = {};
    $scope.chartContainer = {};

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
            debugger;
            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.ViewGetClassLists = result.data;
            $scope.Class = result.data.ResultData;
            console.log(result.data);

        })

    }
    $scope.GetInfo = function () {

        Service.Post("api/ClassYear/GetAllClassInfo").then(function (result) {
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
            email: $scope.email,
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
    $scope.Cancel = function () {
        window.location = "./Index";
    }
    $scope.CourseAdd = function () {
        debugger;
        var Course = {
            CourseName: $scope.CourseName,
            UserId:1333
        };
        
        //if ($scope.form.$valid)
        {
            Service.Post("api/Course/CreateCourse", JSON.stringify(Course)).then(function (result) {
                debugger;
                // $scope.ParamUserLogin.Name = result.data.Name
                if (result.data.IsSucess) {
                    debugger;
                    CustomizeApp.AddMessage();
                    window.location = "./NAdminProfile"
                }
                else {
                    ShowMessage(0, result.data.Message);
                    //$scope.clear();
                    //window.location = "./PostGrievance"
                }
              

            })
        }

    }
    $scope.ClassAdd = function () {
        debugger;
        var Class = {
            CourseName: $scope.CourseName,
            ClassName: $scope.ClassName,
            UserId:29393
        };
        //if ($scope.form.$valid)
        {
            Service.Post("api/ClassYear/CreateClass", JSON.stringify(Class)).then(function (result) {
                debugger;
                // $scope.ParamUserLogin.Name = result.data.Name
                if (result.data.IsSucess) {
                    debugger;
                    CustomizeApp.AddMessage();
                    window.location = "./NAdminProfile"
                }
                else {
                    ShowMessage(0, result.data.Message);
                    //$scope.clear();
                    //window.location = "./PostGrievance"
                }

            })

        }

    }
    $scope.GetUserCount = function () {
        Service.Get("api/Grievance/GetUserList").then(function (result) {
            if (result.data) {
                debugger;
              $scope.studcount = result.data[0][1];
              $scope.parentcount = result.data[1][1];
              $scope.staffcount = result.data[2][1];
              $scope.facultycount = result.data[3][1];
            }
        });
        }



    $scope.ShowGraph = function () {
        debugger;

        Service.Get("api/Grievance/ShowGraph").then(function (result) {
            debugger;
            // $scope.ParamUserLogin.Name = result.data.Name
            if (result.data) {
                debugger;
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

