(function ($, admin) {

	'use strict';

	$(function () {

		var $calendar = $('#eventsCalendar');
		var regionLocale = $calendar.data('region');

		if ($.fullCalendar.locales[regionLocale] == null){
			regionLocale = regionLocale.split('-')[0];
		}

		$calendar.fullCalendar({
			locale: regionLocale,
			header: {
				left: 'prev,next today',
				center: 'title',
				right: 'month,agendaWeek,agendaDay,listMonth'
			},
			themeButtonIcons: {
				prev: 'fa fa-caret-left',
				next: 'fa fa-caret-right',
			},
			events: {
				url: '/calendar/events/feed'
			}
		});

		// FIX INPUTS TO BOOTSTRAP VERSIONS
		var $calendarButtons = $calendar.find('.fc-header-right > span');

		$calendarButtons.filter('.fc-button-prev, .fc-button-today, .fc-button-next')
						.wrapAll('<div class="btn-group mt-sm mr-md mb-sm ml-sm"></div>')
						.parent()
						.after('<br class="hidden"/>');

		$calendarButtons.not('.fc-button-prev, .fc-button-today, .fc-button-next')
						.wrapAll('<div class="btn-group mb-sm mt-sm"></div>');

		$calendarButtons.attr({ 'class': 'btn btn-sm btn-default' });

	});

}).apply(this, [jQuery, window.admin]);
