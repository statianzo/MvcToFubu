require({
	baseUrl: "/content/scripts/",
	paths: {
		underscore: "wrapper/require_underscore"
	}
},
	["main"],
	function (main) {
		require.ready(function () {
			main.init();
		});
	});