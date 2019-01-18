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
        if (!$scope.GriveanceType)
            $scope.GriveanceType = -1;
        if (!$scope.name)
            $scope.name = -1;
        data= {
            id: $scope.id,
            fromdate: $scope.fromdate,
            todate: $scope.todate,
            GriveanceType: $scope.GriveanceType,
            name:$scope.name
        }
        var year = $scope.fromdate.getFullYear();
        var month = $scope.fromdate.getMonth() + 1 //getMonth is zero based;
        var day = $scope.fromdate.getDate();
        var formatted = day + "-" + month + "-" + year;
        
        var year1 = $scope.todate.getFullYear();
        var month1 = $scope.todate.getMonth() + 1 //getMonth is zero based;
        var day1 = $scope.todate.getDate();
        var todated = day1 + "-" + month1 + "-" + year1;
        window.open("http://localhost:55044/Admin/Report/ReportDwonload?id=" + $scope.id + "&fromdate=" + formatted + "&todate=" + todated + "&GriveanceType=" + $scope.GriveanceType + "&CellMember=" + $scope.name);

        //Service.Post("../Report/ReportDwonload",data) 
                


    }
}