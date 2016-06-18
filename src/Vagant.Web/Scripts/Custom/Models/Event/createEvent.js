var vagantApp = window.vagantApp || {};
vagantApp.event = vagantApp.event || {};

vagantApp.event.CreateEvent = function () {
    var self = this;
};

$(function () {
    ko.applyBindings(new vagantApp.event.CreateEvent());
});