(function ($, admin) {

	'use strict';

	var options = {
		formId: '#accountForm',
		currentTabId: '#currentTab',
		statusMessageUpdateId: '#StatusMessageUpdate',
		autoLockSliderId: '#autoLockSlider',
		autoLockSliderFieldId: '#AutoLockScreenInMinutes',
		autoLockSliderFielfInfoId: '#autoLockOutput',
		upload: {
			actionUrl: '/users/profile/image/upload',
			blobIdSelector: '#imageBlobIdProfile',
			blobNameSelector: '#imageBlobNameProfile',
			triggerSelector: '.upload-image-profile',
			fileInputSelector: '#imageFileInputProfile',
			blobThumbPreviewSelector: '#thumbPreviewProfile',
			statusLabelSelector: '.uploading-status-profile'
		}
	};

	var updateScreenLockInfo = function (options, value) {
		var $autoLockInfo = $(options.autoLockSliderFielfInfoId);
		if (value > 0) {
			$autoLockInfo.html($autoLockInfo.data('value-template').replace(/{interval}/g, value));
		} else {
			$autoLockInfo.html($autoLockInfo.data('value-zero'));
		}
	}

	// Initializer
	$(function () {

		admin.validation.init(options.formId);

		$(options.statusMessageUpdateId).maxlength({
			utf8: true,
			threshold: 20,
			alwaysShow: false,
			placement: 'bottom',
			twoCharLinebreak: false
		});

		autosize($(options.statusMessageUpdateId));

		$(options.autoLockSliderId).slider({
			range: "min",
			min: 0,
			max: 60,
			step: 5,
			slide: function (event, ui) {

				var value = ui.value;

				$(options.autoLockSliderFieldId).val(value);

				updateScreenLockInfo(options, value);

			},
			change: function (event, ui) {

				var value = ui.value;

				updateScreenLockInfo(options, value);

			},
			create: function (event, ui) {

				$(this).slider('value', $(options.autoLockSliderFieldId).val());

			}
		});

		// Tabs
		$('ul.nav-tabs').on("click", "a[data-toggle]", function (event) {

			var tabId = $(this).data("id");
			var tabState = $(this).data("state");

			$(options.currentTabId).val(tabId);

			history.replaceState(null, '', tabState);

		});

		// Upload
		$(options.upload.triggerSelector).on('click', function (event) {

			event.preventDefault();
			$(options.upload.fileInputSelector).click();

		});

		// File selected
		$(options.upload.fileInputSelector).on('change', function () {

			if (this.files.length <= 0)
				return;

			var file = this.files[0];

			var formData = new FormData($(options.formId)[0]);

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
