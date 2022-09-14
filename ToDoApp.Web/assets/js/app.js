define(['widgetsLoader', 'router'], function (widgetsLoader, router) {

	function start() {
		router.start();
		widgetsLoader.startAllUsersDropdown();
	}

	return {
		start,
	}
});
