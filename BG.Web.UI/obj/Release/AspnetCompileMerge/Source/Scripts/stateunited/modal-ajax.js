(function ($, admin) {

    'use strict';

    var options2 = {
        formId: '#stateModalForm',
        modal: {

            actionUrl: '/stateunited/modal',
            wrapperId: '#stateModalWrapper',
            triggerSelector: '.state-modal-opener',
            dismissActionSelector: '.state-modal-dismiss',
            confirmActionSelector: '.state-modal-confirm',
            focusedElementSelector: 'input[name="name"]'

        }
    };


    var options_state = {
        tableId: '#statehistoryTable'
        //deleteDialogId: '#tendersDeleteDialog',
        //deleteUrlTemplate: '/tenders/{itemId}/delete'
    };



    // Init
    $(function () {

        
        $(options2.modal.triggerSelector).magnificPopup({

            modal: true,
            type: 'inline',
            preloader: false,
            closeBtnInside: true,
            // Inital focused element
            focus: options2.modal.focusedElementSelector,            
            // Disable mobile focus auto zoom.
            callbacks: {
                beforeOpen: function () {


                    if ($(window).width() < 700) {
                        this.st.focus = false;
                    } else {
                        this.st.focus = options2.modal.focusedElementSelector;
                    }
                }
            }
        });






        var stateunitedID = 1;

        // var stateUrlTemplate = '/stateunited/{stateunitedid}/gethistoryajax';
        var stateunitedHistoryPath  = '/stateunited/gethistoryajax';
        var SelectedId;



        var $table2 = $(options_state.tableId).DataTable(
            {
                "order": [0, 'desc'],
               

                "columnDefs": [
                   // { "title": "#", "targets": [0] },
                    { "title": "Ном. зак. dpd", "targets": [0] },
                    { "title": "Статус", "targets": [1] },
                    { "title": "Дата транзита", "targets": [2] },
                    { "title": "Код терминала", "targets": [3] },
                    { "title": "Город терминала", "targets": [4] }
                    //{ "title": "Код инцидента", "targets": [5] },
                    //{ "title": "Наим. инцидента", "targets": [6] }
                    //{ "title": "Грузополучатель", "targets": [7] }


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
                    "url": stateunitedHistoryPath,
                    "type": "POST",
                    "dataType": "JSON",
                    "data": function(d) {
                        d.stateunitedid = stateunitedID;
                    }                  
                                        
                },
                "columns": [
                   // { "data": "id" },
                    { "data": "dpdOrderNr" },
                    { "data": "newState" },
                    { "data": "transitionTime" },
                    { "data": "terminalCode" },
                    { "data": "terminalCity" }
                   // { "data": "incidentCode" },
                    //{ "data": "incidentName" }
                    //{ "data": "consignee" }


                ]
            });




        $('#stateunitedTable').on('page.dt', function () {

           
            //var info = table.page.info();
            //$('#pageInfo'String).html('Showing page: 'String + info.page + ' of 'String + info.pages);

        });




        $('#stateunitedTable tbody').on('click', 'tr', function () {

            
            $(options2.modal.triggerSelector).magnificPopup({

                modal: true,
                type: 'inline',
                preloader: false,
                closeBtnInside: true,
                // Inital focused element
                focus: options2.modal.focusedElementSelector,
                // Disable mobile focus auto zoom.
                callbacks: {
                    beforeOpen: function () {
                       
                        if ($(window).width() < 700) {
                            this.st.focus = false;
                        } else {
                            this.st.focus = options2.modal.focusedElementSelector;
                        }
                    }
                }
            });




            SelectedId = $(this).attr('data-item-id');

            alert(SelectedId);

            $('#currstateunitedid').val(SelectedId);

            //stateunitedID = $('#currstateunitedid').val();

            stateunitedID = SelectedId;

            // alert(SelectedId);

            //$table2.rows().remove().draw();

           

            $table2.clear().draw();
            $table2.data = null;
            //$table2.clearTable().fnDraw();
            $table2.ajax.reload();
          
          

            //$table2.clearTable();
            //$table2.fnAddData(data.stateunitedID); //the data part of your json message
            //$table2.fnDraw();


            //stateunitedPath = stateUrlTemplate.replace(/{stateunitedid}/g, stateunitedid);


        });

        


        $(options2.modal.wrapperId).on('click', options2.modal.dismissActionSelector, function (e) {
            e.preventDefault();
            $.magnificPopup.close();
        });

        


    });




}).apply(this, [jQuery, window.admin]);