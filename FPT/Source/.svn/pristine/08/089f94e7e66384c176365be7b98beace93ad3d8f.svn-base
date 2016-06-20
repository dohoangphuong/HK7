$(function () {
    $("#gridOrganisation").jqGrid({
        url: "/Organisation/GetOrganisationLists",
        datatype: 'json',
        mtype: 'Get',
        colNames: ['OrganisationID',
            'Organisation Name',
            'Head Office Address Line 1',
            'Postcode',
            'Contact'],
        colModel: [
            { key: true, hidden: true, name: 'OrgID', index: 'OrgID', editable: true },

            {
                key: false, name: 'OrgName', index: 'OrgName', editable: true, formatter: function (cellvalue, options, rowObject) {
                    return '<a class="linkItem" href="/Organisation/AmendOrganisationDetails?OrgID=' +
                        rowObject.OrgID +
                        '">' +
                        cellvalue + "</a>";
                }
            },
            { key: false, name: 'OrganisationAddressLine1', index: 'OrganisationAddressLine1', editable: true },
            { key: false, name: 'OrganisationPostode', index: 'OrganisationPostode', editable: true },
            { key: false, name: 'ContactID', index: 'ContactID', editable: true }],
        pager: jQuery('#pager'),
        rowNum: 10,
        //rowList: [10, 20, 30, 40],        // Allow user display number records in grid, may be 10, 20 or 30...
        height: '35%',
        viewrecords: true,
        //caption: 'Organisation List',
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
        multiselect: false
    });
});