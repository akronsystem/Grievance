angular.module('GR').controller('GrievanceController', GrievanceController);

function GrievanceController($scope, Service, DTOptionsBuilder) {

    var form = $(".student-admission-wrapper");
    $scope.tbl_grievance_list = {};
    $scope.UserCredentialModel = {};
    $scope.IsVisible = false;
    $scope.btnSave = false;
    $scope.btnUpdate = false;


    $scope.Initialize = function () {
        $scope.dtOptions = DTOptionsBuilder.newOptions()
            .withPaginationType('full_numbers').withDisplayLength(10)

        $scope.UserCredentialModel.UserId = "";
        $scope.UserCredentialModel.Password = "";
        Service.Post("api/Grievance/GriveanceTypeInfo").then(function (result) {

            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.tbl_grievance_list = result.data;
            $scope.GrievanceType = result.data.ResultData;
            console.log(result.data);

        })

    }
    $scope.Show = function () {
        //If DIV is visible it will be hidden and vice versa.
        $scope.IsVisible = true;
        $scope.btnSave = true;
        $scope.btnUpdate = false;
    }

    $scope.Save = function (GrievanceName, GrievanceDescription) {
        debugger;
        var Grievance = {
            GrievanceName: $scope.GrievanceName,
            GrievanceDescription: $scope.GrievanceDescription
          

        };
        if ($scope.form.$valid) {
            Service.Post("api/Grievance/SaveGrievanceType", JSON.stringify(Grievance)).then(function (result) {
                debugger;
                // $scope.ParamUserLogin.Name = result.data.Name
                if (result.data.IsSucess) {
                    debugger;
                    console.log(result.data);
                    window.location = "./GrievanceType"
                }
                else {
                    window.alert('Grievance Type does not Save')
                    window.location = "./GrievanceType"
                }

            })
        }


    }
    $scope.ShowHide = function (GrievanceId) {
        $scope.btnSave = false;
        $scope.btnUpdate = true;
         var data = {
             GrievanceId: GrievanceId

        };
        

         Service.Post("api/Grievance/GetSingleGrievanceTypeInfo", JSON.stringify(data), $scope.UserCredentialModel).then(function (result) {
          
            debugger;

            $scope.IsVisible = true;
            $scope.btnUpdate = true;
            $scope.btnSave = false;
            $scope.tbl_grievance_list = result.data;

            $scope.GrievanceId = result.data.grivance_id;
            $scope.GrievanceName = result.data.grivance_name;
            $scope.GrievanceDescription = result.data.grivance_description;
            $scope.Initialize();
        })
    }

    $scope.Update = function (GrievanceName, GrievanceDescription, GrievanceId) {
        debugger;
        var Info = {
            GrievanceName:GrievanceName,
            GrievanceDescription:GrievanceDescription,
            GrievanceId: GrievanceId

        };
        if ($scope.form.$valid) {
            Service.Post("api/Grievance/UpdateGrievanceType", JSON.stringify(Info)).then(function (result) {
                debugger;
                // $scope.ParamUserLogin.Name = result.data.Name
                if (result.data.IsSucess) {
                    debugger;
                    console.log(result.data);
                    window.location = "./GrievanceType"
                }
                else {
                    window.location = "./GrievanceType"
                }

            })
        }


    }

    $scope.Cancel = function () {
        $scope.IsVisible = false;
        $scope.GrievanceName = null;
        $scope.GrievanceDescription = null;
    }

    
}
