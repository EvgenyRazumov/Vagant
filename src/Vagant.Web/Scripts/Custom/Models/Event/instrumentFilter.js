var vagantApp = window.vagantApp || {};
vagantApp.event = vagantApp.event || {};

vagantApp.event.InstrumentFilter = function (changeHandler) {
    var self = this;

    //#region Fields
    var filterChangeHandler = null;
    //#endregion

    //#region Properties
    self.isGuitarUsed = ko.observable(false);
    self.isViolinUsed = ko.observable(false);

    self.isVocalUsed = ko.observable(false);
    //#endregion

    //#region Private functions
    var getFilterFunction = function () {
        var isGuitarRequired = self.isGuitarUsed();
        var isViolinRequired = self.isViolinUsed();
        var isVocalRequired = self.isVocalUsed();

        var filterFunction = function (eventObject) {
            if (eventObject) {
                if (isGuitarRequired && !eventObject.isGuitarUsed) {
                    return false;
                }

                if (isViolinRequired && !eventObject.isViolinUsed) {
                    return false;
                }

                if (isVocalRequired && !eventObject.isVocalUsed) {
                    return false;
                }

                return true;
            }
            return false;
        };
        return filterFunction;
    };

    var handleFilterStateChange = function () {
        if (changeHandler && typeof changeHandler === 'function') {
            changeHandler();
        }
    };
    //#endregion

    //#region Subscribers
    self.isGuitarUsed.subscribe(handleFilterStateChange);
    self.isGuitarUsed.subscribe(handleFilterStateChange);
    self.isVocalUsed.subscribe(handleFilterStateChange);
    //#endregion

    //#region Public functions
    self.initChangeHandler = function (handler) {
        filterChangeHandler = handler ? handler : null;
    };

    self.getFilter = function () {
        return getFilterFunction();
    };
    //#endregion
};