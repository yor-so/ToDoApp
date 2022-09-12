define([], function () {
	function start() {
		var router = new kendo.Router();

		router.route("/task/create", function () {
			layout.showIn("#content", index);
		});

		router.route("/task/edit/:id", function () {
			layout.showIn("#content", detail);
		});

		$(function () {
			router.start();
		});
	}

	return {
		start
	}
});
