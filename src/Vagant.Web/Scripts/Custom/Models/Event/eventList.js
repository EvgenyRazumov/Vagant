var vagantApp = window.vagantApp || {};
vagantApp.event = vagantApp.event || {};

vagantApp.event.EventList = function () {
    var self = this;

    //#region Properties
    self.items = ko.observableArray([]);
    //#endregion

    //#region Private functions
    //#endregion

    //#region Public functions
    self.loadData = function (events) {
        self.items.removeAll();
        if (events) {
            ko.utils.arrayForEach(events, function (eventObject) {
                var newItem = new vagantApp.event.EventListItem();
                newItem.loadData(eventObject);
                self.items.push(newItem);
            });
        }
    };
    //#endregion
};