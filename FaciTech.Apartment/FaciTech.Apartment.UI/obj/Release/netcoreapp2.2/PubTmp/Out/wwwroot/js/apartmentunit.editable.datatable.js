var block_floor = [];

$(document).ready(function () {
    $("body").on("change", "#block", function (e) {
        $('#floor').empty();
        $('<option/>').val("").html("[Select]").appendTo('#floor');
        block_floor.forEach(function (v) {
            if (v.block_name == $('#block option:selected').text()) {
                v.floors.forEach(function (v1) {
                    $('<option/>').val(v1.key).html(v1.value).appendTo('#floor');
                }
                );
            }
        });
    });
});
function apartmentUnit() {
    var dataList = null;
    var deletedRows = [];
    var addRows = [];
    var editDataTable_units = $('#edit_apartment_units');
    var screenActionsDiv = $('#screenActions');
    var gridActionsDiv = $('#gridActions_units');

    (function ($) {
        'use strict';

        var dataSet = [];
        var EditableTable = $.extend({}, dataTable_Edit_Settings, {
            tableOptions: {
                "bAutoWidth": false,
                data: dataSet,
                "columns": [
                    { "data": "flat" },
                    { "data": "block" },
                    { "data": "floor" },
                    { "data": "specification" }
                ],
            },
            options: {
                addButton: '#addToUnit',
                table: '#edit_apartment_units',
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
                        cell.html(this.createTextBox(data,'flat'));
                        break;
                    }
                    case 1: {
                        cell.html(this.createDropdown('block', block_floor, "block_name", "id", data,"block","block_id"));
                        break;
                    }
                    case 2: {
                        cell.html(this.createDropdown('floor', [],"","",data,"floor","floor_number"));
                        break;
                    }
                    case 3: {
                        cell.html(this.createTextBox(data,'specification'));
                        break;
                    }
                }
            },
            getDefaultData: function () {
                return {
                    "flat": "",
                    "block": "",
                    "block_id":0,
                    "floor": "",
                    "specification": ""
                };
            },
            getControlValue: function (cell, cIndex, rIndex) {
                return this.getControlValueFromCell(cell);
            },
            onRowEditable: function () {
                $('#flat').focus();
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
                saveUnit(data);
            }
        });

        $(function () {
            EditableTable.initialize();
        });

    }).apply(this, [jQuery]);

    this.populateDataTable = function (datalist) {

        if (datalist != null) {
            var gridObject = editDataTable_units.DataTable();
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
        var gridObject = editDataTable_units.DataTable();
        gridObject.clear().draw();
    }
    function backupDeletedRow(data) {
        deletedRows.push(data);
    }
    function getGridEditedData() {
        var editDataTable_units = [];
        editDataTable_units.DataTable().data().each(function (d) {
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


    this.doAjaxToGetApartmentUnits = function () {
        var _self = this;
        $.get({
            url: '/Admin/Unit/Get?communityId=' + $('#community_id').val(),
            success: function (res) {
                _self.populateDataTable(res.data);
            }
        });
        $.get({
            url: '/Admin/CommunityBlock/Get?communityId=' + $('#community_id').val(),
            success: function (res) {
                block_floor = res.data;
            }
        });
        return;

    }
    function saveUnit(data) {

        var id = "";
        if (typeof (data["id"]) != 'undefined') {
            id = data["id"];
        }
        var dataToPost = {
            "community_id": $("#community_id").val(),
            "flat": data.flat,
            "block_id": data.block_id,
            "floor_number": data.floor_number,
            "specification": data.specification,
            "id":id
        };
        $.ajax(
            {
                url: '/Admin/Unit/Save',
                type: 'POST',
                dataType: 'json',
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(dataToPost),
                success: function (data) {
                }
            });
    }
}