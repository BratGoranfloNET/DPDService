(function ($, admin) {

	'use strict';

	var context = {

		reset: function () {
			NProgress.set(0);
		},

		set: function (percentage) {
			NProgress.set(percentage);
		},

		increment: function () {
			NProgress.inc();
		},

		complete: function () {
			NProgress.done();
		}

	};

	// Expose to scope
	$.extend(admin, {
		progress: context
	});

}).apply(this, [jQuery, window.admin]);
