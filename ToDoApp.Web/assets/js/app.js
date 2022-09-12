define([], function () {

	const originUrl = new URL(location.href).origin;

	/**
	 * 
	 * */
	function startAllUsersDropdown() {
		$('#users-dropdown').kendoDropDownList({
			index: 0,
			dataTextField: 'FullName',
			dataValueField: 'Id',
			dataSource: {
				type: 'json',
				transport: {
					read: `${originUrl}/api/user/`,
				}
			},
		});
	}

	/**
	 * 
	 * */
	function startAllTasksGrid() {
		$('#all-tasks').kendoGrid({
			dataSource: {
				type: 'json',
				transport: {
					read: `${originUrl}/api/task/`
				},
				//schema: {
				//	data: data
				//}
			},
			columns: [
				{ field: 'IsCompleted', title: 'Is completed?' },
				{ field: 'Title', title: 'Title' },
				{ field: 'EstimatedHours', title: 'Estimated Hours' },
				{ field: 'AppUserDto.FullName', title: 'Created By' },
			]
		});
	}

	function start() {
		startAllUsersDropdown();
		startAllTasksGrid();
	}

	return {
		start
	}
});
