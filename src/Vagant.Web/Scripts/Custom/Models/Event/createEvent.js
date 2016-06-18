var vagantApp = window.vagantApp || {};
vagantApp.event = vagantApp.event || {};

vagantApp.event.CreateEvent = function () {
    var self = this;

    //var player = new vagantApp.sound.SoundCloudPlayer();
    //player.init();
};

$(function () {
    ko.applyBindings(new vagantApp.event.CreateEvent());
});