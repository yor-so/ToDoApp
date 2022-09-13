define(['widgetsLoader'], function (widgetsLoader) {

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
			widgetsLoader.startAllTasksGrid();
		});

		router.route('/task/create', function () {
			app.html('');
			createTaskLayout.render(app);
			widgetsLoader.startCreateTaskForm();
		});

		router.route('/task/edit/:id', function (id) {
			app.html('');
			editTaskLayout.render(app);
			widgetsLoader.startEditTaskForm(id);
		});
	}


	$(function () {
		setRoutes();
		router.start();
		router.navigate('/task')
	});



	return {
		getRouter,
	}
});
