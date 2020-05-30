(function ($, admin) {

	'use strict';

	var options = {
		formId: '#contactsForm',
		upload: {
			actionUrl: '/contacts/image/upload',
			blobIdSelector: '#imageBlobIdContact',
			blobNameSelector: '#imageBlobNameContact',
			triggerSelector: '.upload-image-contact',
			fileInputSelector: '#imageFileInputContact',
			blobThumbPreviewSelector: '#thumbPreviewContact',
			statusLabelSelector: '.uploading-status-contact',

			expectedThumbWidth: 160,
			expectedThumbHeight: 182
		}
	};

	// Init
	$(function () {

		admin.validation.init(options.formId);

		$('.date-picker').each(function (item) {

			var $input = $(this);

			var pickerOptions = {
				format: $input.data("format")
			};

			$input.datepicker(pickerOptions);

		});

		var upload = $(options.upload.triggerSelector).length > 0;

		if (!upload)
			return;

		$(options.upload.triggerSelector).on('click', function (event) {

			event.preventDefault();

			$(options.upload.fileInputSelector).click();

		});

		$(options.upload.fileInputSelector).on('change', function () {

			if (this.files.length <= 0)
				return;

			var file = this.files[0];

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

	});

}).apply(this, [jQuery, window.admin]);
