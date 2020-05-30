(function ($, admin) {

	'use strict';

	var options = {
		formId: '#loginForm'
	};

	// Init
	$(function () {

		admin.validation.init(options.formId);

	});

}).apply(this, [jQuery, window.admin]);
