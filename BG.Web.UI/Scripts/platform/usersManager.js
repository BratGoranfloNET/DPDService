(function ($, admin) {

	'use strict';

	var options = {
		formId: '#usersForm'
	};

	// Init
	$(function () {

		admin.validation.init(options.formId);

	    //
		$('#sampleMulti').multiSelect({
		    dblClick: true,
		    cssClass: 'multiselect-full-width',
		    selectableHeader: 'Не выбранные',
		    selectionHeader: 'Выбранные'                      
                       
		});

	});

}).apply(this, [jQuery, window.admin]);
