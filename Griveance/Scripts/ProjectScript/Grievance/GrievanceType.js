angular.module('GR').controller('GrievanceController', GrievanceController);

function GrievanceController($scope, Service, DTOptionsBuilder) {

    var form = $(".student-admission-wrapper");
    var form1 = $("#frmCRUD");
    $scope.tbl_grievance_list = {};
    $scope.UserCredentialModel = {};
    $scope.IsVisible = false;
    $scope.btnSave = false;
    $scope.btnUpdate = false;
    $scope.dtOptions = {};



    $scope.Initialize = function () {
        if (!$scope.dtOptions)

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
        if (form1.valid()) {
            Service.Post("api/Grievance/SaveGrievanceType", JSON.stringify(Grievance)).then(function (result) {
                debugger;
                // $scope.ParamUserLogin.Name = result.data.Name
                if (result.data.IsSucess) {
                    debugger;
                    CustomizeApp.AddMessage();
                    $scope.Clear();

                    //console.log(result.data);
                    // window.location = "./ParentGrievance"
                }
                else {
                    ShowMessage(0, result.data.Message);
                    //$scope.clear();
                    //window.location = "./PostGrievance"
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
        if (GrievanceName == undefined || GrievanceDescription == undefined) {
            ShowMessage(0, result.data.Message);
        }
            Service.Post("api/Grievance/UpdateGrievanceType", JSON.stringify(Info)).then(function (result) {
                debugger;
                if (result.data.IsSucess) {
                    debugger;
                    CustomizeApp.UpdateMessage();
                    $scope.Clear();
                   
                    //console.log(result.data);
                    // window.location = "./ParentGrievance"
                }
                else {
                    ShowMessage(0, result.data.Message);
                    //$scope.clear();
                    //window.location = "./PostGrievance"
                }

            })
        


    }

    $scope.Cancel = function () {
        $scope.IsVisible = false;
        $scope.GrievanceName = null;
        $scope.GrievanceDescription = null;
    }
    $scope.Clear = function () {
        $scope.IsVisible = false;
        $scope.IsVisible = false;
        $scope.Initialize();
    }

    
}
