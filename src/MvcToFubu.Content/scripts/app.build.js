({
	appDir: "../",
	baseUrl: "scripts/",
	dir: "../../app-build",
	paths: {
		underscore: "wrapper/require_underscore"
	},
	optimize: "closure",
	modules: [
		{
			name: "boot"
		}
	]
})