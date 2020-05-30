(function ($, admin) {

	'use strict';

	var options = {
		tableId: '#usersTable'
	};

	// Init
	$(function () {

		var $table = admin.tables.create(options.tableId);

        $table.order([0, 'desc']).draw(); 

		// Edit
		$(options.tableId).on('click', 'a.edit', function (e) {

			e.preventDefault();
			e.stopPropagation();

			location.href = $(this).data('edit-url');

		});

	});

}).apply(this, [jQuery, window.admin]);
