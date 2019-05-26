var apartmentResident = function () {
    var dataList = null;
    var deletedRows = [];
    var addRows = [];
    var editDataTable1 = $('#edit_apartment_residents');
    var screenActionsDiv = $('#screenActions');
    var gridActionsDiv = $('#gridActions_Residents');

    (function ($) {
        'use strict';

        var dataSet = [];
        var EditableTable = $.extend({}, dataTable_Edit_Settings, {
            tableOptions: {
                "bAutoWidth": false,
                data: dataSet,
                "columns": [
                    { "data": "first_name" },
                    { "data": "last_name" },
                    { "data": "email" },
                    { "data": "phone" },
                    { "data": "block" },
                    { "data": "flat" },
                    { "data": "owner_tenant" }
                ],
            },
            options: {
                addButton: '#addToResidents',
                table: '#edit_apartment_residents',
                dialog: {
                    wrapper: '#dialog',
                    cancelButton: '#dialogCancel',
                    confirmButton: '#dialogConfirm'
                },
                edit: true,
                delete: true
            },
            onCellCreate: function (cell, data, index) {


                switch (index) {
                    case 0: {
                        cell.html(this.createTextBox(data,'first_name'));
                        break;
                    }
                    case 1: {
                        cell.html(this.createTextBox(data,'last_name'));
                        break;
                    }
                    case 2: {
                        cell.html(this.createTextBox(data,'email'));
                        break;
                    }
                    case 3: {
                        cell.html(this.createTextBox(data,'phone'));
                        break;
                    }
                    case 4: {
                        cell.html(this.createTextBox(data,'block', data.flat));
                        break;
                    }
                    case 5: {
                        cell.html(this.createTextBox(data, 'flat', data.flat));
                        break;
                    }
                    case 6: {
                        cell.html(this.createTextBox(data,'owner_tenant', data.owner_tenant));
                        break;
                    }
                }
            },
            getDefaultData: function () {
                return {
                    "first_name": "",
                    "last_name": "",
                    "email": "",
                    "phone": "",
                    "block":"",
                    "flat": "",
                    "owner_tenant": ""
                };
            },
            getControlValue: function (cell, cIndex, rIndex) {
                return this.getControlValueFromCell(cell);
            },
            onRowEditable: function () {
                $('#first_name').focus();
            },
            beforeSave: function () {
                return true;
            },
            onRowDelete: function (row) {
                var data = this.datatable.row(row.get(0)).data();
                if (data[this.client_operation] != 'add') {
                    data.dataTableOperation = data[this.client_operation];
                    backupDeletedRow(data);
                }
                return true;
            },
            onCustomControlSelect: function (e, s) {

            }
        });

        $(function () {
            EditableTable.initialize('ar');
        });

    }).apply(this, [jQuery]);

    this.populateDataTable = function(datalist) {

        if (datalist != null) {
            var gridObject = editDataTable1.DataTable();
            gridObject.clear().rows.add(datalist).draw();
            showHideActions(true);

        }
        else {
            clearGrid();
            showHideActions(false);
        }

    }
    function showHideActions(show) {
        if (show) {
            screenActionsDiv.removeClass("hidden");
            gridActionsDiv.removeClass("hidden");

        }
        else {
            screenActionsDiv.addClass("hidden");
            gridActionsDiv.addClass("hidden");
        }
    }
    function clearGrid() {
        var gridObject = editDataTable1.DataTable();
        gridObject.clear().draw();
    }
    function backupDeletedRow(data) {
        deletedRows.push(data);
    }
    function getGridEditedData() {
        var editDataTable1 = [];
        editDataTable1.DataTable().data().each(function (d) {
            var data = d;
            var operation = data.dataTableOperation;
            if (operation == 'edit')
                editedData.push(data);
            else if (operation == 'delete')
                deletedRows.push(data);
        });
        if (deletedRows.length > 0) {
            deletedRows.forEach(function (item, index) {
                editedData.push(item);
            });
        }
        return editedData;
    }

    function showErrorMessage(errormsg) {
        $('#errorPanel').removeClass("hidden");
        $('#errorPanel').append(errormsg);
    }
    function showSuccessMessage() {
        $('#canvas').addClass("hidden");
        $('#canvasFooter').addClass("hidden");
        $('#successPanel').removeClass("hidden");
    }


    this.doAjaxToGetApartment = function() {
        this.populateDataTable([{ "first_name": "Sankaran", "last_name": "K S","email":"sankaranks@ft.com","phone":"9550782489","block":"Block 1","flat":"112","owner_tenant":"Owner" }]);
        return;
     
    }

    function onApartmentSave() {
        var dataToPost = getGridEditedData();
        doAjax({
            url: 'MaintainDataPatternFromUI',
            type: 'POST',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(dataToPost),
            success: function (data) {
                if (data.status == 0) {
                    showSuccessMessage();
                }
                else {
                    var errmsg = "";
                    data.errors.forEach(function (item, index) {
                        errmsg += "\n" + item.errorCode + item.errorDescription;
                    });
                    showErrorMessage(errmsg);
                }
            }
        }, "canvas");
    }
}