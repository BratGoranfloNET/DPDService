(function ($) {

    'use strict';


    /*
Flot: Pie
*/
    (function () {
        var plot = $.plot('#flotPie', flotPieData, {
            series: {
                pie: {
                    show: true,
                    combine: {
                        color: '#999',
                        threshold: 0.1
                    }
                }
            },
            legend: {
                show: false
            },
            grid: {
                hoverable: true,
                clickable: true
            }
        });
    })();


}).apply(this, [jQuery]);