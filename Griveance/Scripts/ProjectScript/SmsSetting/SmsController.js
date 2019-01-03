angular.module('GR').controller('SmsSettingController', SmsSettingController);

function SmsSettingController($scope, Service, DTOptionsBuilder) {

    var form = $(".student-admission-wrapper");
    $scope.tbl_smssettings = {};
    $scope.IsVisible = false;
    $scope.GATEWAYUSERID = null;
    $scope.GATEWAYPASSWORD = null;
    $scope.SMSSENDAPI = null;
    $scope.CHECKBALANCEAPI = null;
    $scope.SETTINGID = null;
    $scope.Initialize = function () {
        $scope.dtOptions = DTOptionsBuilder.newOptions()
            .withPaginationType('full_numbers').withDisplayLength(10)

        Service.Get("api/Common/SmsSettingList").then(function (result) {

            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.tbl_smssettings = result.data;
            $scope.Sms = result.data.ResultData;
            console.log(result.data);

        })

    }

    $scope.ShowHide = function (SETTINGID) {
        //$scope.Cancel();
        var data = {
            SettingId: SETTINGID

        };
        $scope.IsVisible = true;
        Service.Post("api/Common/GetSingleSmsSetting", JSON.stringify(data), $scope.UserCredentialModel).then(function (result) {

            debugger;

            $scope.IsVisible = true;
            $scope.btnUpdate = true;
            $scope.btnSave = false;
            $scope.tbl_smssettings = result.data;

            $scope.GATEWAYUSERID = result.data.GATEWAYUSERID;
            $scope.GATEWAYPASSWORD = result.data.GATEWAYPASSWORD;
            $scope.SMSSENDAPI = result.data.SMSSENDAPI;
            $scope.CHECKBALANCEAPI = result.data.CHECKBALANCEAPI;
            $scope.SETTINGID = result.data.SETTINGID;
           
            $scope.Initialize();
        })
    }

    


    $scope.Show = function () {
        $scope.IsVisible = true;
        $scope.btnUpdate = false;
        $scope.btnSave = true;

        $scope.GATEWAYUSERID = null;
        $scope.GATEWAYPASSWORD = null;
        $scope.SMSSENDAPI = null;
        $scope.CHECKBALANCEAPI = null;
        $scope.msg = "";
        $scope.Initialize();

    }

    $scope.postdata = function (isValid) {

        if (isValid) {
            $scope.postdata = function (GATEWAYUSERID, GATEWAYPASSWORD, SMSSENDAPI, CHECKBALANCEAPI) {
                debugger;
                var data = {
                    GatewayUserid: GATEWAYUSERID,
                    GatewayPassword: GATEWAYPASSWORD,
                    SmsSendApi: SMSSENDAPI,
                    CheckbalanceApi: CHECKBALANCEAPI

                };


                Service.Post("api/Common/SaveSmsSettings", JSON.stringify(data)).then(function (response) {
                    if (response.data)
                        $scope.Initialize();
                    $scope.msg = "Sms Settings Saved Successfully!";
                    $scope.IsVisible = false;
                });
            }
        }
    }

    $scope.Update = function (isValid) {

        if (isValid) {
            $scope.Update = function (GATEWAYUSERID, GATEWAYPASSWORD, SMSSENDAPI, CHECKBALANCEAPI, SETTINGID) {
                var data = {
                    GatewayUserId: GATEWAYUSERID,
                    GatewayPassword: GATEWAYPASSWORD,
                    SmsSendApi: SMSSENDAPI,
                    CheckBalanceApi: CHECKBALANCEAPI,
                    SettingId: SETTINGID

                };
                Service.Post("api/Common/UpdateSmsSettings", JSON.stringify(data)).then(function (response) {

                    if (response.data)
                        $scope.Initialize();
                    $scope.msg = "Sms Setting Updated Successfully!";
                    $scope.IsVisible = false;

                });
            }
        }
    }
    $scope.Cancel = function () {

        $scope.GATEWAYUSERID = null;
        $scope.GATEWAYPASSWORD = null;
        $scope.SMSSENDAPI = null;
        $scope.CHECKBALANCEAPI = null;
      
        $scope.IsVisible = false;
        $scope.msg = "";
        $scope.Initialize();
    }

}