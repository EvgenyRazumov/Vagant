var vagantApp = window.vagantApp || {};
vagantApp.event = vagantApp.event || {};

vagantApp.event.EventListItem = function () {
    var self = this;

    //#region Properties
    self.title = ko.observable('');
    self.id = ko.observable('');
    self.logoUrl = ko.observable('');

    self.instruments = new vagantApp.event.EventInstrumentModel();
    //#endregion

    //#region Computed
    self.eventDetailsPageUrl = ko.computed(function(){
        var prefixUrl = vagantAppParams ? vagantAppParams.gotoEventsDetailsUrl : '';
        return prefixUrl + '?id=' + self.id();
    });
    //#endregion

    //#region Public functions
    self.loadData = function (dataObject) {
        if (dataObject) {
            self.id(dataObject.eventId);
            self.title(dataObject.title);
            self.logoUrl(dataObject.logoUrl);

            self.instruments.loadData(dataObject.instruments);
        }
    };

    self.play = function () {

    };

    self.pause = function () {

    };

    self.open = function () {
        location = self.eventDetailsPageUrl();
    };
    //#endregion
};