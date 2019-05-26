function convertDateToLocal(date) {
    if (date === null) {
        return null;
    }
    var convertdUTCTime = new Date(date);
    var minutesOffSet = convertdUTCTime.getTimezoneOffset();
    convertdUTCTime.setMinutes(convertdUTCTime.getMinutes() - minutesOffSet);
    return convertdUTCTime;
}
function populateDropdownFromJsonArray(dropdown, data, valColumn, textColumn,selectText) {

    if (typeof (selectText) == "undefined") {
        selectText = "[Select]";
    }
    $(dropdown).children().remove();

    if (selectText.length > 0) {
        $(dropdown).append(new Option(selectText, ""));
    }

    $.each(data, function (index, dataItem) {
        var txt = "", val = "";
        if (valColumn != undefined && valColumn != null && valColumn != "") {
            val = dataItem[valColumn];
        }
        if (textColumn != undefined && textColumn != null && textColumn != "") {
            txt = dataItem[textColumn];
        }
        $(dropdown).append(new Option(txt, val));
    });
};
function doAjax(options, blockObject) {
    var blockRequred = false;

    if (blockObject != undefined && blockObject != null && blockObject !== "") {
        blockRequred = true;
    }

    if (blockRequred && typeof (blockObject) == "string") {
        blockObject = $("#" + blockObject);
    }

    var loadOptions = {
        contentType: options.contentType == undefined ? "application/json; charset=utf-8" : options.contentType,
        beforeSend: function () {
            if (blockRequred) {
                blockDiv(blockObject);
            }
        },
        complete: function () {
            if (blockRequred) {
                unblockDiv(blockObject);
            }
        }
    };
    var extendedOptions = $.extend({}, options, loadOptions);
    $.ajax(extendedOptions);
}
function blockDiv(n) {
    n.block({
        message: '<img src="/images/loadingCirc.gif"  alt=""  style="margin:0" />',
        css: {
            width: "25px",
            height: "25px",
            position: "absolute",
            left: "40%",
            top: "45%",
            margin: "0"
        }
    });
}
function unblockDiv(n) {
    n.unblock();
}

