(function ($, admin) {

	'use strict';

	var options = {
		formId: '#resetPasswordForm'
	};

	// Initializer
	$(function () {

		admin.validation.init(options.formId);

	});

}).apply(this, [jQuery, window.admin]);
