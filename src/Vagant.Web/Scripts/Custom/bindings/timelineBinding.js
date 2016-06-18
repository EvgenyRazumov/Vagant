(function ($, ko) {

    var timeline = null;

    function setTimeline(element, valueAccessor, allBindings) {
        var options = valueAccessor();

        if (options.dates && options.callback) {
            var unvrappedDatesArray = ko.unwrap(options.dates);
            timeline = $(element).jqtimeline({
                events: unvrappedDatesArray,
                numYears: 3,
                startYear: 2014,
                click: options.callback
            });
        }
    }

    function updateTimeline(element, valueAccessor, allBindings) {
    }

    ko.bindingHandlers.timeline = {
        init: function (element, valueAccessor, allBindings) {
            setTimeline(element, valueAccessor, allBindings);
        },
        update: function (element, valueAccessor, allBindings) {
            updateTimeline(element, valueAccessor, allBindings);
        }
    };

})(jQuery, ko);