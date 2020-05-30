/*
Name: 			UI Elements / Tree View - Examples
Written by: 	Okler Themes - (http://www.okler.net)
Theme Version: 	1.5.4
*/

(function ($) {

	'use strict';

	/*
	Basic
	*/
	$('#treeBasic').jstree({
		'core': {
			'themes': {
				'responsive': false
			}
		},
		'types': {
			'default': {
				'icon': 'fa fa-folder'
			},
			'file': {
				'icon': 'fa fa-file'
			}
		},
		'plugins': ['types']
	});

	/*
	Checkbox
	*/
	$('#treeCheckbox').jstree({
		'core': {
			'themes': {
				'responsive': false
			}
		},
		'types': {
			'default': {
				'icon': 'fa fa-folder'
			},
			'file': {
				'icon': 'fa fa-file'
			}
		},
		'plugins': ['types', 'checkbox']
	});

	/*
	Ajax HTML
	*/
	$('#treeAjaxHTML').jstree({
		'core': {
			'themes': {
				'responsive': false
			},
			'check_callback': true,
			'data': {
				'url': function (node) {
					return $('#treeAjaxHTML').attr("data-source-url");
				},
				'data': function (node) {
					return { 'parent': node.id };
				}
			}
		},
		'types': {
			'default': {
				'icon': 'fa fa-folder'
			},
			'file': {
				'icon': 'fa fa-file'
			}
		},
		'plugins': ['types']
	});

	/*
	Ajax JSON
	*/
	$('#treeAjaxJSON').jstree({
		'core': {
			'themes': {
				'responsive': false
			},
			'check_callback': true,
			'data': {
				'url': function (node) {
					return node.id === '#' ? $('#treeAjaxJSON').attr("data-source-url-roots") : $('#treeAjaxJSON').attr("data-source-url-children");
				},
				'data': function (node) {
					return { 'id': node.id };
				}
			}
		},
		'types': {
			'default': {
				'icon': 'fa fa-folder'
			},
			'file': {
				'icon': 'fa fa-file'
			}
		},
		'plugins': ['types']
	});

	/*
	Drag & Drop
	*/
	$('#treeDragDrop').jstree({
		'core': {
			'check_callback': true,
			'themes': {
				'responsive': false
			}
		},
		'types': {
			'default': {
				'icon': 'fa fa-folder'
			},
			'file': {
				'icon': 'fa fa-file'
			}
		},
		'plugins': ['types', 'dnd']
	});

}).apply(this, [jQuery]);