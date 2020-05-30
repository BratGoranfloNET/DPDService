(function ($, admin) {

    'use strict';

    var options = {
        tableId: '#stateunitedTable',
        //deleteDialogId: '#stateunitedDeleteDialog',
       // deleteUrlTemplate: '/stateunited/{itemId}/delete'
    };


    // Init
    $(function () {


        var History = function (data, type, row, meta) {
            

            var Count = data;

            var strVar = "";
            strVar += "<ul class=\"notifications\">";
            strVar += "    <li >";
            strVar += "        <a  data-item-id=" + row.id + "\" href=\"#stateModalWrapper\"  alt=\"Статусы\" title=\"История статусов\" class=\"state-modal-opener notification-icon\">";
            strVar += "            <i class=\"fa fa-history\"><\/i>";
          //  strVar += "            <span class=\"badge\">" + Count + "<\/span>";
            strVar += "        <\/a>";
            strVar += "    <\/li>";
            strVar += "<\/ul>";

            return strVar

        };

        
      
        

        var stateunitedID = 1;

        // var stateUrlTemplate = '/stateunited/{stateunitedid}/gethistoryajax';
        var stateunitedPath = '/stateunited/getstateunitedajax';
        var SelectedId;




        var $table_main = $(options.tableId).DataTable(
            {

                "order": [0, 'desc'],

                "columnDefs": [
                
                  //  { "title": "Ном. заказа клиента", "targets": [0] },
                  //  { "title": "Ном. пос. клиента",   "targets": [1] },
                  //  { "title": "Ном. отправления", "targets": [2] },
                  //  { "title": "Ном. пос. dpd", "targets": [3] },
                  //  { "title": "Дата отгрузки", "targets": [4] },
                                       


                  //  { "title": "Статус", "targets": [5] },
                  //  { "title": "Дата транзита", "targets": [6] },
                   // { "title": "Код терминала", "targets": [7] },
                  //  { "title": "Город терминала", "targets": [8] }

                 

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
                    "url": stateunitedPath,
                    "type": "POST",
                    "dataType": "JSON",
                    // "data": function (d) {
                    //     d.stateunitedid = stateunitedID;
                    //}

                },
                "columns": [
                    // { "data": "id" },
                    {
                        "data": "id",
                        "render": function (data, type, row, meta) {

                            return History(data, type, row, meta);
                        }
                    },


                    { "data": "clientOrderNr" },
                    { "data": "clientParcelNr" },
                    { "data": "dpdOrderNr" },
                    { "data": "dpdParcelNr" },
                    { "data": "pickupDate" },


                    // { "data": "isReturn" },
                    // { "data": "isReturnSpecified" },
                    { "data": "planDeliveryDate_string" },
                    // { "data": "planDeliveryDateSpecified" },
                    { "data": "newState" },
                    { "data": "transitionTime" },
                    { "data": "terminalCode" },
                    { "data": "terminalCity" },
                    { "data": "incidentCode" },
                    { "data": "incidentName" },
                    { "data": "consignee" },

                    { "data": "deliveryAddress" },
                    //{ "data": "deliveryAddress2"},
                    { "data": "deliveryCity" },
                    { "data": "deliveryVariant" },
                    { "data": "deliveryPointCode" },
                    { "data": "deliveryInterval" },
                    
                    { "data": "pickupAddress" },
                    { "data": "pickupCity" },
                    { "data": "pointCity" },
                    { "data": "consignee2" },
                    { "data": "consignor" },

                    { "data": "eventName" },

                    { "data": "eventReason" },
                    { "data": "problemName" },
                    { "data": "reasonName" },
                    { "data": "rejectionReason" },
                    { "data": "orderType" },
                    { "data": "momentLocZone" }
                    

                ]
            });





    });

}).apply(this, [jQuery, window.admin]);
