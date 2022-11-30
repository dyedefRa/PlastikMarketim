$(function () {
    var l = abp.localization.getResource('PlastikMarketim');
    var editModal = new abp.ModalManager(abp.appPath + 'Admin/Category/Edit');
    var createModal = new abp.ModalManager(abp.appPath + 'Admin/Category/Create');
    var deleteModal = new abp.ModalManager(abp.appPath + 'Admin/Category/Delete');

    var getFilter = function () {
        return {
            nameFilter: $("#NameFilter").val()
        };
    };

    var dataTable = $('#CategoriesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(plastikMarketim.services.category.getCategoryList, getFilter),
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
                    title: l('CategoryName'),
                    data: "name",
                    render: function (data) {
                        return data;
                    }
                },
                {
                    title: l('Description'),
                    data: "description",
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