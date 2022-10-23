$(function () {
    var l = abp.localization.getResource('PlastikMarketim');
    //var detailModal = new abp.ModalManager(abp.appPath + 'Product/Detail');

    var getFilter = function () {
        return {
            gtinFilter: $("#NameFilter").val()           
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
                                    text: l('NotificationDetail'),
                                    action: function (data) {
                                        detailModal.open({ ProductId: data.record.id });
                                    }
                                }                              
                            ]
                    }
                },
                {
                    title: l('ProductName'),
                    data: "name",
                    render: function (data) {
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
                        return data;
                    }
                },
                //{
                //    title: l('ProductName'),
                //    data: "name",
                //    render: function (data) {
                //        if (data === null || data === '') {
                //            return '-'
                //        }
                //        return data;
                //    }
                //},
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


    $(document).on('click', '#btnSelectedSend', function (e) {
        var checkedList = $.map($('input[class="child"]:checked'), function (c) { return c.value; });
        var totalSelectedCount = checkedList.length;

        if (totalSelectedCount !== 0) {
            abp.message.confirm('Seçili ' + totalSelectedCount + ' kayıt için ITS sistemine numune üretim bildirimi yapılacak. Onaylıyor musunuz?')
                .then(function (confirmed) {
                    if (confirmed) {
                        numuneTakip.services.productDetail.sendMultiple(checkedList, false);

                        abp.notify.info("Gönderiliyor...");
                        $('.loading').show();
                    }
                })
                .then(function () {
                    setTimeout(function () {
                        window.location.reload();
                    }, 2000)
                });
        }
        else {
            abp.notify.info("Lütfen bildirilecek olan kayıtları işaretleyiniz.");
        }
    });

    //$(document).on('change', '.parent', function (e) {
    //    var $related = $('input[name="' + $(this).attr("name") + '"]');
    //    if (this.checked) {
    //        $related.prop("checked", true);
    //    }
    //    else {
    //        $related.prop("checked", false);
    //    }
    //});

});