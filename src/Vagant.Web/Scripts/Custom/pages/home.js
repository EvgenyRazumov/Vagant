var vagantApp = window.vagantApp || {};
vagantApp.pages = vagantApp.pages || {};

vagantApp.pages.Home = function () {
    var self = this;

    //#region Properties
    self.gridManager = new vagantApp.event.EventGridManager();
    //#endregion

    //#region Private functions
    //#endregion

    //#region Public functions
    self.init = function (options) {
        self.gridManager.init(options);
    };
    //#endregion
};

$(function () {
    var pageModel = new vagantApp.pages.Home();

    ko.applyBindings(pageModel);

    pageModel.init(vagantAppParams);
});