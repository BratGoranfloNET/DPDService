(function ($, admin) {

    
	'use strict';

	var options = {
	    tableId: '#articleTable',
		deleteDialogId: '#articleDeleteDialog',
		deleteUrlTemplate: '/article/{itemId}/delete'
		
	};

	var tableOptions = {	    
	        //paging: true     
	};

	// Init
	$(function () {

	    var $table = admin.tables.create(options.tableId, tableOptions);
                     
		//$('#categoriesTable').DataTable({
	    //paging: true
	    //} );


		// Edit
		$(options.tableId).on('click', 'a.edit', function (e) {

			e.preventDefault();
			e.stopPropagation();

			location.href = $(this).data('edit-url');

		});

		// Delete
		$(options.tableId).on('click', 'a.delete', function (e) {

			e.preventDefault();
			e.stopPropagation();

			var $a = $(this);
			var $row = $(this).closest('tr');

			// Modal
			$.magnificPopup.open({
				modal: true,
				preloader: false,
				items: {
					type: 'inline',
					src: options.deleteDialogId
				},
				callbacks: {

					close: function () {

						$('button.cancel', options.deleteDialogId).off('click');
						$('button.confirm', options.deleteDialogId).off('click');

					},

					open: function () {

						var labelText = $row.data('item-label');

						$('strong.item-label', options.deleteDialogId).text(labelText);

						// Cancel
						$('button.cancel', options.deleteDialogId).on('click', function (e) {
							e.preventDefault();
							$.magnificPopup.close();
						});

						// Confirm
						$('button.confirm', options.deleteDialogId).on('click', function (e) {

							e.preventDefault();

							var itemId = $row.data('item-id');

							var errorMessageTitle = $a.data('msg-error-title');
							var errorMessageContent = $a.data('msg-error-content');

							var successMessageTitle = $a.data('msg-success-title');
							var successMessageContent = $a.data('msg-success-content');

							var deletePath = options.deleteUrlTemplate.replace(/{itemId}/g, itemId);

							$.post(deletePath)
								.done(function () {
									// Use the 'page' parameter to
									// avoids recalculating sort and paging
									$table.row($row.get(0)).remove().draw('page');
									admin.notify.success(successMessageTitle, successMessageContent);
								})
								.fail(function () {
									admin.notify.error(errorMessageTitle, errorMessageContent);
								})
								.always(function () {
									$.magnificPopup.close();
								});

						});

					}
				}
			});

		});

	});

}).apply(this, [jQuery, window.admin]);
