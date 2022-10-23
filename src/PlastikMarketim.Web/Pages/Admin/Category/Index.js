$(function () {
    var l = abp.localization.getResource('NumuneTakip');
    //var errorDetailModal = new abp.ModalManager(abp.appPath + 'Document/ErrorDetail');

    //var getFilter = function () {
    //    var normInsertedDate = GetNormalizeDate($("#InsertedDateFilter").val());

    //    return {
    //        gtinFilter: $("#GtinFilter").val(),
    //        lotNumberFilter: $("#LotNumberFilter").val(),
    //        documentNumberFilter: $("#DocumentNumberFilter").val(),
    //        insertedDateFilter: normInsertedDate,
    //        documentStatusFilter: $("#DocumentStatusFilter").val()
    //    };
    //};

    var dataTable = $('#CategoriesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(plastikMarketim.services.document.getDocumentList, getFilter),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Details'),
                                    action: function (data) {
                                        errorDetailModal.open({ documentId: data.record.id });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Gtin'),
                    data: "gtin",
                    render: function (data) {
                        return data;
                    }
                },
                {
                    title: l('LotNumber'),
                    data: "lotNumber",
                    render: function (data) {
                        return data;
                    }
                },
                {
                    title: l('DocumentNumber'),
                    data: "documentNumber",
                    render: function (data) {
                        return data;
                    }
                },
                {
                    title: l('DocumentPath'),
                    data: "documentPath",
                    render: function (data) {
                        return data;
                    }
                },
                {
                    title: l('TotalErrorCount'),
                    data: "totalErrorCount",
                    render: function (data) {
                        return data;
                    }
                },
                {
                    title: l('InsertedDate'), data: "insertedDate",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                },
                {
                    title: l('DocumentStatus'),
                    data: "documentStatus",
                    render: function (data) {
                        return l('Enum:DocumentStatus:' + data);
                    }
                }
            ],
            createdRow: function (nRow, aData) {
                /*console.log(aData);*/
            }
        })
    );

    $('#btnSearch').on('click', function (e) {
        $('.loading').show();

        dataTable.ajax.reload(() => {
            $('.loading').hide();
        });
    });

});