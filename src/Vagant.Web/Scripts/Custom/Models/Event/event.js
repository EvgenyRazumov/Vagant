var vagantApp = window.vagantApp || {};
vagantApp.event = vagantApp.event || {};

vagantApp.event.EventPage = function () {
    var self = this;
};

$(function () {
    ko.applyBindings(new vagantApp.event.EventPage());
});