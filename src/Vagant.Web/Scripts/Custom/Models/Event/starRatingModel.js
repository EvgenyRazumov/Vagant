var vagantApp = window.vagantApp || {};
vagantApp.event = vagantApp.event || {};

vagantApp.event.StarRating = function () {
    var self = this;

    self.ratingValue = ko.observable(0);

    self.ratingChaged = function (element, newValue) {
        $(element).val(4);
        $(element).rating('refresh', {
            disabled: true
        });
    };
};