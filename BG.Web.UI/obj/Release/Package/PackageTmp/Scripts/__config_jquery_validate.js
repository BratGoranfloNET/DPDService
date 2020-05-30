/*
 * JQuery validate configs
 * - Customize global options here.
 * - Some parts of this code are based ob the work here: https://github.com/johnnyreilly/$-validation-globalize
 */

// Custom validation rules

$.validator.addMethod("requiredcheckbox", function (value, element, param) {
	return element.checked;
});

// Replace native validation methods with the ones provided by JQuery globalize library.

var baseMethods = {
	min: $.validator.methods.min,
	max: $.validator.methods.max,
	range: $.validator.methods.range
};

$.validator.methods.date = function (value, element) {

	if (element.type === "date")
		value = new Date(value).toLocaleDateString();

	val = Globalize.parseDate(value, { skeleton: "yMd" });

	return this.optional(element) || !/Invalid|NaN/.test(new Date(val).toString());

};

$.validator.methods.number = function (value, element) {
	var val = Globalize.parseNumber(value);
	return this.optional(element) || ($.isNumeric(val));
};

$.validator.methods.min = function (value, element, param) {
	var val = Globalize.parseNumber(value);
	return baseMethods.min.call(this, val, element, param);
};

$.validator.methods.max = function (value, element, param) {
	var val = Globalize.parseNumber(value);
	return baseMethods.max.call(this, val, element, param);
};

$.validator.methods.range = function (value, element, param) {
	var val = Globalize.parseNumber(value);
	return baseMethods.range.call(this, val, element, param);
};

