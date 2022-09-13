define(['widgetsLoader', 'router'], function (widgetsLoader) {

	function start() {
		widgetsLoader.startAllUsersDropdown();
	}

	return {
		start,
	}
});
