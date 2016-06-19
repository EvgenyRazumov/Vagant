var vagantApp = window.vagantApp || {};
vagantApp.event = vagantApp.event || {};

vagantApp.event.EventPage = function () {
    var self = this;
    self.rating = new vagantApp.event.StarRating();
};

$(function () {
    ko.applyBindings(new vagantApp.event.EventPage());
});