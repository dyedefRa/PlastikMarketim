$(function () {
    var l = abp.localization.getResource('PlastikMarketim');
    var editModal = new abp.ModalManager(abp.appPath + 'Admin/Product/Edit');
    var createModal = new abp.ModalManager(abp.appPath + 'Admin/Product/Create');
    var deleteModal = new abp.ModalManager(abp.appPath + 'Admin/Product/Delete');

    var getFilter = function () {
        return {
            nameFilter: $("#NameFilter").val()
        };
    };

    var dataTable = $('#ProductsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(plastikMarketim.services.product.getProductList, getFilter),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    action: function (data) {
                                        deleteModal.open({ id: data.record.id });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('ProductName'),
                    data: "name",
                    render: function (data) {
                        if (data === null || data === '') {
                            return '-'
                        }
                        return data;
                    }
                },
                {
                    title: l('Unit'),
                    data: "unit",
                    render: function (data) {
                        return data;
                    }
                },
                {
                    title: l('Price'),
                    data: "price",
                    render: function (data) {
                        return data;
                    }
                },
                {
                    title: l('Image'),
                    data: "fileUrl",
                    render: function (data) {
                        if (data === null || data === '') {
                            return '';
                        }
                        return '<img  src= "' + data + '"  class="form-group" width="80"  />';
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
                    title: l('Status'),
                    data: "status",
                    render: function (data) {
                        return l('Enum:Status:' + data)
                    }
                }
            ],
            createdRow: function (nRow, aData) {
            }
        })
    );

    $('#btnSearch').on('click', function (e) {
        $('.loading').show();

        dataTable.ajax.reload(() => {
            $('.loading').hide();
        });
    });

    $('#btnNew').on('click', function (e) {
        createModal.open({});
    });

    createModal.onResult(function () {
        dataTable.ajax.reload();
        abp.notify.info(l('Successfully'));
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
        abp.notify.info(l('Successfully'));
    });

    deleteModal.onResult(function () {
        dataTable.ajax.reload();
        abp.notify.info(l('Successfully'));
    });
});