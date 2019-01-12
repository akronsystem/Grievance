angular.module('GR').controller('ReportController', ReportController);

function ReportController($scope, Service) {
    $scope.tbl_rpt = {};
    var form = $(".m-form m-form--fit m-form--label");
    
    $scope.Initialize = function () {

        Service.Post("api/Report/GetReportType").then(function (result) {
            
            $scope.tbl_rpt = result.data.ResultData;
            $scope.Report = result.data.ResultData;
            console.log(result.data);

        })

    }
    $scope.GetInfo = function () {
        $scope.dtOptions = "";
        Service.Post("api/Grievance/GriveanceTypeInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.tbl_grievance_list = result.data;
            $scope.Grievance = result.data.ResultData;
            console.log(result.data);

        })

    }
    $scope.GetMember = function () {
      
        Service.Post("api/Member/MemberInfo", $scope.UserCredentialModel).then(function (result) {
            debugger;
            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.View_ForMemberName = result.data;
            $scope.Member = result.data.ResultData;
            console.log(result.data);

        })

    }
    $scope.Save = function (data) {
        debugger;
        data= {
            id: $scope.id
        }
        window.open("http://localhost:55044/Admin/Report/ReportDwonload?id=" + $scope.id);

        //Service.Post("../Report/ReportDwonload",data) 
                


    }
}