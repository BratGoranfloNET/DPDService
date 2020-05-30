(function ($, admin) {

	'use strict';

	$(function () {

		var $calendar = $('#sidebarCalendar');

		var calendarOptions = {
			clearBtn: true,
			todayBtn: 'linked',
			toggleActive: true
		};

		$calendar.datepicker(calendarOptions).on('changeDate', function (e) {

			var date = e.date;

			$('li.calendar-event-item').removeClass('hidden');

			if (!date)
				return;

			var day = date.getDate();
			var month = date.getMonth() + 1;
			var fullYear = date.getFullYear();

			$('li.calendar-event-item').each(function () {

				var $item = $(this);

				var itemDay = $item.data('day');
				var itemMonth = $item.data('month');
				var itemFullYear = $item.data('full-year');

				if (itemDay != day || itemMonth != month || itemFullYear != fullYear) {
					$item.addClass('hidden')
				}

			});

		});

		$calendar.data('datepicker').picker.addClass('datepicker-dark');

	});

}).apply(this, [jQuery, window.admin]);
