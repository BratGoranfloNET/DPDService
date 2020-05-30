
(function ($, admin) {

	'use strict';

	var initMain = function () {

		var formId = '#lockScreenForm';

		var $lockScreenForm = $(formId);

		if (!$lockScreenForm.length)
			return;

		admin.validation.init(formId);
	}

	var initModal = function () {

		var formId = '#lockScreenModalForm';
		var lockScreenUrl = '/users/screen/lock';
		var initialFocus = 'input[name="Password"]';
		var modalWrapperId = '#lockScreenModalWrapper';
		var screenLockedDataAttribute = 'screen-locked';

		var $body = $('body');
		var $userBox = $('#userbox');
		var $lockScreenModalForm = $(formId);

		if (!$lockScreenModalForm.length)
			return;

		var autoLockMinutes = $userBox.data("auto-lock-minutes");

		if (autoLockMinutes > 0) {

			admin.validation.init(formId);

			// Miliseconds
			$.idleTimer(autoLockMinutes * 60 * 1000);

			$(document).on('idle.idleTimer', function () {

				if ($userBox.data(screenLockedDataAttribute))
					return;

				// Apply lock
				$.get(lockScreenUrl).done(function () {

					$userBox.data(screenLockedDataAttribute, 'true');

					// Show lock screen modal
					$.magnificPopup.open({

						modal: true,
						focus: initialFocus,
						mainClass: 'mfp-lock-screen',

						items: {
							type: 'inline',
							src: modalWrapperId
						},

						callbacks: {
							beforeOpen: function () {
								if ($(window).width() < 700) {
									this.st.focus = false;
								} else {
									this.st.focus = initialFocus;
								}
							}
						}
					});

				});

			});

			$(modalWrapperId).on('click', '.unlock-action', function (e) {

				e.preventDefault();

				var isValidForm = $(formId).valid();

				if (isValidForm) {
					$(formId).submit();
				}

			});

		}
	}

	// Initializer
	$(function () {

		initMain();

		initModal();

	});

}).apply(this, [jQuery, window.admin]);
