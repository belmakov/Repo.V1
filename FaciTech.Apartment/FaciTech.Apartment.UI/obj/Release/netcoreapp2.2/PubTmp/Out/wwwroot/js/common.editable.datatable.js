var dataTable_Edit_Settings = {

    client_operation: 'dataTableOperation',
    initialize: function (source) {
        this.source = '';
        if (typeof (source) != 'undefined') {
            this.source = '-' + source;
        }
        this
            .setVars()
            .build()
            .events();
    },
    setVars: function () {

        this.$table = $(this.options.table);
        this.$addButton = $(this.options.addButton == null ? '' : this.options.addButton);

        var _dialog = $.extend({}, { wrapper: '', cancelButton: '', confirmButton: '' }, this.options.dialog);

        // dialog
        this.dialog = {};
        this.dialog.$wrapper = $(_dialog.wrapper);
        this.dialog.$cancel = $(_dialog.cancelButton);
        this.dialog.$confirm = $(_dialog.confirmButton);

        this.popupEdit = {};
        this.popupEdit.$wrapper = $('#gridPopupEdit');
        this.popupEdit.$save = $('#gridPopupEditSave');
        this.popupEdit.$cancel = $('#gridPopupEditCancel');

        return this;
    },
    build: function () {

        if (this.tableOptions.columnDefs == undefined || this.tableOptions.columnDefs == null) {
            this.tableOptions.columnDefs = [];
        }
        var html = this.createActionButtonHtml(false);
        this.tableOptions.columnDefs.push(
            {
                "targets": this.tableOptions.columns.length,
                "data": null,
                "render": function () {
                    return html;
                }
            });

        if (this.tableOptions.dom == undefined) {
            this.tableOptions.dom = '<"row"<"col-lg-6"l><"col-lg-6"f>><"table-responsive"t>p';
        }
        this.datatable = this.$table.DataTable(this.tableOptions);

        window.dt = this.datatable;

        return this;
    },
    events: function () {
        var _self = this;
        this.$table
            .on('click', 'a.save-row' + this.source, function (e) {
                e.preventDefault();

                _self.rowSave($(this).closest('tr'));
            })
            .on('click', 'a.cancel-row' + this.source, function (e) {
                e.preventDefault();

                _self.rowCancel($(this).closest('tr'));
            })
            .on('click', 'a.edit-row' + this.source, function (e) {
                e.preventDefault();

                _self.rowEdit($(this).closest('tr'));
            })
            .on('click', 'a.editmore-row' + this.source, function (e) {
                e.preventDefault();
                _self.rowEditMore($(this).closest('tr'));
            })
            .on('click', '.custom-control' + this.source, function (e) {
                if (_self.onCustomControlSelect) {
                    _self.onCustomControlSelect(e, _self);
                }
            })
            .on('click', 'a.remove-row' + this.source, function (e) {
                e.preventDefault();

                var $row = $(this).closest('tr'),
                    itemId = $row.attr('data-item-id');

                $.magnificPopup.open({
                    items: {
                        src: _self.options.dialog.wrapper,
                        type: 'inline'
                    },
                    preloader: false,
                    modal: true,

                    callbacks: {
                        change: function () {
                            _self.dialog.$confirm.on('click', function (e) {
                                e.preventDefault();
                                if (_self.onRowDelete($row)) {
                                    _self.rowRemove($row);
                                }
                                $.magnificPopup.close();
                            });
                        },
                        close: function () {
                            _self.dialog.$confirm.off('click');
                        }
                    }
                });
            });
        this.$addButton.on('click', function (e) {
            e.preventDefault();
            _self.rowAdd();
        });
        this.dialog.$cancel.on('click', function (e) {
            e.preventDefault();
            $.magnificPopup.close();
        });

        return this;
    },

    // ==========================================================================================
    // ROW FUNCTIONS
    // ==========================================================================================
    rowAdd: function () {
        if ($('.cancel-row' + this.source).not('.hidden').length > 0) {
            return;
        }
        this.$addButton.attr({ 'disabled': 'disabled' });
        var actions,
            data,
            $row;

        var defaultData = this.getDefaultData();
        defaultData[this.client_operation] = 'add';
        data = this.datatable.row.add(defaultData);
        $row = this.datatable.row(data).nodes().to$();

        $row
            .addClass('adding')
            .find('td:last')
            .addClass('actions');

        this.datatable.order([0, 'asc']).draw(); // always show fields
        this.rowEdit($row);


    },
    rowCancel: function ($row) {
        var _self = this,
            $actions,
            i,
            data;

        if ($row.hasClass('adding')) {
            this.rowRemove($row);
        } else {

            data = this.datatable.row($row.get(0)).data();
            this.datatable.row($row.get(0)).data(data);

            $actions = $row.find('td.actions' + this.source);
            if ($actions.get(0)) {
                this.rowSetActionsDefault($row);
            }

            this.datatable.draw();
        }
    },
    rowEdit: function ($row) {

        if ($('.cancel-row' + this.source).not('.hidden').length > 0) {
            return;
        }
        var _self = this,
            data,
            hasCells = false;

        var actionIndex = this.tableOptions.columnDefs[this.tableOptions.columnDefs.length - 1].targets;
        data = this.datatable.row($row.get(0)).data();

        if (data[this.client_operation] == undefined) {
            data[this.client_operation] = 'edit';
        }

        $row.children('td').each(function (i) {
            var $this = $(this);

            if ($this.hasClass('actions')) {
                _self.rowSetActionsEditing($row);
            } else {
                if (actionIndex == i) {
                    $this.html(_self.createActionButtonHtml(true));
                }
                else {
                    _self.onCellCreate($this, data, i);
                }

                hasCells = true;
            }
        });

        _self.onRowEditable();
    },
    rowEditMore: function ($row) {

        if ($('.cancel-row').not('.hidden').length > 0) {
            return;
        }
        var _self = this,
            data,
            hasCells = false;

        var actionIndex = this.tableOptions.columnDefs[this.tableOptions.columnDefs.length - 1].targets;
        data = this.datatable.row($row.get(0)).data();

        if (data[this.lient_operation] == undefined) {
            data[this.client_operation] = 'edit';
        }
        $('#modelForm').html("");
        var count = 0;
        var htmlString = '';
        $.each(this.options.editmoreData, function (index, mapData) {

            if (count % 2 == 0) {
                htmlString += '<div class="row form- group">';
            }
            htmlString += '<div class="col-lg-6">';
            htmlString += '<div class="form-group">';
            htmlString += "\r\n\t <label>" + mapData.header + "</label>";
            htmlString += _self.createFormElement(index, data);
            htmlString += "</div>";
            htmlString += "</div>";
            count++;
            if (count % 2 == 0) {
                htmlString += "</div>";
            }

        });
        $('#modelForm').append(htmlString);
        $.magnificPopup.open({
            items: {
                src: _self.popupEdit.$wrapper,
                type: 'inline'
            },
            preloader: false,
            modal: true,

            callbacks: {
                change: function () {
                    _self.popupEdit.$save.on('click', function (e) {
                        e.preventDefault();
                        $.each(_self.options.editmoreData, function (index, mapData) {
                            data[mapData.data] = $('#' + mapData.element).prop('nodeName') == "INPUT" && $('#' + mapData.element).attr('type') == "checkbox" ? $('#' + mapData.element).is(":checked") : $('#' + mapData.element).val();
                            //data[mapData.data] = $('#' + mapData.element).checked();

                        });


                        _self.datatable.row($row).data(data);
                        $.magnificPopup.close();
                    });
                },
                close: function () {
                    _self.popupEdit.$save.off('click');
                }
            }
        });
        _self.popupEdit.$cancel.on('click', function (e) {
            e.preventDefault();
            $.magnificPopup.close();
        });
    },
    createFormElement: function (index, data) {
        return "";
    },
    updateColumnValue: function ($row, key, value) {
        var data = this.datatable.row($row.get(0)).data();
        data[key] = value;
    },
    createActionButtonHtml: function (isEditMode) {
        if (isEditMode) {
            return (this.options.edit ? '<a href="#" class="on-editing save-row' + this.source + ' datatable-action-button"><i class="fa fa-save"></i></a>' : '') +
                (this.options.edit ? '<a href="#" class="on-editing cancel-row' + this.source + ' datatable-action-button"><i class="fa fa-times"></i></a>' : '') +
                (this.options.edit ? '<a href="#" class="hidden edit-row' + this.source + ' datatable-action-button"><i class="fa fa-pencil"></i></a>' : '') +
                (this.options.edit ? '<a href="#" class="hidden remove-row' + this.source + ' datatable-action-button"><i class="fa fa-trash-o"></i></a>' : '');
        }
        else {
            return (this.options.edit ? '<a href="#" class="hidden on-editing save-row' + this.source + ' datatable-action-button"><i class="fa fa-save"></i></a>' : '') +
                (this.options.delete ? '<a href="#" class="hidden on-editing cancel-row' + this.source + ' datatable-action-button"><i class="fa fa-times"></i></a>' : '') +
                (this.options.edit ? '<a href="#" class="on-default edit-row' + this.source + ' datatable-action-button"><i class="fa fa-pencil"></i></a>' : '') +
                (this.options.editmore ? '<a href="#" class="on-default editmore-row' + this.source + ' datatable-action-button"><i class="fa fa-edit"></i></a>' : '') +
                (this.options.delete ? '<a href="#" class="on-default remove-row' + this.source + ' datatable-action-button"><i class="fa fa-trash-o"></i></a>' : '');
        }
    },
    rowSave: function ($row) {
        var _self = this,
            $actions,
            values = [];
        if (this.beforeSave && !this.beforeSave()) {
            return;
        }
        if ($row.hasClass('adding')) {
            this.$addButton.removeAttr('disabled');
            $row.removeClass('adding');
        }

        var index = 0;
        var elementValues = {};
        $row.find('td').each(function () {
            var $this = $(this);
            if ($this.hasClass('actions')) {
                _self.rowSetActionsDefault($row);
                //return _self.datatable.cell(this).data();
            } else {
                var res = _self.getControlValue($this, index++, $row.index());
                for (var key in res) {
                    if (res.hasOwnProperty(key)) {
                        var val = res[key];
                        elementValues[key] = val;
                    }
                }
            }
        });

        var data = this.datatable.row($row).data();
        for (var key in data) {
            if (data.hasOwnProperty(key) && elementValues.hasOwnProperty(key)) {
                data[key] = elementValues[key];
            }
        }
        this.tableOptions.columns.map(function (key, index) {
            data[key.data] = elementValues[key.data];
        });
        
        this.datatable.row($row).data(data);

        $actions = $row.find('td.actions');
        if ($actions.get(0)) {
            this.rowSetActionsDefault($row);
        }

        this.datatable.draw();
        if (this.afterSave && !this.afterSave(data)) {
            return;
        }
    },

    rowRemove: function ($row) {
        if ($row.hasClass('adding')) {
            this.$addButton.removeAttr('disabled');
        }
        var defaultData = this.datatable.row($row.get(0)).data();
        if (defaultData[this.client_operation] == undefined || defaultData[this.client_operation] != 'add') {
            defaultData[this.client_operation] = 'delete';
        }
        this.datatable.row($row.get(0)).remove().draw();
    },
    rowSetActionsEditing: function ($row) {
        $row.find('.on-editing').removeClass('hidden');
        $row.find('.on-default').addClass('hidden');
    },
    rowSetActionsDefault: function ($row) {
        $row.find('.on-editing').addClass('hidden');
        $row.find('.on-default').removeClass('hidden');
    },
    lockRow: function ($row) {
        var actionIndex = this.tableOptions.columnDefs[this.tableOptions.columnDefs.length - 1].targets;
        var td = $row.children("td")[actionIndex];
        $(td).html("");
    },
    unlockRow: function ($row) {
        var actionIndex = this.tableOptions.columnDefs[this.tableOptions.columnDefs.length - 1].targets;
        var td = $row.children("td")[actionIndex];
        $(td).html(this.createActionButtonHtml(false));
    },
    options: {

    },
    onRowDelete: function (row) {
        //Overwrite
        return true;
    },
    onCellCreate: function (cell, data, index) {
        //Overwrite in subclass like => cell.html('<input type="text" id=t' + index + ' class="form-control input-block" value="' + data[index] + '"/>');
    },
    getDefaultData: function () {
        return [];
    },
    getControlValue: function (cell) {
        return '';
    },
    onRowEditable: function () {
    },
    beforeSave: function () {
        return true;
    },
    createDropdown: function (name, data, txtCol, valCol, bindData, text_binding_column, value_binding_column) {

        var selectedValue = bindData[value_binding_column];
        var dropDownHtml = "<select class=\"form-control input-block\" name='" + name + "' id='" + name + "' text-binding-column='" + text_binding_column + "' value-binding-column='" + value_binding_column +"' >\r\n";
        dropDownHtml += "<option value=''>[Select]</option>\r\n";
        for (var index = 0; index < data.length; index++) {
            var selected = "";
            var text = '';
            var value = '';
            if (typeof (data[index]) == 'string') {
                text = data[index];
                value = text;
            }
            else {
                value = data[index][valCol];
                text = data[index][txtCol];
            }
            if (typeof (selectedValue) != undefined && selectedValue != null && selectedValue == value) {
                selected = "selected='selected'";
            }
            dropDownHtml += "<option value='" + value + "' " + selected + ">" + text + "</option>\r\n";
        }
        dropDownHtml += "</select>";
        return dropDownHtml;
    },
    createTextArea: function (name, value) {
        var textAreaHtml = "<textarea rows='4' class='form-control input-block' name='" + name + "' id='" + name + "'>" + value + "</textarea>";
        return textAreaHtml;
    },
    createTextBox: function (data, columnName) {
        var value = data[columnName];
        var textBoxHtml = "<input type='text' class='form-control input-block'  name='" + columnName + "' id='" + columnName + "' value='" + value + "'/>";
        return textBoxHtml;
    },
    createCheckBox: function (name, value) {
        var checked = value ? "checked='checked'" : "";
        return "<div><input type='checkbox' name='" + name + "' id='" + name + "' " + checked + "' class='custom-control'/></div>";
    },
    createControlFromColumn: function (column, data) {
        switch (column.control.type) {
            case "text": {
                return this.createTextBox(column.control.name, data[column.data]);
            }
            case "select": {
                return this.createDropdown(column.control.name, data[column.data]);
            }
        }
    },
    getControlValueFromCell: function (cell) {
        var element = null;
        var data = {};

        if (cell.find('input').length == 1) {
            element = cell.find('input')[0];
            var name = $(element).attr('name');
            data[name] = null;
            if ($(element).is(':text')) {
                data[name] = $(element).val();
                return data;
            }
            if ($(element).is(':checkbox')) {
                data[name] = $(element).is(':checked');
                return data;
            }
        }

        if (cell.find('select').length == 1) {
            element = cell.find('select')[0];
            data[$(element).attr('text-binding-column')] = $(element).find("option:selected").text();
            data[$(element).attr('value-binding-column')] = $(element).val();
            return data;
        }

        if (cell.find('textarea').length == 1) {
            element = cell.find('textarea')[0];
            return $(element).val();
        }

        return cell.html();
    }
};


