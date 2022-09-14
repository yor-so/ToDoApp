define([], function () {
	const RBG_GREEN = '#CEFFD5';
	const RBG_RED = '#FFCACB';

	function startAllUsersDropdown() {
		$('#users-dropdown').kendoDropDownList({
			index: 0,
			dataTextField: 'FullName',
			dataValueField: 'Id',
			dataSource: {
				transport: {
					read: {
						dataType: 'json',
						url: '/api/user/',
					}
				}
			},
		});
	}

	function startAllTasksGrid() {
		const allTasksGrid = $('#all-tasks');
		allTasksGrid.kendoGrid({
			dataSource: {
				transport: {
					read: {
						dataType: 'json',
						url: '/api/task/',
					}
				},
			},
			columns: [
				{ field: 'Id', title: 'Action', template: '<a class="k-button k-button-md k-rounded-md k-button-solid k-button-solid-base" href=/\\#/task/edit/#=Id#>Edit</a>' },
				{ field: 'IsCompleted', title: 'Is Completed?', template: "\#= IsCompleted ? 'Yes' : 'No' \#" },
				{ field: 'Title', title: 'Title' },
				{ field: 'EstimatedHours', title: 'Estimated Hours' },
				{ field: 'AppUserDto.FullName', title: 'Created By' },
			],
			dataBound: function (e) {
				var items = e.sender.items();
				var dataItems = e.sender.dataItems();
				items.each(function (index) {
					if (dataItems[index].IsCompleted) {
						$(this).css('background-color', RBG_GREEN);
					} else {
						$(this).css('background-color', RBG_RED);
					}
				})
			},
			filterable: {
				mode: "row"
			},
			height: 400,
			scrollable: true,
			sortable: true,
		});
	}

	function startCreateTaskForm() {
		$('#create-task').kendoForm({
			items: [{
				field: 'Title',
				label: 'Title (required)',
				validation: {
					required: true,
					titleLength: function (input) {
						if (!input.is('[name="Title"]')) {
							return true;
						}

						const value = input.val();
						input.attr('data-titleLength-msg', 'Title length must be between 4 and 50');

						return value.length >= 4 && value.length <= 50;
					},
					hint: "Between 3 and 50 characters"
				}
			},
			{
				field: 'EstimatedHours',
				label: 'Estimated Hours (required)',
				validation: {
					required: true,
					hoursRange: function (input) {
						if (!input.is('[name="EstimatedHours"]')) {
							return true
						}

						const value = parseInt(input.val(), 10);
						input.attr('data-hoursRange-msg', 'Estimated hours must be a number between 1 and 100');

						return typeof value === 'number' && value >= 1 && value <= 100;
					},
				},
				}],
			buttonsTemplate: "<button>Submit</button>",
			submit: function (event) {
				event.preventDefault();
				event.model.AppUserId = $('#users-dropdown').data('kendoDropDownList').value();
				$.post('/api/task', event.model, function () {
					alert('Task created successfully.');
				});
			}
		})
	}

	function startEditTaskForm(id) {
		$.get(`/api/task/${id}`, function (data) {
			$('#edit-task').kendoForm({
				formData: {
					Id: data.Id,
					Title: data.Title,
					EstimatedHours: data.EstimatedHours,
					IsCompleted: data.IsCompleted,
					AppUserId: data.AppUserId,
				},
				items: [
					{
						field: 'Title',
						label: 'Title (required)',
						validation: {
							required: true,
							titleLength: function (input) {
								if (!input.is('[name="Title"]')) {
									return true;
								}

								const value = input.val();
								input.attr('data-titleLength-msg', 'Title length must be between 4 and 50');

								return value.length >= 4 && value.length <= 50;
							},
							hint: "Between 3 and 50 characters"
						}
					},
					{
						field: 'EstimatedHours',
						label: 'Estimated Hours (required)',
						validation: {
							required: true,
							hoursRange: function (input) {
								if (!input.is('[name="EstimatedHours"]')) {
									return true
								}

								const value = parseInt(input.val(), 10);
								input.attr('data-hoursRange-msg', 'Estimated hours must be a number between 1 and 100');

								return typeof value === 'number' && value >= 1 && value <= 100;
							},
						},
					},
					{
						field: 'IsCompleted',
						label: 'Is Completed?',
						editor: 'Switch',
					}],
				buttonsTemplate: "<button>Submit</button>",
				submit: function (event) {
					event.preventDefault();
					$.ajax({
						type: 'PUT',
						url: `/api/task/${id}`,
						data: event.model,
						success: function () {
							alert("Task updated successfully.");
						},
					});
				}
			})
		})
	}

	return {
		startAllUsersDropdown,
		startAllTasksGrid,
		startCreateTaskForm,
		startEditTaskForm,
	}
});