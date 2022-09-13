define([], function () {

	/**
	 * 
	 * */
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

	/**
	 * Sets the color of the 'all tasks' grid rows depending on the IsComplete model value.
	 * @param {any} e The callback object.
	 */
	function grid_dataBound(e) {
		var items = e.sender.items();
		items.each(function (index) {
			var dataItem = grid.dataItem(this);
			if (dataItem.IsCompleted) {
				this.css("background-color", "#CEFFD5");
			}
			else {
				this.css("background-color", "#FFCACB");
			}
		})
	}

	/**
	 * 
	 * */
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
				{ title: 'Action', field: 'Id', template: '<a class="k-button k-button-md k-rounded-md k-button-solid k-button-solid-base" href=/\\#/task/edit/#=Id#>Edit</a>'},
				{ field: 'IsCompleted', title: 'Is Completed?' },
				{ field: 'Title', title: 'Title' },
				{ field: 'EstimatedHours', title: 'Estimated Hours' },
				{ field: 'AppUserDto.FullName', title: 'Created By' },
			],
			height: 400,
			scrollable: true,
			sortable: true,
		});
	}

	/**
	 * 
	 * */
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
			submit: function (ev) {
				ev.model.AppUserId = $('#users-dropdown').data('kendoDropDownList').value();

				$.ajax({
					type: 'POST',
					url: '/api/task',
					data: ev.model,
					success: function () {
						var form = $("#create-task").getKendoForm();
						form.clear();
					}
				});
			}
		})
	}

	function startEditTaskForm(id) {
		$('#edit-task').kendoForm({
			formData: {
				Id: id,
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
					editorOptions: {
						items: ['Yes'],
					}
				}],
			submit: function (ev) {
				$.ajax({
					type: 'PUT',
					url: `/api/task/${id}`,
					data: ev.model,
					success: function () {
						var form = $("#create-task").getKendoForm();
						form.clear();
					}
				});
			}
		})
	}

	function start() {
		startAllUsersDropdown();
		setRoutes()
	}

	/*Router.js here *************************/
	var router = new kendo.Router();
	var allTasksLayout = new kendo.Layout('<div id="all-tasks-view" class="row"><h2>All Tasks</h2><div id="all-tasks"></div></div>');
	var createTaskLayout = new kendo.Layout('<div id="create-task-view" class="row"><h2>Create Task</h2><form id="create-task"></form></div>');
	var editTaskLayout = new kendo.Layout('<div id="edit-task-view" class="row"><h2>Edit Task</h2><form id="edit-task"></form></div>');

	function getRouter() {
		return router;
	}

	function setRoutes() {
		const app = $('#app');

		router.route('/task', function () {
			app.html('');
			allTasksLayout.render(app);
			startAllTasksGrid();
		});

		router.route('/task/create', function () {
			app.html('');
			createTaskLayout.render(app);
			startCreateTaskForm();
		});

		router.route('/task/edit/:id', function (id) {
			app.html('');
			editTaskLayout.render(app);
			startEditTaskForm(id);
		});

		$(function () {
			router.start();
			router.navigate('/task')
		});
	}

	return {
		start,
		getRouter
	}
});
