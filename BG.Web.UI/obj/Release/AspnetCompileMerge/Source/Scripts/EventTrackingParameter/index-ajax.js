(function ($, admin) {

    'use strict';

    var options = {
        tableId: '#eventTable',
        //deleteDialogId: '#stateunitedDeleteDialog',
       // deleteUrlTemplate: '/stateunited/{itemId}/delete'
    };


    // Init
    $(function () {

              
        

        var stateunitedID = 1;

        // var stateUrlTemplate = '/stateunited/{stateunitedid}/gethistoryajax';
        var ePath = '/eventtrackingparameter/geteventtrackingparameterajax';
        var SelectedId;




        var $table_main = $(options.tableId).DataTable(
            {

                "order": [0, 'desc'],

                "columnDefs": [
                
                  //  { "title": "Ном. заказа клиента", "targets": [0] },
                  //  { "title": "Ном. пос. клиента",   "targets": [1] },
                  
                 

                ],

                //"columnDefs": [
                //    { "width": "5%", "targets": [0] },
                //    { "className": "text-center custom-middle-align", "targets": [0, 1, 2, 3, 4, 5, 6] },
                //],


                "language":
                {
                    "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
                },

                "processing": true,
                "serverSide": true,
                "searching": true,
                "deferRender": true,

                "ajax":
                {
                    "url": ePath,
                    "type": "POST",
                    "dataType": "JSON",
                    // "data": function (d) {
                    //     d.stateunitedid = stateunitedID;
                    //}

                },
                "columns": [
                     { "data": "id" },
                    


                    { "data": "name" },
                    { "data": "eventTrackingTypeId" },
                    { "data": "paramName" },
                    { "data": "valueString" },
                    { "data": "valueDecimalstring" },                
                    { "data": "valueDecimalSpecified" },
                    { "data": "valueDateTimestring" },
                    { "data": "valueDateTimeSpecified" },
                    { "data": "type" }
                   

                ]
            });





    });

}).apply(this, [jQuery, window.admin]);
