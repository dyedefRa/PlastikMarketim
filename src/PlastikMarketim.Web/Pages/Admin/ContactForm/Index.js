$(function () {
    var l = abp.localization.getResource('PlastikMarketim');

    var getFilter = function () {
        return {
            fullNameFilter: $("#FullNameFilter").val(),
            emailFilter: $("#EmailFilter").val()
        };
    };

    var dataTable = $('#ContactFormsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(plastikMarketim.services.contactForm.getContactFormList, getFilter),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                            ]
                    }
                },
                {
                    title: l('FullName'),
                    data: "fullName",
                    render: function (data) {
                        if (data === null || data === '') {
                            return '';
                        }
                    }
                },
                {
                    title: l('Email'),
                    data: "email",
                    render: function (data) {
                        if (data === null || data === '') {
                            return '';
                        }
                        return data;
                    }
                },
                {
                    title: l('PhoneNumber'),
                    data: "phoneNumber",
                    render: function (data) {
                        return data;
                    }
                },
                {
                    title: l('Subject'),
                    data: "subject",
                    render: function (data) {
                        if (data === null || data === '') {
                            return '';
                        }
                        return data;
                    }
                },
                {
                    title: l('MailSubject'),
                    data: "message",
                    render: function (data) {
                        if (data === null || data === '') {
                            return '';
                        }
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
});