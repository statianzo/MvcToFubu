define(['util/content-builder'], function (builder) {
	var exports = {}
	exports.init = function () {
		builder.execute();
	};
	return exports;
});
