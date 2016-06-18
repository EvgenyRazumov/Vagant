var vagantApp = window.vagantApp || {};
vagantApp.home = vagantApp.home || {};

vagantApp.home.Timeline = function () {
    var self = this;

    self.dates = ko.observableArray([]);

    self.selectDate = function (element, information) {
        alert(information.on);
    };

    var init = function () {
        var ev = [{
            on: new Date(2011, 2, 15)
        }, {
            on: new Date(2011, 2, 17)
        }, {
            on: new Date(2011, 5, 30)
        }, {
            on: new Date(2011, 7, 5)
        }, {
            on: new Date(2012, 5, 5)
        }, {
            on: new Date(2012, 5, 30)
        }, {
            on: new Date(2013, 0, 1)
        }, {
            on: new Date(2013, 6, 10)
        }, {
            on: new Date(2014, 6, 10)
        }, {
            on: new Date(2015, 6, 10)
        }];

        self.dates(ev);
    };

    init();
};