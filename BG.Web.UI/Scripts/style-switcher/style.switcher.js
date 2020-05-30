/*
Name: 			Style Switcher Initializer
Written by: 	Okler Themes - (http://www.okler.net)
Version: 		2.0
*/

var styleSwitcher = {

	initialized: false,
	defaults: {
		saveToStorage: true,
		preserveCookies: false,
		colorPrimary: '#0088CC',
		backgroundColor: 'light',
		headerColor: 'light',
		borderRadius: '4px',
		layoutStyle: 'wide',
		sidebarColor: 'dark',
		sidebarSize: 'md',
		changeLogo: true
	},

	initialize: function () {

		var $this = this,
			htmlDataOptions = $('html').data('style-switcher-options');

		if (this.initialized) return;

		// Options
		$this.options = $.extend({}, $this.defaults);

		// Capitalize String
		String.prototype.capitalize = function () {
			return this.charAt(0).toUpperCase() + this.slice(1);
		}

		// Style Switcher Cache Script
		jQuery.styleSwitcherCachedScript = function (url, options) {
			options = $.extend(options || {}, {
				dataType: 'script',
				cache: true,
				url: url
			});
			return jQuery.ajax(options);
		};

		// Set Borders Radius
		if ($.cookie('borderRadius') != null) {
			$this.options.borderRadius = $.cookie('borderRadius');
		}

		// Set Colors
		if ($.cookie('colorPrimary') != null) {
			$this.options.colorPrimary = '#' + $.cookie('colorPrimary');
		}

		// Set Temporary Options
		if (htmlDataOptions) {
			htmlDataOptions = htmlDataOptions.replace(/'/g, '"');
			$this.options = $.extend({}, $this.options, JSON.parse(htmlDataOptions));
			$this.options.preserveCookies = true;
			$this.options.saveToStorage = false;
		}

		// Style Switcher CSS
		$('head').append($('<link rel="stylesheet">').attr('href', '/scripts/style-switcher/style-switcher.css'));
		$('head').append($('<link rel="stylesheet/less">').attr('href', '/scripts/style-switcher/less/skin.less'));
		$('head').append($('<link rel="stylesheet/less">').attr('href', '/scripts/style-switcher/less/extension.less'));
		$('head').append($('<link rel="stylesheet">').attr('href', '/scripts/style-switcher/bootstrap-colorpicker/css/bootstrap-colorpicker.css'));

		$.styleSwitcherCachedScript('/scripts/style-switcher/bootstrap-colorpicker/js/bootstrap-colorpicker.min.js').done(function (script, textStatus) {

			less = {
				async: true,
				env: "production",
				modifyVars: {
					'@border-radius': $this.options.borderRadius,
					'@color-primary': $this.options.colorPrimary
				}
			};

			$.styleSwitcherCachedScript('/assets/vendor/less/less.min.js').done(function (script, textStatus) {

				$.ajax({
					url: '/scripts/style-switcher/style.switcher.html'
				}).done(function (data) {

					$('body').append(data);

					$this.container = $('#styleSwitcher');

					$this.build();
					$this.events();

					if (!htmlDataOptions) {

						// Set Layout Style
						if ($.cookie('layoutStyle') != null) {
							$this.options.layoutStyle = $.cookie('layoutStyle');
						}

						// Set Background Color
						if ($.cookie('backgroundColor') != null) {
							$this.options.backgroundColor = $.cookie('backgroundColor');
						}

						// Set Header Color
						if ($.cookie('headerColor') != null) {
							$this.options.headerColor = $.cookie('headerColor');
						}

						// Set Sidebar Color
						if ($.cookie('sidebarColor') != null) {
							$this.options.sidebarColor = $.cookie('sidebarColor');
						}

						// Set Sidebar Color
						if ($.cookie('sidebarSize') != null) {
							$this.options.sidebarSize = $.cookie('sidebarSize');
						}

					}

					$this.setLayoutStyle($this.options.layoutStyle);
					$this.setBackgroundColor($this.options.backgroundColor);
					$this.setHeaderColor($this.options.headerColor);
					$this.setSidebarColor($this.options.sidebarColor);
					$this.setSidebarSize($this.options.sidebarSize);
					$this.setColors();
					$this.setBorderRadius($this.options.borderRadius);

					// Check if already initialized
					if ($.cookie('initialized') == null) {
						$this.container.find('#styleSwitcherOpen').trigger('click');
						$.cookie('initialized', true);
					}

					$this.initialized = true;

				});

			});

		});

		$.styleSwitcherCachedScript('/scripts/style-switcher/cssbeautify/cssbeautify.js').done(function (script, textStatus) { });

	},

	build: function () {

		var $this = this,
			colorPrimaryField = $this.container.find('.color-primary input');

		// Color Picker
		colorPrimaryField
			.val($this.options.colorPrimary)
			.parent()
			.colorpicker({
				align: 'right',
				customClass: 'style-switcher-color-picker'
			});

		$('.colorpicker').on('mousedown', function (e) {
			e.preventDefault();
			$this.isChanging = true;
		}).on('mouseup', function (e) {
			e.preventDefault();
			$this.isChanging = false;

			$this.options.colorPrimary = colorPrimaryField.val();

			$this.setColors();
		});

		$('.colorpicker-element input').on('blur', function (e) {
			$this.options.colorPrimary = colorPrimaryField.val();

			$this.setColors();
		});

		// Borders Radius
		this.container.find('.options-links.borders a').click(function (e) {
			e.preventDefault();
			$this.setBorderRadius($(this).attr('data-border-radius'));
		});

		// Background Color
		this.container.find('.options-links.background-color a').click(function (e) {
			e.preventDefault();
			$this.setBackgroundColor($(this).attr('data-background-color'));
		});

		// Header Color
		this.container.find('.options-links.header-color a').click(function (e) {
			e.preventDefault();
			$this.setHeaderColor($(this).attr('data-header-color'));
		});

		// Sidebar Color
		this.container.find('.options-links.sidebar-color a').click(function (e) {
			e.preventDefault();
			$this.setSidebarColor($(this).attr('data-sidebar-color'));
		});

		// Layout Styles
		this.container.find('.options-links.layout a').click(function (e) {
			e.preventDefault();
			$this.setLayoutStyle($(this).attr('data-layout-type'));
		});

		// Sidebar Size
		this.container.find('.options-links.sidebar-size a').click(function (e) {
			e.preventDefault();
			$this.setSidebarSize($(this).attr('data-sidebar-size'));
		});

		// Reset
		$this.container.find('.reset').click(function (e) {
			e.preventDefault();
			$this.reset();
		});

		// Get CSS
		$this.container.find('.get-css').click(function (e) {
			e.preventDefault();
			$this.getCss();
		});

	},

	events: function () {

		var $this = this;

		$('#styleSwitcherOpen').click(function (e) {

			e.preventDefault();

			if ($this.container.hasClass('active')) {

				$this.container.animate({
					right: '-' + $this.container.width() + 'px'
				}, 300).removeClass('active');

			} else {

				$this.container.animate({
					right: '0'
				}, 300).addClass('active');

			}

		});

		if ($.cookie('showSwitcher') != null || $('body').hasClass('one-page')) {
			$('#styleSwitcherOpen').trigger('click');
			$.removeCookie('showSwitcher');
		}

	},

	setColors: function (color, rel) {

		var $this = this;

		if (this.isChanging) {
			return false;
		}

		if (color) {
			$this.options['color' + rel.capitalize()] = color;
			$this.container.find('.color-' + rel + ' input').val(color);
		}

		if (!$this.options.preserveCookies) {
			$.cookie('colorPrimary', $this.options.colorPrimary.replace('#', ''));
		}

		$this.modifyVars();

		this.setLogo();

	},

	setBorderRadius: function (radius) {

		var $this = this;

		$this.options.borderRadius = radius;

		if (!$this.options.preserveCookies) {
			$.cookie('borderRadius', radius);
		}

		$this.modifyVars();

		var borderRadius = this.container.find('.options-links.borders');

		borderRadius.find('.active').removeClass('active');
		borderRadius.find('a[data-border-radius=' + radius + ']').addClass('active');

		$.event.trigger({
			type: 'styleSwitcher.setBorderRadius',
			radius: radius
		});

	},

	setBackgroundColor: function (color) {

		var $this = this;

		if (!$this.options.preserveCookies) {
			$.cookie('backgroundColor', color);
		}

		if (this.options.saveToStorage && typeof localStorage !== "undefined") {
			localStorage.setItem('backgroundColor', color);
		}

		var backgroundColors = this.container.find('.options-links.background-color');

		backgroundColors.find('.active').removeClass('active');
		backgroundColors.find('a[data-background-color=' + color + ']').addClass('active');

		if (color == 'dark') {
			$('html').addClass('dark');
			$('#addDarkClassInfo').show();
		} else {
			$('html').removeClass('dark');
			$('#addDarkClassInfo').hide();
		}

		$.event.trigger({
			type: 'styleSwitcher.setBackgroundColor',
			color: color
		});

		this.setLogo();

	},

	setHeaderColor: function (color) {

		var $this = this;

		if (!$this.options.preserveCookies) {
			$.cookie('headerColor', color);
		}

		if (this.options.saveToStorage && typeof localStorage !== "undefined") {
			localStorage.setItem('headerColor', color);
		}

		var headerColors = this.container.find('.options-links.header-color');

		headerColors.find('.active').removeClass('active');
		headerColors.find('a[data-header-color=' + color + ']').addClass('active');

		if (color == 'dark') {
			$('html').addClass('header-dark');
			$('#addHeaderDarkClassInfo').show();
		} else {
			$('html').removeClass('header-dark');
			$('#addHeaderDarkClassInfo').hide();
		}

		$.event.trigger({
			type: 'styleSwitcher.setHeaderColor',
			color: color
		});

	},

	setSidebarColor: function (color) {

		var $this = this;

		if (!$this.options.preserveCookies) {
			$.cookie('sidebarColor', color);
		}

		if (this.options.saveToStorage && typeof localStorage !== "undefined") {
			localStorage.setItem('sidebarColor', color);
		}

		var sidebarColors = this.container.find('.options-links.sidebar-color');

		sidebarColors.find('.active').removeClass('active');
		sidebarColors.find('a[data-sidebar-color=' + color + ']').addClass('active');

		if (color == 'light') {
			$('html').addClass('sidebar-light');
			$('#addSidebarLightClassInfo').show();
		} else {
			$('html').removeClass('sidebar-light');
			$('#addSidebarLightClassInfo').hide();
		}

		$.event.trigger({
			type: 'styleSwitcher.setSidebarColor',
			color: color
		});

	},

	setLayoutStyle: function (style, refresh) {

		var $this = this;

		if (!$this.options.preserveCookies) {
			$.cookie('layoutStyle', style);
		}

		if (this.options.saveToStorage && typeof localStorage !== "undefined") {
			localStorage.setItem('layout', style);
		}

		if (refresh) {
			$.cookie('showSwitcher', true);
			window.location.reload();
			return false;
		}

		var layoutStyles = this.container.find('.options-links.layout');

		layoutStyles.find('.active').removeClass('active');
		layoutStyles.find('a[data-layout-type=' + style + ']').addClass('active');

		if (style == 'wide') {
			$('html').removeClass('boxed');
			$('#addBoxedClassInfo').hide();
		} else {
			$('html').addClass('boxed').removeClass('fixed');
			$('#addBoxedClassInfo').show();
		}

		$.event.trigger({
			type: 'styleSwitcher.setLayoutStyle',
			style: style
		});

	},

	setSidebarSize: function (size) {

		var $this = this,
			$html = $('html');

		if (!$this.options.preserveCookies) {
			$.cookie('sidebarSize', size);
		}

		if (this.options.saveToStorage && typeof localStorage !== "undefined") {
			localStorage.setItem('sidebarSize', size);
		}

		var sidebarSizes = this.container.find('.options-links.sidebar-size');

		sidebarSizes.find('.active').removeClass('active');
		sidebarSizes.find('a[data-sidebar-size=' + size + ']').addClass('active');

		$html.removeClass("sidebar-left-xs sidebar-left-sm");

		switch (size) {

			case 'xs':
				$html.addClass('sidebar-left-xs');
				break;

			case 'sm':
				$html.addClass('sidebar-left-sm');
				break;

		}

		$.event.trigger({
			type: 'styleSwitcher.setSidebarSize',
			color: size
		});

	},

	setLogo: function (forceDefault) {

		if (!this.options.changeLogo) {
			return this;
		}

		var logos = $('.header .logo img, .center-sign .logo img');

		if (forceDefault || ('#' + $.cookie('colorPrimary')).toUpperCase() == (this.defaults.colorPrimary).toUpperCase() && $.cookie('backgroundColor') != 'dark') {
			logos.attr('src', '/contents/logo-default.png');
		} else if ($.cookie('backgroundColor') == 'dark') {
			logos.attr('src', '/contents/logo-light.png');
		} else {
			logos.attr('src', '/contents/logo.png');
		}

		$.event.trigger({
			type: 'styleSwitcher.setLogo'
		});

	},

	modifyVars: function () {

		var $this = this;

		window.clearTimeout($this.timer);

		$this.timer = window.setTimeout(function () {

			less.modifyVars({
				'@border-radius': $this.options.borderRadius,
				'@color-primary': $this.options.colorPrimary
			});

			if ($this.options.saveToStorage && typeof localStorage !== "undefined") {
				localStorage.setItem('skin-admin.css', $('style[id^="less:"]').text());
			}

			$.event.trigger({
				type: 'styleSwitcher.modifyVars',
				options: $this.options
			});

		}, 300);

	},

	reset: function () {

		$.removeCookie('borderRadius');
		$.removeCookie('colorPrimary');
		$.removeCookie('backgroundColor');
		$.removeCookie('headerColor');
		$.removeCookie('layoutStyle');
		$.removeCookie('sidebarColor');
		$.removeCookie('sidebarSize');

		$.cookie('showSwitcher', true);
		window.location.reload();

		if (typeof localStorage !== "undefined") {
			localStorage.removeItem('skin-admin.css');
			localStorage.removeItem('layout');
		}

	},

	getCss: function () {

		var rawAdmin = '',
			rawExtension = '';

		// Admin
		$('#getCSSTextarea')
			.text($('style[id$="less-skin"]').text())
			.focus(function () {
				var $this = $(this);
				$this.select();

				$this.mouseup(function () {
					$this.unbind('mouseup');
					return false;
				});
			});

		rawAdmin = $('#getCSSTextarea').text();

		$('#getCSSTextarea').text(cssbeautify(rawAdmin, {
			indent: '\t',
			autosemicolon: true
		}));

		// Extension
		$('#getCSSTextareaExtension')
			.text($('style[id$="less-extension"]').text())
			.focus(function () {
				var $this = $(this);
				$this.select();

				$this.mouseup(function () {
					$this.unbind('mouseup');
					return false;
				});
			});

		rawExtension = $('#getCSSTextareaExtension').text();

		$('#getCSSTextareaExtension').text(cssbeautify(rawExtension, {
			indent: '\t',
			autosemicolon: true
		}));

		$('#getCSSModal').modal('show');

	}

};

styleSwitcher.initialize();