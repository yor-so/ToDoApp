define([], function () {
	function startUsersDropdown() {
		$('#users-dropdown').kendoDropDownList({
			index: 0,
			dataTextField: "FullName",
			dataValueField: "Id",
			dataSource: {
				type: "json",
				transport: {
					read: "https://localhost:44397/api/user/",
				}
			},
		});
	}

	function start() {
		startUsersDropdown();
	}

	return {
		start
	}
});
