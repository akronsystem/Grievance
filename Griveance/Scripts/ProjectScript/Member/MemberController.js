angular.module('GR').controller('MemberController', MemberController);

function MemberController($scope, Service, DTOptionsBuilder, $timeout) {

    var form = $(".m-form m-form--fit m-form--label");
    $scope.IsVisible = false;
    $scope.tbl_memberinfo = {};
    $scope.UserCredentialModel = {};
    $scope.dtOptions = {};
    $scope.myText = "/Content/assets/images/ajax-loader.gif";
    $scope.isCheck = true;
    $scope.btnValue = "SAVE";
    $scope.Initialize = function () {
        debugger;
       
        if (!$scope.dtOptions)
            $scope.dtOptions = DTOptionsBuilder.newOptions()
                .withPaginationType('full_numbers').withDisplayLength(10)
        
        $scope.UserCredentialModel.DisplayStatus = $scope.btnactive;
        Service.Post("api/Member/GetMemberInfo", $scope.UserCredentialModel).then(function (result) {
            $scope.Clear();
            $scope.GetInfo();
            console.log(result.data)
            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.tbl_memberinfo = result.data;
            $scope.Member = result.data.ResultData;
            console.log(result.data);

        })

    }
    $scope.Add = function () {
        debugger;
       
        var Member = {
            

            EmailId: $scope.EMAILID,
            Name: $scope.NAME,
            Code: $scope.EMPLOYEECODE,
            Type: $scope.TYPE,
            GriType: $scope.GRIEVANCETYPE,
            Gender: $scope.GENDER,
            MobileNo: $scope.MOBILENO,
            Password: $scope.Password,
            Designation: $scope.DESIGNATION           

        };
        if ($scope.form.$valid) {
            $scope.disableBtn = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";

            $timeout(function () {
                $scope.isCheck = true;
                $scope.disableBtn = false;
                $scope.btnValue = "SAVE";
                $scope.btnStyle = "";

                Service.Post("api/Member/MemberSave", JSON.stringify(Member)).then(function (result) {
                    debugger;
                    // $scope.ParamUserLogin.Name = result.data.Name

                    if (result.data.IsSucess) {
                        debugger;
                        CustomizeApp.AddMessage();
                        $scope.IsVisible = false;

                        //window.location = "Griveance/GrievanceAllocation"
                    }
                    else {
                        ShowMessage(0, result.data.Message);
                        //$scope.clear();
                        //window.location = "./PostGrievance"
                    }

                })
            }, 3000);
        }

 
    }

    $scope.Show = function () {
        $scope.IsVisible = true;
        $scope.txtPASSSOWRD = true;
        $scope.txtCONFIRMPASSWORD = true;
        $scope.btnUpdate = false;
        $scope.btnSave = true;
        $scope.empcode = false;
        $scope.Clear();
        $scope.msg = "";
        $scope.Initialize();

    }

   

    $scope.ShowHide = function (UserId) {
        //$scope.Cancel();
        debugger;
        var data = {
            UserId: UserId

        };
        $scope.IsVisible = true;
        Service.Post("api/Grievance/GetSingleGrievance", JSON.stringify(data), $scope.UserCredentialModel).then(function (result) {
            $scope.txtPASSSOWRD = false;
            $scope.txtCONFIRMPASSWORD = false;

          

            $scope.IsVisible = true;
            $scope.btnUpdate = true;
            $scope.btnSave = false;
            $scope.tbl_memberinfo = result.data;

            $scope.EMAILID = result.data.email;
            $scope.NAME = result.data.name;
            $scope.EMPLOYEECODE = result.data.code;
            $scope.GENDER = result.data.gender;
            $scope.MOBILENO = result.data.contact;
            $scope.DESIGNATION = result.data.designation;
            $scope.griType = result.data.griType;
            $scope.USERID = result.data.UserId;
            $scope.empcode = true;
           
           
        })
    }

    $scope.GetData = function () {

        var data = sessionStorage.getItem('emp-key');
        $scope.UserCredentialModel.StudentCode = data;
        var userid = sessionStorage.getItem('userid');
        $scope.UserCredentialModel.UserId = userid;
        var password = sessionStorage.getItem('Password');
        $scope.UserCredentialModel.Password = password;
        Service.Post("api/Common/GetMyGrievance", $scope.UserCredentialModel).then(function (result) {

            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.ViewGetStudentInfoes = result.data;
            $scope.Student = result.data.ResultData;
            console.log(result.data);

        })

    }

    //$scope.Update = function (isValid) {
    //    debugger;
    //    if (isValid) {
    $scope.Update = function (NAME, GENDER, EMPLOYEECODE, EMAILID, MOBILENO, DESIGNATION, USERID, GRIEVANCETYPE) {
        debugger;
        var data = {
            name: NAME,
            gender: GENDER,
            code: EMPLOYEECODE,
            EmailId: EMAILID,
            MobileNo: MOBILENO,
            designation: DESIGNATION,
            UserId: USERID,
            GriType: GRIEVANCETYPE

        };
        if (data!=null) {
            $scope.disableBtn = true;
            $scope.isCheck = false;
            $scope.btnValue = "SAVING.........";

            $timeout(function () {
                $scope.isCheck = true;
                $scope.disableBtn = false;
                $scope.btnValue = "SAVE";
                $scope.btnStyle = "";
                Service.Post("api/Grievance/UpdateMemberInfo", JSON.stringify(data)).then(function (response) {
                    if (response.data.IsSucess) {
                        debugger;
                        CustomizeApp.UpdateMessage();
                        $scope.Cancel();
                        //$scope.IsVisible = false;
                        //$scope.Initialize();
                        //console.log(result.data);
                        // window.location = "./ParentGrievance"
                    }
                    else {
                        ShowMessage(0, response.data.Message);
                        //$scope.clear();
                        //window.location = "./PostGrievance"
                    }

                });
            }, 3000);
        }
    }
    //    }
    //}


    $scope.Delete = function (UserId) {
        debugger;
        var data = {

            UserId: UserId,
            
        };
        var deactivestatus = 1;
        if (event.target.checked == false) {
            var confirm = window.confirm("Do you want to change the status to deactive of this member ?");
            deactivestatus = 0;
        }
        else {
            var confirm = window.confirm("Do you want to change the status to active of this member ?");
        }
        if (confirm == true) {
            Service.Post("api/Grievance/DeleteMemberInfo", JSON.stringify(data)).then(function (response) {

                $scope.Initialize();


                if (deactivestatus == 0) {
                    window.alert('Member Deactived Successfully!')

                }
                else {
                    window.alert('Member Actived Successfully!')

                }

            });
        }
        $scope.Clear();
        $scope.IsVisible = false;
    


    }

    $scope.GetInfo = function () {
         
        Service.Post("api/Grievance/GetUnAssignedGrievanceType").then(function (result) {
            debugger;
            // $scope.ParamUserLogin.Name = result.data.Name
            $scope.tbl_grievance_list = result.data;
            $scope.Grievance = result.data.ResultData;
            console.log(result.data);

        })

    }
    $scope.Cancel = function () {
        $scope.Clear();
        $scope.IsVisible = false;
        $scope.msg = "";
        $scope.Initialize();
    }

    


    $scope.SavePost = function () {
        debugger;
       
            var data = sessionStorage.getItem('userid');
            var Password = sessionStorage.getItem('Password');
            var code = sessionStorage.getItem('emp-key');
            var email = sessionStorage.getItem('Email');
            var type = sessionStorage.getItem('Type');
            PostGr = {
                GriveanceType: $scope.GriveanceType,
                Subject: $scope.Subject,
                PostDetails: $scope.PostDetails,
                UserId: data,
                Password: Password,
                Code: code,
                Email: email,
                Type: type,

            };
           
            if ($scope.form.$valid) {
                Service.Post("api/Grievance/PostGrievance", JSON.stringify(PostGr)).then(function (result) {
                    debugger;
                    // $scope.ParamUserLogin.Name = result.data.Name

                    console.log(result.data);
                    if (result.data.IsSucess) {
                        debugger;
                        console.log(result.data);
                        window.location = "./StudentGrievance"
                    }
                    else {
                        window.alert('Record Not Inserted.')
                        window.location = "./PostGrievance"
                    }
                })
            }

    }
    $scope.Clear = function () {
                                       


                                        $scope.EMAILID = null;
                                        $scope.NAME = null;
                                        $scope.EMPLOYEECODE = null;
                                        $scope.GENDER = null;
                                        $scope.MOBILENO = null;
                                        $scope.DESIGNATION = null;
                                        $scope.GRIEVANCETYPE = null;
                                        $scope.USERID = null;
    }

  

}
