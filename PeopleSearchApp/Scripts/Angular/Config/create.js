angular.module('createPeopleApp', ['ngMaterial', 'ngMessages']).component('createPeople', {
    templateUrl: '/Scripts/Angular/Templates/createPeople.html',
    controller: CreatePeopleController
});

function CreatePeopleController($http, $mdToast) {
    var ctrl = this;

    var baseUrl = "/api/Individuals/";

    ctrl.searchURL = "/Individuals/Index";

    ctrl.avatarData = [{
        id: "avatarspng_1",
        title: 'Male Avatar',
        value: '/Content/avatar_male.png'
    }, {
        id: "avatarspng_2",
        title: 'Female Avatar',
        value: '/Content/avatar_female.png'
    }];

    ctrl.createPerson = function (person) {
        person.ID = 0;
        $http.post(baseUrl + "Create/", person).then(
            function (response) {
                $mdToast.show(
                  $mdToast.simple()
                    .textContent('Person Created Successfully!')
                    .position('bottom left')
                    .hideDelay(3000)
                );
                console.log(response.data);
            },
            function (response) {
                $mdToast.show(
                  $mdToast.simple()
                    .textContent('Error Creating Person!')
                    .position('bottom left')
                    .hideDelay(3000)
                );
                console.log(response);
            }
        );
    }
}
