
var app = angular.module("myApp", [])
    .controller("moviesCtrl", function ($scope, $http) {
    

        $scope.categoris = ["", "Action", "Drama", "Comedy"];

        //=================================================================

        $scope.url = "/Movie/MoviesByAngular";
        $http.get($scope.url)
            .then(function (response) {
                //alert("fassfsf");
                console.log(response.data);
                $scope.movies = response.data;

            }, function (response) {

                $scope.movies = "Something went wrong";

            });

        $scope.orderByField = "+Picture";
        $scope.sortDirection = "down";
        $scope.selected = "Picture";

        $scope.sortBy = function (field) {
            console.log(field);

            $scope.selected = field;
          

            if ($scope.orderByField.substring(1)  == field) // לחצו על אותו שדה 
            {
                if ($scope.orderByField.substring(0, 1) == "+") {
                    $scope.orderByField = "-" + field;
                    $scope.sortDirection = "up";
                }
                else {
                    $scope.orderByField = "+" + field;
                    $scope.sortDirection = "down";
                }
            }
            else {
                // לחצו על שדה אחר
                $scope.orderByField = "+" + field;
                $scope.sortDirection = "down";
            }

        }
    });










