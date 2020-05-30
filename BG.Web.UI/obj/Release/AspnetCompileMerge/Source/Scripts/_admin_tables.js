(function ($, admin) {

	'use strict';

	var defaults = {
		"order": [[0, 'asc']],
		"columnDefs": [{
			"targets": 'nosort',
			"orderable": false
		}]
	};

	var context = {

		create: function (tableId, options) {

			options = options || {};
			options = $.extend(true, defaults, options);

			return $(tableId).DataTable(
				options.tableOptions
			);

		}

	 

	};

	// Expose to scope
	$.extend(admin, {
		tables: context
	});

}).apply(this, [jQuery, window.admin]);
