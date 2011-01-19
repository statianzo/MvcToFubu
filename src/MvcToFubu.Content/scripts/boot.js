require({
	baseUrl: "/content/scripts/",
	paths: {
		underscore: "wrapper/require_underscore"
	}
},
	["util/store"],
	function (store) {
		if (!store.get('whoa')) {
			store.set('whoa', new Date());
		}
		else {
			alert(store.get('whoa'));
		}
	});