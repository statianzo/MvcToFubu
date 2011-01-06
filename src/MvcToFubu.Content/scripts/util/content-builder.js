define(['underscore', './cookie', './json'], function (_, cookie, JSON) {
	var exports = {};
	var replaceContent = function (element, content) {
		element.html(content);
		element.css('visibility', 'visible');
	};
	exports.execute = function () {
		$('[data-placeholder-uri]').each(function () {
			var element = $(this);
			var settings = {
				uri: element.data('placeholder-uri'),
				load: element.data('placeholder-load')
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
			var url = "http://fubutomvc.com/content/" + settings.uri;
			$.get(url, function (resp) {
				replaceContent(element, resp);
			});
		});
	};

	return exports;
});