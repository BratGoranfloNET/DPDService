(function ($, admin) {

	'use strict';

	// Init
	$(function () {

		$('div.feedback-messages div').each(function () {

			var type = $(this).data("type");
			var content = $(this).data("content");
			var title = $(this).data("title");

			admin.notify.show(type, title, content);

		});

	});

}).apply(this, [jQuery, window.admin]);
