(function ($, admin) {

	'use strict';

	var options = {
		formId: '#registerForm'
	};

	// Init
	$(function () {

		admin.validation.init(options.formId);

		$('.terms-dialog-action').magnificPopup({
			type: 'inline',
			fixedContentPos: false,
			fixedBgPos: true,
			overflowY: 'auto',
			closeBtnInside: true,
			preloader: false,
			midClick: true,
			removalDelay: 300,
			mainClass: 'my-mfp-zoom-in'
		});

	});

}).apply(this, [jQuery, window.admin]);
