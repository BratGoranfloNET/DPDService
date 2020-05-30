(function ($, admin) {

    var editor = CKEDITOR.replace('body2', {
        filebrowserBrowseUrl: '/scripts/ckfinder/ckfinder.html',
        filebrowserImageBrowseUrl: '/scripts/ckfinder/ckfinder.html?type=Images',
        filebrowserFlashBrowseUrl: '/scripts/ckfinder/ckfinder.html?type=Flash',
        //filebrowserUploadUrl: '/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Files',
        //filebrowserImageUploadUrl: '/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Images',
        //filebrowserUploadUrl: '/Uploads/images',
        //filebrowserImageUploadUrl: '../Uploads/images',
        filebrowserUploadUrl: '/scripts/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
        filebrowserImageUploadUrl: '/scripts/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
        filebrowserFlashUploadUrl: '/scripts/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'

        //filebrowserWindowWidth: '1000',
        //filebrowserWindowHeight: '700'

        //filebrowserFlashUploadUrl: '/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Flash'
    });
    CKFinder.setupCKEditor(editor, '../');

    






	//'use strict';

	var options = {
	    formId: '#articleForm',
		//contactsSelector: 'select[name=ContactId]',
		upload: {
			actionUrl: '/article/image/upload',
			blobIdSelector: '#imageBlobIdArticle',
            blobNameSelector: '#imageBlobNameArticle',
            triggerSelector: '.upload-image-article',
            fileInputSelector: '#imageFileInputArticle',
            blobThumbPreviewSelector: '#thumbPreviewArticle',
			statusLabelSelector: '.uploading-status-article',
			expectedThumbWidth: 160,
			expectedThumbHeight: 182
		}
    };


    var optionsTagResult = {
        tableId: '#tagResultTable',
        deleteDialogId: '#tagResultDeleteDialog',
        deleteUrlTemplate: '/article/{itemId}/deletetagresult'
    };
    


	// Init
	$(function () {

        var $tableTagResult = admin.tables.create(optionsTagResult.tableId);

        // Delete
        $(optionsTagResult.tableId).on('click', 'a.delete', function (e) {

            e.preventDefault();
            e.stopPropagation();

            var $a = $(this);

            //console.log($a);

            var $row = $(this).closest('tr');

            // Modal
            $.magnificPopup.open({
                modal: true,
                preloader: false,
                items: {
                    type: 'inline',
                    src: optionsTagResult.deleteDialogId
                },
                callbacks: {

                    close: function () {

                        $('button.cancel', optionsTagResult.deleteDialogId).off('click');
                        $('button.confirm', optionsTagResult.deleteDialogId).off('click');

                    },

                    open: function () {

                        var labelText = $row.data('item-label');

                        $('strong.item-label', optionsTagResult.deleteDialogId).text(labelText);

                        // Cancel
                        $('button.cancel', optionsTagResult.deleteDialogId).on('click', function (e) {
                            e.preventDefault();
                            $.magnificPopup.close();
                        });

                        // Confirm
                        $('button.confirm', optionsTagResult.deleteDialogId).on('click', function (e) {

                            e.preventDefault();

                            var itemId = $row.data('item-id');

                            console.log(itemId);

                            var errorMessageTitle = $a.data('msg-error-title');
                            var errorMessageContent = $a.data('msg-error-content');

                            var successMessageTitle = $a.data('msg-success-title');
                            var successMessageContent = $a.data('msg-success-content');

                            var deletePath = optionsTagResult.deleteUrlTemplate.replace(/{itemId}/g, itemId);

                            var itemId = $('#ArticleId').val();

                            console.log(deletePath);

                            $.post(deletePath)
                                .done(function () {
                                    // Use the 'page' parameter to
                                    // avoids recalculating sort and paging
                                    //$table.row($row.get(0)).remove().draw('page');
                                    admin.notify.success(successMessageTitle, successMessageContent);
                                })
                                .fail(function () {
                                    admin.notify.error(errorMessageTitle, errorMessageContent);
                                })
                                .always(function () {
                                    $.magnificPopup.close();
                                    

                                    var editTemplate = '/article/{itemId}/edit';
                                    var editUrl = editTemplate.replace(/{itemId}/g, itemId);
                                    

                                    console.log(editUrl);

                                    setTimeout(function () {
                                        location.href = editUrl;
                                    }, 1000);

                                });

                        });

                    }
                }
            });

        });











        
	    admin.validation.init(options.formId);

	    $('.date-picker').each(function (item) {

	        var $input = $(this);

	        var pickerOptions = {
	            format: $input.data("format")
	        };

	        $input.datepicker(pickerOptions);

	    });



		$(options.upload.triggerSelector).on('click', function (event) {

			event.preventDefault();
			$(options.upload.fileInputSelector).click();

		});

		$(options.upload.fileInputSelector).on('change', function () {

			var file = this.files[0];

			if (file === null)
				return;

			var formData = new FormData($(options.formId)[0]);

			formData.append('expectedThumbWidth', options.upload.expectedThumbWidth);
			formData.append('expectedThumbHeight', options.upload.expectedThumbHeight);

			$.post({
				data: formData,
				processData: false,
				contentType: false,
				url: options.upload.actionUrl,
				xhr: function () {
					var xhrRequest = $.ajaxSettings.xhr();
					if (xhrRequest.upload) {
						xhrRequest.upload.addEventListener('progress', function (progress) {

							if (!progress.lengthComputable)
								return;

							admin.progress.set(progress.loaded / progress.total);

						}, false);
					}
					return xhrRequest;
				},

				beforeSend: function (params) {
					admin.progress.reset();
					$(options.upload.statusLabelSelector).removeClass("hidden");
				},

				error: function (request) {
					var msgTitle = $(options.upload.fileInputSelector).data('msg-error-title');
					var messages = admin.utilities.getModelStateMessages(request.responseJSON);
					$.each(messages, function (idx, message) {
						admin.notify.error(msgTitle, message);
					});
				},

				success: function (data) {
					$(options.upload.blobIdSelector).val(data.imageBlob.id);
					$(options.upload.blobNameSelector).val(data.imageBlob.name);
					$(options.upload.blobThumbPreviewSelector).attr('src', data.previewThumbnailUrl);
				},

				complete: function () {
					$(options.upload.statusLabelSelector).addClass("hidden");
				}

			});
		});

		/*
		Subscribe to contact events
		*/
		admin.events.on('dot:contact-created', function (event, contact) {

			var option = $("<option></option>").attr("value", contact.id).text(contact.name);

			$(options.contactsSelector).append(option);
			$(options.contactsSelector).val(contact.id);

		});

                		
		
		








	});

}).apply(this, [jQuery, window.admin]);
