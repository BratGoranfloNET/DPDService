(function ($, admin) {

	'use strict';

	var options = {
		formId: '#eventsForm',
		images: {
			upload: {
				actionUrl: '/calendar/events/image/upload',
				triggerSelector: '.upload-images-event',
				fileInputSelector: '#imageFileInputEvent',
				blobThumbPreviewSelector: '#thumbPreviewContact',
				statusLabelSelector: '.uploading-status-event',
				imagesContainerSelector: '.event-images-gallery',

				expectedThumbWidth: 125,
				expectedThumbHeight: 125
			}
		}
	};

	var checkExistingFiles = function (options) {

		var $galleryWrapper = $('div.event-image-wrapper');
		var $emptyElement = $('.event-images-gallery-empty');

		if ($galleryWrapper.length) {
			$emptyElement.addClass('hidden');
		} else {
			$emptyElement.removeClass('hidden');
		}

	};

	var setGalleryEvents = function () {

		$('.delete-image-event').each(function () {

			var $item = $(this);

			// Delete confirmation
			if (!$item.hasClass('gallery-delete-ready')) {

				$item.confirmation({
					title: $item.data('confirmation-title-msg'),
					btnOkLabel: $item.data('confirmation-ok-lbl'),
					btnCancelLabel: $item.data('confirmation-cancel-lbl'),
					onConfirm: function (event, element) {
						event.preventDefault();
						var wrapper = $(element).closest('div.event-image-wrapper');
						if (wrapper.length > 0) {
							wrapper.remove();
							checkExistingFiles(options);
						}
					}
				});

				$item.addClass('gallery-delete-ready');

			}

		});

	};

    $(function () {

        

       
        

        //TTT 
        $('#LocationId').on('change', function (e) {

            
            var locationId = $('#LocationId').val();
            var ProductionsUrlTemplate = '/production/{locationId}/get';
            var ProductionsUrl = ProductionsUrlTemplate.replace(/{locationId}/g, locationId);
            
            // alert(locationId);
            // var $el = $(this);
            // e.stopPropagation();
            // console.log(e);
            // console.log($el);

            // if ($el.is('a'))
            // e.preventDefault();
                            
                $.ajax({
                    type: "GET",
                    url: ProductionsUrl,
                    dataType: 'json',
                    method: 'GET',
                    error: function (data) {
                                    // alert('error');
                                    },
                    success: function (data) {

                                    // console.log(data); 
                                    // alert(data.length);

                                    var options = '';
                                    options += '<option value=""></option>'; 
                                                                       
                                    for (var i = 0; i < data.length; i++) {
                                        options += '<option value="' + data[i].id + '"' + '>' + data[i].name + '</option >'; 
                                        // options += '<option value="' + data[i] + '">' + data[i] + '</option>';                                       
                                    }
                        
                                        // $('#ProductionId').append(options); 
                                    $('#ProductionId').find('option').remove().end().append(options);   

                                    }

                });


        });
        

		/*
		FORM
		****************/

		admin.validation.init(options.formId);

		$('.date-picker').each(function (item) {

			var $input = $(this);

			var pickerOptions = {
				format: $input.data("format")
			};

			$input.datepicker(pickerOptions);

		});

		$('.time-picker').each(function (item) {

			var $input = $(this);

			var pickerOptions = {
				template: false,
				showInputs: false,
				minuteStep: 1,
				defaultTime: false,
				showMeridian: $input.data("meridiem")
			};

			$input.timepicker(pickerOptions);

		});

		/*
		GALLERY
		****************/

		$('.event-images-gallery').magnificPopup({
			delegate: 'a.event-gallery-item',
			type: 'image',
			tLoading: $('.event-images-gallery').data('loading-msg-tpl'),
			mainClass: 'mfp-img-mobile',
			gallery: {
				enabled: true,
				navigateByImgClick: true,
				preload: [0, 1]
			},
			image: {
				tError: $('.event-images-gallery').data('loading-error-msg-tpl'),
			}
		});

		setGalleryEvents();


		/*
		UPLOADS
		****************/

		$(document).on('click', options.images.upload.triggerSelector, function (event) {

			event.preventDefault();
			$(options.images.upload.fileInputSelector).click();

		});

		$(document).on('change', options.images.upload.fileInputSelector, function () {

			if (this.files.length <= 0)
				return;

			// Files will be sent one by one.
			for (var idx = 0; idx < this.files.length; idx++) {

				var file = this.files[idx];

				var formData = new FormData();

				formData.append('imageFile', file);
				formData.append('expectedThumbWidth', options.images.upload.expectedThumbWidth);
				formData.append('expectedThumbHeight', options.images.upload.expectedThumbHeight);

				$.post({
					data: formData,
					processData: false,
					contentType: false,
					url: options.images.upload.actionUrl,
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
						$(options.images.upload.statusLabelSelector).removeClass("hidden");
					},

					error: function (request) {
						var msgTitle = $(options.upload.fileInputSelector).data('msg-error-title');
						var messages = admin.utilities.getModelStateMessages(request.responseJSON);
						$.each(messages, function (idx, message) {
							admin.notify.error(msgTitle, message);
						});
					},

					success: function (data) {
						$(options.images.upload.blobIdSelector).val(data.imageBlob.id);
						$(options.images.upload.blobNameSelector).val(data.imageBlob.name);
						$(options.images.upload.imagesContainerSelector).append(data.imageHtml);

						setGalleryEvents();
					},

					complete: function () {

						checkExistingFiles(options);
						$(options.images.upload.statusLabelSelector).addClass("hidden");

					}

				});

			}

		});

	});

}).apply(this, [jQuery, window.admin]);
