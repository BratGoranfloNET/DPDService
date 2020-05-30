(function ($, admin) {

	'use strict';

	var options = {
		formId: '#categoryForm',
		contactsSelector: 'select[name=ContactId]',
		upload: {
            actionUrl: '/category/image/upload',
            blobIdSelector: '#imageBlobIdCategory',
            blobNameSelector: '#imageBlobNameCategory',
            triggerSelector: '.upload-image-category',
            fileInputSelector: '#imageFileInputCategory',
            blobThumbPreviewSelector: '#thumbPreviewCategory',
            statusLabelSelector: '.uploading-status-category',
			expectedThumbWidth: 160,
			expectedThumbHeight: 182
		}
	};

	// Init
	$(function () {

		admin.validation.init(options.formId);

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
