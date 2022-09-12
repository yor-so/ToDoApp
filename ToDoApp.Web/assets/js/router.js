define([], function () {
	function start() {
		var router = new kendo.Router();

		router.route("/", function () {
			layout.showIn("#content", index);
		});

		router.route("/detail", function () {
			layout.showIn("#content", detail);
		});
	}

	return {
		start
	}
});
