$(function () {
    $("#gridSupportingMaterial").jqGrid({
        url: "/SupportingMaterials/GetSupportingMaterialsLists",
        datatype: 'json',
        mtype: 'Get',
        colNames: ['SupportingMaterialID',
            'UserID',
            'OrgID',
            'URL',
            'Type',
            'AddedDate',
            'SupportingMaterialDescription'],

        colModel: [
            { key: true, hidden: true, name: 'SupportingMaterialID', index: 'SupportingMaterialID', editable: true },
            { key: false, hidden: true, name: 'UserID', index: 'UserID', editable: true },
            { key: false, hidden: true, name: 'OrgID', index: 'OrgID', editable: true },
            {
                key: false, name: 'URL', index: 'URL', editable: true,
                formatter: function (cellvalue, options, rowObject) {
                    return '<a class="linkItem" href="/SupportingMaterials/AmendSupportingMaterialsDetails?SupportingMaterialID=' +
                    rowObject.SupportingMaterialID +
                    '">' +
                    cellvalue + "</a>";
                }
            },
            { key: false, name: 'Type', index: 'Type', editable: true },
            { key: false, name: 'AddedDate', index: 'AddedDate', editable: true },
            { key: false, name: 'SupportingMaterialDescription', index: 'SupportingMaterialDescription', editable: true }],
        pager: jQuery('#pager'),
        rowNum: 10,
        //rowList: [10, 20, 30, 40],        // Allow user display number records in grid, may be 10, 20 or 30...
        height: '35%',
        viewrecords: true,
        //caption: 'SupportingMaterials List',
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