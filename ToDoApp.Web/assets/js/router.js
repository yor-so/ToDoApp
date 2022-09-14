define(['widgetsLoader'], function (widgetsLoader) {
	var router = new kendo.Router();

	var allTasksViewModel = kendo.observable({
		title: 'All Tasks',
		init: function () {
			widgetsLoader.startAllTasksGrid();
		},
	})

	var createTaskViewModel = kendo.observable({
		title: 'Create Task',
		init: function () {
			widgetsLoader.startCreateTaskForm();
		}
	})

	var editTaskViewModel = kendo.observable({
		title: 'Edit Task',
		init: function (id) {
			widgetsLoader.startEditTaskForm(id);
		}
	})

	function setRoutes() {
		const app = $('#app');
		var layout = new kendo.Layout('<div id="app-content"></div>');
		layout.render(app);


		router.route('/task', function () {
			var allTaskKendoView = new kendo.View('all-tasks-template', {
				model: allTasksViewModel,
				init: allTasksViewModel.init.bind(allTasksViewModel),
			})

			layout.showIn('#app-content', allTaskKendoView);
		});
		
		router.route('/task/create', function () {
			var createTaskKendoView = new kendo.View('create-task-template', {
				model: createTaskViewModel,
				init: createTaskViewModel.init.bind(createTaskViewModel),
			})

			layout.showIn('#app-content', createTaskKendoView);
		});

		router.route('/task/edit/:id', function (id) {
			editTaskViewModel.set('Id', id);
			var editTaskKendoView = new kendo.View('edit-tasks-template', {
				model: editTaskViewModel,
				init: function (event) {
					editTaskViewModel.init(event.sender.model.Id);
				},
			})

			layout.showIn('#app-content', editTaskKendoView);
		});
	}

	function start() {
		setRoutes();
		router.start();
		router.navigate('/task')
	}

	return {
		start
	}
});
