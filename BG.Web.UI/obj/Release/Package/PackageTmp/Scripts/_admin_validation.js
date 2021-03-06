(function ($, admin) {

	'use strict';

	var getForm = function (formId) {

		var $form = $(formId);

		

		if (!$form.length) {
			console.log('Attempt to validate unknown form');
			return;
		}

		

		return $form;

	}

	var context = {

		init: function (formId, validatorOptions) {

			if (!$.validator) {
				console.log('Error! Validation scripts may be missing!');
				return;
			}

			var $form = getForm(formId);

			var validator = $.data($form[0], 'validator');

			if (validator) {

				var config = validator.settings;

				config.errorClass = 'error';
				config.errorElement = 'label';

				config.success = function (element) {

					var $placement = $(element).closest('.form-group');

					if ($placement.get(0)) {
						$placement.removeClass('has-error');
					}

					element.remove();

				};

				config.highlight = function (element) {

					var $placement = $(element).closest('.form-group');

					if ($placement.get(0)) {
						$placement.removeClass('has-success').addClass('has-error');
					}

					$(document).find('.feedback-validation').addClass('hidden');

				};

				config.unhighlight = function (element) {

					$(element).parent().removeClass('has-error').find('label.error').remove();

				};

				config.errorPlacement = function (error, element) {

					var placement = element.closest('.input-group');

					if (element.is(':checkbox')) {
						placement = element.closest('div');
					}

					if (!placement.get(0)) {
						placement = element;
					}

					if (error.text() !== '') {
						placement.after(error);
					}

				};

				config.submitHandler = function (form) {

					$(document).find('.feedback-validation').addClass('hidden');

					form.submit();
				}
			}

		}

	};

	// Expose context
	$.extend(admin, {
		validation: context
	});

}).apply(this, [jQuery, window.admin]);

