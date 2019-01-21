angular.module('GR').controller('UsernameController', UsersController);

function UsersController($scope, Service) {

    var form = $(".m-form m-form--fit m-form--label");
    var form1 = $("#frmCRUD");
    $scope.UserName = sessionStorage.getItem('Email');

}