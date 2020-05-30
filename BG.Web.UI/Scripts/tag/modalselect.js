(function ($, admin) {
       

	'use strict';

	var options = {
		formId: '#tagselectModalForm',
		modal: {
			actionUrl: '/tags/modalselect',
            wrapperId: '#tagselectModalWrapper',
			triggerSelector: '.tagselect-modal-opener',
            dismissActionSelector: '.tagselect-modal-dismiss',
            confirmActionSelector: '.tagselect-modal-confirm',
            focusedElementSelector: 'input[name="name"]'
           
		},		
    };
        

    var options_tagselect = {
	    tableId: '#tagselectTable',
	    //deleteDialogId: '#tendersDeleteDialog',
	    //deleteUrlTemplate: '/tenders/{itemId}/delete'
	};


	// Init
	$(function () {

        var $table2 = admin.tables.create(options_tagselect.tableId);


        //console.log(admin);

	    //var SelectedId = 0;

	    //var TenderId = $('#tenderid').val();

       

        $('#tagselectTable tbody').on( 'click', 'tr', function () {

	        //SelectedId = $(this).attr('data-item-id');	        

	        //console.log( SelectedId);

	        if ($(this).hasClass('tag-selected')) {

                $(this).removeClass('tag-selected');

	         }

	        else {

                $table2.$('tr.tag-selected').removeClass('tag-selected');

                $(this).addClass('tag-selected');

	            }

                } );

        $('#tagselect-modal-confirm').click(function () {
                                    
            var rowId = $table2.row('.tag-selected').data().DT_RowId;

            console.log(rowId);         

            console.log($table2.row('.tag-selected').data()[1]);

            


            ///////////
            var addTagToArticleUrlTemplate = '/article/{articleId}/{tagId}/addtag';

            var itemId = $('#ArticleId').val();

            //alert(rowId);
            //alert(itemId);


            var addTagPath = addTagToArticleUrlTemplate.replace(/{articleId}/g, itemId);
                addTagPath = addTagPath.replace(/{tagId}/g, rowId);
            
            console.log(addTagPath);

            var errorMessageTitle = 'Ошибка !';
            var errorMessageContent = ' НЕ удалось добавить тэг к статье !';

            var successMessageTitle = 'Успешно !';
            var successMessageContent = 'Тэг добавлен к статье !';

            $.post(addTagPath)
                .done(function () {
                   // Use the 'page' parameter to
                   // avoids recalculating sort and paging
                   // $table.row($row.get(0)).remove().draw('page');
                    admin.notify.success(successMessageTitle, successMessageContent);



                })
                .fail(function () {
                    admin.notify.error(errorMessageTitle, errorMessageContent);
                })
                .always(function () {
                    //$.magnificPopup.close();

                    var editTemplate = '/article/{itemId}/edit';
                    var editUrl = editTemplate.replace(/{itemId}/g, itemId);

                    console.log(editUrl);

                    setTimeout(function () {
                        location.href = editUrl;
                    }, 1000);

                });








            $('#offertag').val(rowId);

            $('#offertagname').html($table2.row('.tag-selected').data()[1]);

            $('#offertagname-label').removeClass('hide');

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

				//$.post(options.modal.actionUrl, formData).done(function (tag) {

				//	admin.events.trigger('dot:tag-created', [tag]);

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
