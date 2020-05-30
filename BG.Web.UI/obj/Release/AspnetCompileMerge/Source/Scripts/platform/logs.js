(function ($, admin) {

	'use strict';

	// Init
	$(function () {

		$('.log-refresh').bind('click', function () {

			var $item = $(this);

			document.location.href = $item.data('url');

		});

		$('a.log-details').magnificPopup({
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
