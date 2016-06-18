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

    //#region Public functions
    self.loadData = function (dataObject) {
        if (dataObject) {
            self.id(dataObject.eventId);
            self.title(dataObject.title);
            self.logoUrl(dataObject.logoUrl);

            self.instruments.loadData(dataObject.instruments);
        }
    };
    //#endregion
};