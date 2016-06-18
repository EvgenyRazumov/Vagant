var vagantApp = window.vagantApp || {};
vagantApp.event = vagantApp.event || {};

vagantApp.event.EventGridManager = function () {
    var self = this;

    //#region Fields
    var loadedEvents = null;

    //#endregion

    //#region Properties
    self.eventList = new vagantApp.event.EventList();
    self.instrumentFilter = new vagantApp.event.InstrumentFilter();
    //#endregion

    //#region Private functions
    var updateVisibleEventsList = function(dateFilter, instrumentsFilter){
        var itemsToLoad = [];
        if (loadedEvents && loadedEvents.length > 0) {
            ko.utils.arrayForEach(loadedEvents, function (eventObject) {
                if (dateFilter && typeof dateFilter === 'function') {
                    if (!dateFilter(eventObject)) {
                        return;
                    }
                }

                if (instrumentsFilter && typeof instrumentsFilter === 'function') {
                    if (!instrumentsFilter(eventObject)) {
                        return;
                    }
                }

                itemsToLoad.push(eventObject);
            });
        }

        self.eventList.loadData(itemsToLoad);
    };

    var handleDateOrInstrumentFilterChange = function () {
        var dateFilterFunction = null;
        var instrumentFilterFunction = self.instrumentFilter.getFilter();

        updateVisibleEventsList(dateFilterFunction, instrumentFilterFunction);
    }
    //#endregion

    //#region Public functions
    self.init = function () {
        self.instrumentFilter.init(handleDateOrInstrumentFilterChange);
    };

    self.loadEvents = function (events) {
        
    };
    //#endregion
};