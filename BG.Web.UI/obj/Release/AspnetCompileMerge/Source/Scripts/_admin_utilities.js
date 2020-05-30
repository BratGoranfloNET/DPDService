(function ($, admin) {

	'use strict';

	var defaults = { };

	var context = {

		getModelStateMessages: function (modelState) {

			var messages = [];

			$.each(modelState, function (fieldIdx, item) {
				$.each(item.errors, function (errorsIdx, error) {
					messages.push(error.errorMessage);
				});
			});

			return messages;
		}

	};

	// Expose to scope
	$.extend(admin, {
		utilities: context
	});

}).apply(this, [jQuery, window.admin]);
