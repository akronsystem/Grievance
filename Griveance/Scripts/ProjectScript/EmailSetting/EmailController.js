angular.module('GR').controller('EmailSettingController', EmailSettingController);

function EmailSettingController($scope, Service, DTOptionsBuilder) {

    var form = $(".m-form m-form--fit m-form--label-align-right");
    $scope.tbl_emailsettings = {};
    $scope.IsVisible = false;
    $scope.btnSave = false;
    $scope.btnUpdate = false;

    $scope.fromid = null;
    $scope.host = null;
    $scope.port = null;
    $scope.password = null;
    $scope.UserCredentialModel = {};
    $scope.Initialize = function () {
        debugger;
        $scope.dtOptions = DTOptionsBuilder.newOptions()
            .withPaginationType('full_numbers').withDisplayLength(10)
        $scope.UserCredentialModel.DisplayStatus = $scope.btnactive;
       
        Service.Post("api/Common/GetEmailInformation", $scope.UserCredentialModel).then(function (result) {

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

  
    $scope.postdata = function (fromid, host, port, password) {
       
        var data = {
            fromid: fromid,
            host: host,
            port: port,
            password: password

        };

        if ($scope.form.$valid) {
            Service.Post("api/Common/SaveEmailSettings", JSON.stringify(data)).then(function (response) {
                if (response.data.IsSucess) {
                    debugger;
                    CustomizeApp.AddMessage();
                    $scope.Clear();
                    $scope.IsVisible = false;
                    $scope.Initialize();
                    //console.log(result.data);
                    // window.location = "./ParentGrievance"
                }
                else {
                    ShowMessage(0, response.data.Message);
                    //$scope.clear();
                    //window.location = "./PostGrievance"
                }
            });
        }
    }
        
     $scope.AddUpdate = function (fromid, host, port, password, emailsettingid) {
                var data = {
                    fromid: fromid,
                    host: host,
                    port: port,
                    password: password,
                    emailsettingid: emailsettingid

                };
                if ($scope.form.$valid) {
                    Service.Post("api/Common/UpdateEmailSettings", JSON.stringify(data)).then(function (response) {
                        if (response.data.IsSucess) {
                            debugger;
                            CustomizeApp.AddMessage();
                            $scope.Clear();
                            $scope.IsVisible = false;
                            $scope.Initialize();
                            //console.log(result.data);
                            // window.location = "./ParentGrievance"
                        }
                        else {
                            ShowMessage(0, response.data.Message);
                            //$scope.clear();
                            //window.location = "./PostGrievance"
                        }

                    });
                }
     }

        
     $scope.Delete = function (emailsettingid) {
         debugger;
         var data = {

             emailsettingid: emailsettingid,
           
         };
         var deactivestatus = 1;
         if (event.target.checked == false) {
             var confirm = window.confirm("Do you want to deactive this Entry ?");
             var deactivestatus = 0;
         }
         else {
             var confirm = window.confirm("Do you want to active this Entry ?");

         }
         if (confirm == true) {
             Service.Post("api/Common/DeleteEmailInformation", JSON.stringify(data)).then(function (response) {
                 debugger;


                 if (deactivestatus == 0) {
                     window.alert('Entry Deactive Successfully!')

                 }
                 else {
                     window.alert('Entry Active Successfully!')

                 }


                 debugger;
                 $scope.Cancel();
                 $scope.IsVisible = false;
                 $scope.Initialize();

             });
         }

         $scope.Initialize();

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