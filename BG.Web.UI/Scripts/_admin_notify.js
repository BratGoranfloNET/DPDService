(function ($, admin) {

	'use strict';

	var defaults = {
		width: '35%',
		addclass: 'stack-topright',
		stack: {
			"dir1": "down",
			"dir2": "left",
			"firstpos1": 15,
			"firstpos2": 15
		},
		buttons: {
			closer: false,
			sticker: false
		}
	};

	var showAlert = function (type, title, message, options) {

		options = options || {};
		options = $.extend(true, defaults, options);

		var notification = new PNotify({
			title: title,
			text: message,
			type: type,
			buttons: options.buttons,
			addclass: options.addclass,
			stack: options.stack,
			width: options.width
		});

		notification.get().click(function () {
			notification.remove();
		});

	};

	var context = {

		show: function (type, title, message, options) {
			showAlert(type, title, message, options);
		},

		error: function (title, message, options) {
			showAlert('error', title, message, options);
		},

		info: function (title, message, options) {
			showAlert('info', title, message, options);
		},

		success: function (title, message, options) {
			showAlert('success', title, message, options);
		},

		warning: function (title, message, options) {
			showAlert('warning', title, message, options);
		}

	};

	// Expose context
	$.extend(admin, {
		notify: context
	});

}).apply(this, [jQuery, window.admin]);
