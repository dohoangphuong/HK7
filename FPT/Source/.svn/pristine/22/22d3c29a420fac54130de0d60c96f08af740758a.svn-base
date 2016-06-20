$(function () {
    $("#gridDirectorates").jqGrid({
        url: "/Directorates/GetDirectoratesLists",
        datatype: 'json',
        mtype: 'Get',
        colNames: ['Directorate ID',
            'Directorate Name',
            'Office Address Line 1',
            'Postcode',
            'Contact',
            'Is Active?'],

        colModel: [
            { key: true, hidden: true, name: 'DirectorateID', index: 'DirectorateID', editable: true },
            {
                key: false, name: 'DirectorateName', index: 'DirectorateName', editable: true,
                formatter: function (cellvalue, options, rowObject) {
                    return '<a class="linkItem" href="/Directorates/AmendDirectorateDetails?DirectorateID=' +
                        rowObject.DirectorateID +
                        '">' +
                        cellvalue + "</a>";
                }
            },
            { key: false, name: 'DirectorateAddressLine1', index: 'DirectorateAddressLine1', editable: true },
            { key: false, name: 'DirectoratePostcode', index: 'DirectoratePostcode', editable: true },
            { key: false, name: 'ContactID', index: 'ContactID', editable: true },
            { key: false, name: 'DirectorateStatus', index: 'DirectorateStatus', editable: true }],
        pager: jQuery('#pager'),
        rowNum: 10,
        //rowList: [10, 20, 30, 40],        // Allow user display number records in grid, may be 10, 20 or 30...
        height: '35%',
        viewrecords: true,
        //caption: 'Directorates List',
        emptyrecords: 'No records to display',
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Id: "0"
        },
        autowidth: true,
        //multiselect: false
    });
});