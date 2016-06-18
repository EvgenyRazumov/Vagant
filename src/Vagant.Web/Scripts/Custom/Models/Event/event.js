var vagantApp = window.vagantApp || {};
vagantApp.event = vagantApp.event || {};

vagantApp.event.Event = function () {
    var self = this;
};

$(function () {
    ko.applyBindings(new vagantApp.event.Event());
});