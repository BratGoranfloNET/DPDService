(function ($, admin) {

	'use strict';

	var options = {
		formId: '#contactselectModalForm',
		modal: {
			actionUrl: '/contacts/modalselect',
            wrapperId: '#contactselectModalWrapper',
			triggerSelector: '.contactselect-modal-opener',
            dismissActionSelector: '.contactselect-modal-dismiss',
            confirmActionSelector: '.contactselect-modal-confirm',
			focusedElementSelector: 'input[name="name"]'
           
		},		
    };
        

    var options_contactselect = {
	    tableId: '#contactselectTable',
	    //deleteDialogId: '#tendersDeleteDialog',
	    //deleteUrlTemplate: '/tenders/{itemId}/delete'
	};


	// Init
	$(function () {

        var $table2 = admin.tables.create(options_contactselect.tableId);

	    //var SelectedId = 0;

	    //var TenderId = $('#tenderid').val();

        $('#contactselectTable tbody').on( 'click', 'tr', function () {

	        //SelectedId = $(this).attr('data-item-id');	        

	        //console.log( SelectedId);

	        if ($(this).hasClass('contact-selected')) {

                $(this).removeClass('contact-selected');

	         }

	        else {

                $table2.$('tr.contact-selected').removeClass('contact-selected');

                $(this).addClass('contact-selected');

	            }

                } );

        $('#contactselect-modal-confirm').click(function () {
                                    
            var rowId = $table2.row('.contact-selected').data().DT_RowId;

            console.log(rowId);         

            console.log($table2.row('.contact-selected').data()[1]);

            $('#offercontact').val(rowId);

            $('#offercontactname').html($table2.row('.contact-selected').data()[1]);

            $('#offercontactname-label').removeClass('hide');

            $('#btn-offer-add').addClass('btn-primary').prop('disabled', false);

            $.magnificPopup.close(); 

            //admin.notify.success('!', 'Поставщик выбран');
            	       
	    } );

		//admin.validation.init(options.formId);

		$(options.modal.triggerSelector).magnificPopup({


			modal: true,
			type: 'inline',
			preloader: false,
			closeBtnInside: true,
			
            

			// Inital focused element
			focus: options.modal.focusedElementSelector,

			// Disable mobile focus auto zoom.
			callbacks: {
				beforeOpen: function () {
					if ($(window).width() < 700) {
						this.st.focus = false;
					} else {
						this.st.focus = options.modal.focusedElementSelector;
					}
				}
			}
		});


		$(options.modal.wrapperId).on('click', options.modal.dismissActionSelector, function (e) {
			e.preventDefault();
			$.magnificPopup.close();
		});

		$(options.modal.wrapperId).on('click', options.modal.confirmActionSelector, function (e) {

			//e.preventDefault();

			//var isValidForm = $(options.formId).valid();

			//if (isValidForm) {

				//var formData = $(options.formId).serialize();

				//$.post(options.modal.actionUrl, formData).done(function (contact) {

				//	admin.events.trigger('dot:contact-created', [contact]);

				//	$.magnificPopup.close();

				//}).fail(function () {

				//	var $modalWrapper = $(options.modal.wrapperId);
				//	var modalErrorMessageTitle = $modalWrapper.data('msg-error-title');
				//	var modalErrorMessageContent = $modalWrapper.data('msg-error-content');

				//	admin.notify.error(msg.title, msg.content);

				//});

			//}

		});
        
    });


}).apply(this, [jQuery, window.admin]);
