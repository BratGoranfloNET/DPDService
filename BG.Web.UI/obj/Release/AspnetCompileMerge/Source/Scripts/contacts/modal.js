(function ($, admin) {

	'use strict';

	var options = {
		formId: '#contactsModalForm',
		modal: {
			actionUrl: '/contacts/modal',
			wrapperId: '#contactsModalWrapper',
			triggerSelector: '.contacts-modal-opener',
			dismissActionSelector: '.contacts-modal-dismiss',
			confirmActionSelector: '.contacts-modal-confirm',
			focusedElementSelector: 'input[name="name"]'
		},
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

			e.preventDefault();

			var isValidForm = $(options.formId).valid();

           


			if (isValidForm) {

				var formData = $(options.formId).serialize();

				$.post(options.modal.actionUrl, formData).done(function (contact) {

					admin.events.trigger('dot:contact-created', [contact]);

					$.magnificPopup.close();

				}).fail(function () {

					var $modalWrapper = $(options.modal.wrapperId);
					var modalErrorMessageTitle = $modalWrapper.data('msg-error-title');
					var modalErrorMessageContent = $modalWrapper.data('msg-error-content');

					admin.notify.error(msg.title, msg.content);

				});

			}

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
