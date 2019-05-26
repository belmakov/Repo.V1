
var apartmentAssociation = function () {

    var dataList = null;
    var deletedRows = [];
    var addRows = [];
    var editDataTable2 = $('#edit_apartment_association');
    var screenActionsDiv = $('#screenActions');
    var gridActionsDiv = $('#gridActions_aa');

    (function ($) {
        'use strict';

        var dataSet = [];
        var EditableTable = $.extend({}, dataTable_Edit_Settings, {
            tableOptions: {
                "bAutoWidth": false,
                data: dataSet,
                "columns": [
                    { "data": "resident_name" },
                    { "data": "association_role" }
                ],
            },
            options: {
                addButton: '#addToAssociation',
                table: '#edit_apartment_association',
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
                        cell.html(this.createTextBox(data,'resident_name'));
                        break;
                    }
                    case 1: {
                        cell.html(this.createTextBox(data,'association_role'));
                        break;
                    }

                }
            },
            getDefaultData: function () {
                return {
                    "resident_name": "",
                    "association_role": ""
                };
            },
            getControlValue: function (cell, cIndex, rIndex) {
                return this.getControlValueFromCell(cell);
            },
            onRowEditable: function () {
                $('#resident_name').focus();
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
            EditableTable.initialize();
        });

    }).apply(this, [jQuery]);

    this.populateDataTable=function(datalist) {

        if (datalist != null) {
            var gridObject = editDataTable2.DataTable();
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
        var gridObject = editDataTable2.DataTable();
        gridObject.clear().draw();
    }
    function backupDeletedRow(data) {
        deletedRows.push(data);
    }
    function getGridEditedData() {
        var editDataTable2 = [];
        editDataTable2.DataTable().data().each(function (d) {
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


    this.doAjaxToGetApartmentAssociation=function() {
        this.populateDataTable([{ "resident_name": "Sankaran", "association_role": "member" }]);
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