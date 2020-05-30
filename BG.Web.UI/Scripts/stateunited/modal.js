(function ($, admin) {

    'use strict';

    var options = {
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



    var options_position = {
        tableId: '#stateTable'
        //deleteDialogId: '#tendersDeleteDialog',
        //deleteUrlTemplate: '/tenders/{itemId}/delete'
    };


    // Init
    $(function () {



        var $table2 = admin.tables.create(options_position.tableId);

        $table2.order([0, 'desc']).draw();

        var SelectedId = 0;

        var TenderId = $('#tenderid').val();

        $('#stateTable tbody').on('click', 'tr', function () {

            SelectedId = $(this).attr('data-item-id');

            //console.log( SelectedId);

            if ($(this).hasClass('position-selected')) {

                $(this).removeClass('position-selected');

            }

            else {

                $table2.$('tr.position-selected').removeClass('position-selected');

                $(this).addClass('position-selected');

            }

        });

        $('#state-modal-confirm').click(function () {

            var rowId = $table2.row('.position-selected').data().DT_RowId;

            console.log(rowId);

            var addPath = '/lots/' + TenderId + '/' + rowId + '/add';

            var errorMessageTitle = "Ошибка";
            var errorMessageContent = "Лот не добавлен";

            var successMessageTitle = "Тендер № 123 ";
            var successMessageContent = "Лот успешно добавлен к тендеру! ";

            $.post(addPath)
                .done(function () {
                    // Use the 'page' parameter to
                    // avoids recalculating sort and paging
                    //$table.row($row.get(0)).remove().draw('page');
                    admin.notify.success(successMessageTitle, successMessageContent);


                })
                .fail(function () {
                    admin.notify.error(errorMessageTitle, errorMessageContent);


                    setTimeout(function () {
                        location.href = '/lots/?tenderid=' + TenderId;
                    }, 1000);

                })
                .always(function () {
                    $.magnificPopup.close();

                    setTimeout(function () {
                        location.href = '/lots/?tenderid=' + +TenderId;
                    }, 1000);

                });


        });

        //admin.validation.init(options.formId);

        $(options.modal.triggerSelector).magnificPopup({


            modal: true,
            type: 'inline',
            preloader: false,
            closeBtnInside: true,



            // Inital focused element
            focus: options.modal.focusedElementSelector,

            // Disable mobile focus auto zoom.
            callbacks: {
                beforeOpen: function () {
                    if ($(window).width() < 700) {
                        this.st.focus = false;
                    } else {
                        this.st.focus = options.modal.focusedElementSelector;
                    }
                }
            }
        });


        $(options.modal.wrapperId).on('click', options.modal.dismissActionSelector, function (e) {
            e.preventDefault();
            $.magnificPopup.close();
        });

        $(options.modal.wrapperId).on('click', options.modal.confirmActionSelector, function (e) {

            e.preventDefault();

            var isValidForm = $(options.formId).valid();

            if (isValidForm) {

                var formData = $(options.formId).serialize();

                $.post(options.modal.actionUrl, formData).done(function (contact) {

                    admin.events.trigger('dot:contact-created', [contact]);

                    $.magnificPopup.close();

                }).fail(function () {

                    var $modalWrapper = $(options.modal.wrapperId);
                    var modalErrorMessageTitle = $modalWrapper.data('msg-error-title');
                    var modalErrorMessageContent = $modalWrapper.data('msg-error-content');

                    admin.notify.error(msg.title, msg.content);

                });

            }

        });

    });


}).apply(this, [jQuery, window.admin]);
