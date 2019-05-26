
function apartmentBlock() {
    var dataList = null;
    var deletedRows = [];
    var addRows = [];
    var editDataTable = $('#edit_apartment_blocks');
    var screenActionsDiv = $('#screenActions');
    var gridActionsDiv = $('#gridActions');

    (function ($) {
        'use strict';
        if ($.fn.DataTable.isDataTable('#edit_apartment_blocks')) {
            $('#edit_apartment_blocks').DataTable().destroy();
        }
        var dataSet = [];
        var EditableTable = $.extend({}, dataTable_Edit_Settings, {
            tableOptions: {
                "bAutoWidth": false,
                data: dataSet,
                "columns": [
                    { "data": "block_name" },
                    { "data": "no_of_floors" }
                ]
            },
            options: {
                addButton: '#addToBlock',
                table: '#edit_apartment_blocks',
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
                        cell.html(this.createTextBox(data,'block_name'));
                        break;
                    }
                    case 1: {
                        cell.html(this.createTextBox(data,'no_of_floors'));
                        break;
                    }

                }
            },
            getDefaultData: function () {
                return {
                    "block_name": "",
                    "no_of_floors": 0,
                    "id":0
                };
            },
            getControlValue: function (cell, cIndex, rIndex) {
                return this.getControlValueFromCell(cell);
            },
            onRowEditable: function () {
                $('#block_name').focus();
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

            },
            afterSave: function (data) {
                saveCommunityBlock(data);
            }
        });

        $(function () {
            EditableTable.initialize('ab');
        });

    }).apply(this, [jQuery]);

    this.populateDataTable = function (datalist) {

        if (datalist != null) {
            var gridObject = editDataTable.DataTable();
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
        var gridObject = editDataTable.DataTable();
        gridObject.clear().draw();
    }
    function backupDeletedRow(data) {
        deletedRows.push(data);
    }
    function getGridEditedData() {
        var editedData = [];
        editDataTable.DataTable().data().each(function (d) {
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


    this.doAjaxToGetApartmentBlocks = function () {
        var self = this;
        $.get({
            url: '/Admin/CommunityBlock/Get?communityId=' + $('#community_id').val(),
            success: function (res) {
                block_floor = res.data;
                self.populateDataTable(block_floor);
            }
        });
        
        return;
    }


}

function saveCommunityBlock(data) {

    var id = "";
    if (typeof(data["id"]) != 'undefined')
    {
        id = data["id"];
    }
    var dataToPost = {
        "community_id": $("#community_id").val(),
        "block_name": data.block_name,
        "no_of_floors": data.no_of_floors,
        "id":id
    };
    $.ajax(
        {
            url: '/Admin/CommunityBlock/Save',
            type: 'POST',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(dataToPost),
            success: function (res) {
                data.id = res.data.id;
            }
        });
} 