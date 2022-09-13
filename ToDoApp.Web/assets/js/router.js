define([], function () {

	var router = new kendo.Router();
	var allTasksLayout = new kendo.Layout('<div id="all-tasks-view" class="row"><h2>All Tasks</h2><div id="all-tasks"></div></div>');
	var createTaskLayout = new kendo.Layout('<div id="create-task-view" class="row"><h2>Create Task</h2><form id="create-task"></form></div>');
	var editTaskLayout = new kendo.Layout('<div id="edit-task-view" class="row"><h2>Edit Task</h2><form id="edit-task"></form></div>');

	function getRouter() {
		return router;
	}

	function setRoutes() {
		router.route("/tasks", function () {
			/*layout.showIn("#content", index);*/
		});

		router.route("/task/create", function () {
			/*layout.showIn("#content", index);*/
		});

		router.route("/task/edit/:id", function () {
			/*layout.showIn("#content", detail);*/
		});
	}

	function startRoutes() {
		router.bind("init", function () {
			allTasksLayout.render($("#app"));
		});
	}

	$(function () {
		setRoutes();
		router.start();
	});



	return {
		getRouter,
	}
});
