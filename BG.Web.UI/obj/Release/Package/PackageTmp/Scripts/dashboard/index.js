(function ($, admin) {

	'use strict';

	var itemTemplate = '<li><a class="text-muted text-no-decoration item-link" style="text-decoration:none;"><figure class="image rounded"><img width="40" height="40" class="img-circle item-image" /></figure><span class="title item-title"></span><span class="truncate item-date"></span></a></li>';

    var itemTemplateNoImage = '<li><a class="text-muted text-no-decoration item-link" style="text-decoration:none;"> <span class="title item-title"></span><span class="truncate item-date"></span></a></li>';


	var buildListItem = function (item) {

		var $template = $(itemTemplate).clone();

		$('.item-title', $template).text(item.name);
		$('.item-image', $template).attr('alt', item.name);
		$('.item-image', $template).attr('src', item.image);
		$('.item-date', $template).text(item.creationDate);
		$('.item-link', $template).attr('href', item.navigationPath);

		return $template;

    };

    var buildListItemNoImage = function (item) {

        var $template = $(itemTemplateNoImage).clone();

        $('.item-title', $template).text(item.name);
        // $('.item-image', $template).attr('alt', item.name);
        // $('.item-image', $template).attr('src', item.image);
        $('.item-date', $template).text(item.creationDate);
        $('.item-link', $template).attr('href', item.navigationPath);

        return $template;

    };

    var buildListItemNoImageNoLink = function (item) {

        var $template = $(itemTemplateNoImage).clone();

        $('.item-title', $template).text(item.name);
        //$('.item-image', $template).attr('alt', item.name);
        // $('.item-image', $template).attr('src', item.image);
        $('.item-date', $template).text(item.creationDate);
        //$('.item-link', $template).attr('href', item.navigationPath);

        return $template;

    };

	// Init
    $(function () {


        var isperiod1changed = false;
        var isperiod2changed = false;

        // $('#refresh-stat').prop('disabled', true);
        // $('#export-excel').prop('disabled', true);
       

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



        //$('#period1').on('change', function () {

        //  isperiod1changed = true;          
        //    if (isperiod2changed) {
        //        $('#refresh-stat').addClass('btn-success').prop('disabled', false);
        //        $('#export-excel').addClass('btn-success').prop('disabled', false);
        //    }
        //});


        //$('#period2').on('change', function () {

        //    isperiod2changed = true;
        //    if (isperiod1changed) {
        //        $('#refresh-stat').addClass('btn-success').prop('disabled', false);
        //        $('#export-excel').addClass('btn-success').prop('disabled', false);
        //    }           

        //});


        // Refresh
        $('#refresh-stat').on('click',  function (e) {

          

            //e.preventDefault();
            //e.stopPropagation();
            //var indexTemplate = '/dashboard/index';
            //var indexUrl = indexTemplate.replace(/{itemId}/g, itemId);

            var period1 = $('#period1').val();
            var period2 = $('#period2').val();
            var consignor1 = $('#consignor1').val();
          
            
            location.href = '/dashboard/?period1=' + period1 + '&period2=' + period2 + '&consignor1=' + consignor1;
          
            //setTimeout(function () {
            //    location.href = editUrl;
            //}, 1000);

        });


        // Excel
        $('#export-excel').on('click', function (e) {

            var period1 = $('#period1').val();
            var period2 = $('#period2').val();
            var consignor1 = $('#consignor1').val();

            location.href = '/dashboard/export/?period1=' + period1 + '&period2=' + period2 + '&consignor1=' + consignor1;
            
        });



        $.when(
            $.get('/stateunited/statistics'),
            $.get('/state/statistics'),
            $.get('/eventtrackingtype/statistics'),
            $.get('/eventtrackingparameter/statistics')

        ).then(function (stateunitedData, stateData, eventtrackingtypeData, eventtrackingparameterData)
         {

            var stateunited = stateunitedData[0];
            var state = stateData[0];
            var eventtrackingtype = eventtrackingtypeData[0];
            var eventtrackingparameter = eventtrackingparameterData[0];          
           


            var seriesConfig = {
                series: {
                    lines: {
                        show: true,
                        lineWidth: 2
                    },
                    points: {
                        show: true
                    },
                    shadowSize: 0
                },
                grid: {
                    hoverable: true,
                    clickable: true,
                    borderColor: 'rgba(0,0,0,0.1)',
                    borderWidth: 1,
                    labelMargin: 15,
                    backgroundColor: 'transparent'
                },
                yaxis: {
                    min: 0,
                    color: 'rgba(0,0,0,0.1)'
                },
                xaxis: {
                    mode: 'categories',
                    color: 'rgba(0,0,0,0)'
                },
                legend: {
                    show: false
                },
                tooltip: true,
                tooltipOpts: {
                    content: '%x: %y',
                    shifts: {
                        x: -30,
                        y: 25
                    },
                    defaultTheme: false
                }
            };

            $('#registrationSelector').trigger('change');

            $('#registrationSelectorWrapper').addClass('ready');

            $('#registrationSelector').themePluginMultiSelect().on('change', function () {
                var rel = $(this).val();
                $('#registrationSelectorItems .chart').removeClass('chart-active').addClass('chart-hidden');
                $('#registrationSelectorItems .chart[data-sales-rel="' + rel + '"]').addClass('chart-active').removeClass('chart-hidden');
            });





            /*
          stateunited
          */

            $('.amount-stateunited').text(stateunited.count);

            var stateunitedChartData = [{
                data: stateunited.weeklyRegistrations,
                color: "#008c95" 
            }];

            var $stateunitedChart = $.plot('#stateunitedChart', stateunitedChartData, seriesConfig);

            if (!stateunited.latest.length) {
                $('.empty', 'ul.latest-stateunited').removeClass('hidden');
            } else {
                $.each(stateunited.latest, function (idx, item) {
                    //var $item = buildListItem(item);
                    var $item = buildListItemNoImage(item);
                    $('ul.latest-stateunited').append($item);
                });
            }









            /*
			state
			*/

            $('.amount-state').text(state.count);

            var stateChartData = [{
                data: state.weeklyRegistrations,
                color: "#bbc91e" 
            }];

            var $stateChart = $.plot('#stateChart', stateChartData, seriesConfig);

            if (!state.latest.length) {
                $('.empty', 'ul.latest-state').removeClass('hidden');
            } else {
                $.each(state.latest, function (idx, item) {
                    //var $item = buildListItem(item);
                    var $item = buildListItemNoImage(item);
                    $('ul.latest-state').append($item);
                });
            }












            /*
          eventtrackingtype
          */

            $('.amount-eventtrackingtype').text(eventtrackingtype.count);

            var eventtrackingtypeChartData = [{
                data: eventtrackingtype.weeklyRegistrations,
                color: "#ffc000"
            }];

            var $eventtrackingtypeChart = $.plot('#eventtrackingtypeChart', eventtrackingtypeChartData, seriesConfig);

            if (!eventtrackingtype.latest.length) {
                $('.empty', 'ul.latest-eventtrackingtype').removeClass('hidden');
            } else {
                $.each(eventtrackingtype.latest, function (idx, item) {
                    var $item = buildListItemNoImage(item);
                    $('ul.latest-eventtrackingtype').append($item);
                });
            }




            /*
			eventtrackingparameter
			*/

            $('.amount-eventtrackingparameter').text(eventtrackingparameter.count);

            var eventtrackingparameterChartData = [{
                data: eventtrackingparameter.weeklyRegistrations,
                color: "#b2d2d8"
            }];

            var $eventtrackingparameterChart = $.plot('#eventtrackingparameterChart', eventtrackingparameterChartData, seriesConfig);

            if (!eventtrackingparameter.latest.length) {
                $('.empty', 'ul.latest-eventtrackingparameter').removeClass('hidden');
            } else {
                $.each(eventtrackingparameter.latest, function (idx, item) {
                    //var $item = buildListItem(item);
                    var $item = buildListItemNoImage(item);
                    $('ul.latest-eventtrackingparameter').append($item);
                });
            }


 


		});

	});

}).apply(this, [jQuery, window.admin]);
