var vagantApp = window.vagantApp || {};
vagantApp.home = vagantApp.home || {};

vagantApp.home.HomePage = function () {
    var self = this;
};

$(function () {
    ko.applyBindings(new vagantApp.home.HomePage());
});