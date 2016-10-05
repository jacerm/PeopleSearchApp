angular.module('peopleSearchApp', ['ngMaterial']).component('peopleSearch', {
    templateUrl: '/Scripts/Angular/Templates/peopleSearch.html',
    controller: PeopleSearchController
});

function PeopleSearchController($http, $timeout) {
    var ctrl = this;

    var baseUrl = "/api/Individuals/";

    ctrl.createURL = "/Individuals/Create"
    
    ctrl.$onInit = function () {
        $http.get(baseUrl).then(
            function (response) {
                ctrl.individuals = response.data;
                console.log(response);
            },
            function (response) {

                console.log(response);
            }
        );
    };

    ctrl.submitSearch = function (query) {
        ctrl.Loading = true;
        ctrl.searchResults = [];
        $http.get(baseUrl + "Search/" + query).then(
            function (response) {
                $timeout(function () {
                    ctrl.Loading = false;
                    ctrl.searchResults = response.data;
                }, 3000);
                console.log(response.data);
            },
            function (response) {
                console.log(response);
            }
        );
    }
}
