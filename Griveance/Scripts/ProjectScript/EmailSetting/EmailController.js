angular.module('GR').controller('EmailSettingController', EmailSettingController);

function EmailSettingController($scope, Service) {

    var form = $(".student-admission-wrapper");
    $scope.tbl_emailsettings = {};
    $scope.IsVisible = false;
    $scope.btnSave = false;
    $scope.btnUpdate = false;

    $scope.fromid = null;
    $scope.host = null;
    $scope.port = null;
    $scope.password = null;

    $scope.Initialize = function () {

        Service.Get("api/Common/GetEmailInfo").then(function (result) {

            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.tbl_emailsettings = result.data;
            $scope.Email = result.data.ResultData;
            console.log(result.data);

        })

    }

    $scope.ShowHide = function (emailsettingid) {
        $scope.Cancel();
        var data = {
            emailsettingid: emailsettingid

        };

      
        Service.Post("api/Common/GetSingleEmailInfo", JSON.stringify(data), $scope.UserCredentialModel).then(function (result) {

            debugger;
         
            $scope.IsVisible = true ;
            $scope.btnUpdate = true;
            $scope.btnSave = false;
            $scope.tbl_emailsettings = result.data;

            $scope.fromid = result.data.fromid;
            $scope.host = result.data.host;
            $scope.port = result.data.port;
            $scope.password = result.data.password;
            $scope.emailsettingid = result.data.emailsettingid;
            $scope.Email = result.data.ResultData;
            $scope.Initialize();
        })
    }

    
    $scope.Show = function () {
        $scope.IsVisible = true;
        $scope.btnUpdate = false;
        $scope.btnSave = true;

        $scope.fromid = null;
        $scope.host = null;
        $scope.port = null;
        $scope.password = null;
       
        $scope.msg = "";
        $scope.Initialize();
      
    }


    debugger;
    $scope.postdata = function (fromid, host, port, password) {
       
        var data = {
            fromid: fromid,
            host: host,
            port: port,
            password: password

        };


        Service.Post("api/Common/SaveEmailSettings", JSON.stringify(data)).then(function (response) {
            if (response.data)
                $scope.Initialize();
            $scope.msg = "Email Settings Saved Successfully!";
            $scope.IsVisible = false;
        });
    }


    $scope.AddUpdate = function (fromid, host, port, password, emailsettingid) {
        var data = {
            fromid: fromid,
            host: host,
            port: port,
            password: password,
            emailsettingid: emailsettingid
           
        };
        Service.Post("api/Common/UpdateEmailSettings", JSON.stringify(data)).then(function (response) {

            if (response.data)               
                $scope.Initialize();
            $scope.msg = "Email Settings Updated Successfully!";
            $scope.IsVisible = false;
           
        });
    }

    $scope.Cancel = function () {
      
        $scope.fromid = null;
        $scope.host = null;
        $scope.port = null;
        $scope.password = null;
        $scope.IsVisible = false;
        $scope.msg = "";
        $scope.Initialize();
    }



   


}