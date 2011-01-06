define(['underscore', './cookie', './json'], function (_, cookie, JSON) {
    var exports = {};
    var replaceContent = function (element, content) {
        element.html(content);
        element.css('visibility', 'visible');
    };
    exports.execute = function () {
        $('div[data-dynamic-uri]')
        .css('visibility', 'hidden')
        .each(function () {
            var element = $(this);
            var settings = {
                uri: element.data('dynamic-uri'),
                load: element.data('dynamic-load')
            };
            if (settings.load) {
                replaceContent(element, 'Loading');
            }
            var match = /\{\w+\}/.exec(settings.uri);
            if (match) {
                var val = cookie(match[0].slice(1, match.length - 2));
                val = val || "";
                settings.uri = settings.uri.replace(match, val);
            }
            var url = "/content/" + settings.uri;
            $.ajax({
                url: url,
                success: function (resp) {
                    replaceContent(element, resp);
                },
                error: function () {
                    element.css('visibility', 'visible');
                }
            });
        });
    };

    return exports;
});