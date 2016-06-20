$(function () {
    $("#gridDepartment").jqGrid({
        url: "/Department/GetDepartmentLists",
        datatype: 'json',
        mtype: 'Get',

        colNames: ['Department ID',
            'Department Name',
            'Address Line 1',
            'Postcode',
            'Contact'],

        colModel: [
            { key: true, hidden:true, name: 'DepartmentID', index: 'DepartmentID', editable: true},
            {
                key: false, name: 'DepartmentName', index: 'DepartmentName', editable: true,
                formatter: function (cellvalue, options, rowObject) {
                    return '<a class="linkItem" href="/Department/AmendDepartmentDetails?DepartmentID=' +
                        rowObject.DepartmentID +
                        '">' +
                        cellvalue + "</a>";
                }
            },
            { key: false, name: 'DepartmentAddressLine1', index: 'DepartmentAddressLine1', editable: true },
            { key: false, name: 'DepartmentPostcode', index: 'DepartmentPostcode', editable: true },
            { key: false, name: 'ContactID', index: 'ContactID', editable: true }],

        pager: jQuery('#pager'),
        rowNum: 10,
        //rowList: [10, 20, 30, 40],        // Allow user display number records in grid, may be 10, 20 or 30...
        height: '35%',
        viewrecords: true,
        //caption: 'Department List',
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
    });
});