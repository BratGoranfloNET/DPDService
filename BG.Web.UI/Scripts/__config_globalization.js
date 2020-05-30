/*
 * Globalization configs
 * - Customize global options here.
 */

var region = $('html').data('region');

$.when(
  $.get('/scripts/cldr/supplemental/likelySubtags.json')
).then(function (data) {

	Globalize.load(data);

	var globalize = Globalize(region);

	var language = globalize.cldr.attributes.minLanguageId;

	$.when(
	  $.get('/scripts/cldr/supplemental/likelySubtags.json'),
	  $.get('/scripts/cldr/main/' + language + '/numbers.json'),
	  $.get('/scripts/cldr/supplemental/numberingSystems.json'),
	  $.get('/scripts/cldr/supplemental/plurals.json'),
	  $.get('/scripts/cldr/supplemental/ordinals.json'),
	  $.get('/scripts/cldr/main/' + language + '/currencies.json'),
	  $.get('/scripts/cldr/supplemental/currencyData.json'),
	  $.get('/scripts/cldr/main/' + language + '/ca-gregorian.json'),
	  $.get('/scripts/cldr/main/' + language + '/timeZoneNames.json'),
	  $.get('/scripts/cldr/supplemental/timeData.json'),
	  $.get('/scripts/cldr/supplemental/weekData.json'),
	  $.get('/scripts/cldr/main/' + language + '/dateFields.json'),
	  $.get('/scripts/cldr/main/' + language + '/units.json')
	).then(function () {

		return [].slice.apply(arguments, [0]).map(function (result) {
			return result[0];
		});

	}).then(Globalize.load).then(function () {

		Globalize.locale(region);

	});

});

