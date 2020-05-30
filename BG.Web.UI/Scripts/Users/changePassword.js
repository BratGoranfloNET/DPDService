(function ($, admin) {

	'use strict';

	var options = {
		formId: '#changePasswordForm'
	};

	// Init
	$(function () {

		admin.validation.init(options.formId);

	});

}).apply(this, [jQuery, window.admin]);
