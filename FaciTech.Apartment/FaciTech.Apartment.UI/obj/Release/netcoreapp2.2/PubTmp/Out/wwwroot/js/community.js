
$(document).ready(function () {

    var block = new apartmentBlock();
    var unit = new apartmentUnit();
    var resident = new apartmentResident();
    var association = new apartmentAssociation();

    populateDropdown('country', '/Country/All', 'id', 'name');

    $('#w4').bootstrapWizard({
        tabClass: 'wizard-steps',
        nextSelector: 'ul.pager li.next',
        previousSelector: 'ul.pager li.previous',
        firstSelector: null,
        lastSelector: null,
        onNext: function (tab, navigation, index, newindex) {
            //var validated = $('#versionForm').valid();
            //if (!validated) {
            //    $w4validator.focusInvalid();
            //    return false;
            //}

        },
        onTabClick: function (tab, navigation, index, newindex) {

            if (newindex == 3) {
                block.doAjaxToGetApartmentBlocks();
            }
            if (newindex == 4)
                unit.doAjaxToGetApartmentUnits();
            if (newindex == 5)
                resident.doAjaxToGetApartment();
            if (newindex == 6)
                association.doAjaxToGetApartmentAssociation();

            if ($('#community_id').val() != "") {
                return this.onNext(tab, navigation, index, newindex);
            } else {
                return true;
            }
        },
        onTabChange: function (tab, navigation, index, newindex) {


            //validateStep(index, newindex);
            var $total = navigation.find('li').length - 1;
            //$w4finish[newindex != $total ? 'addClass' : 'removeClass']('hidden');
            //$('#w4').find(this.nextSelector)[newindex == $total ? 'addClass' : 'removeClass']('hidden');
        },
        onTabShow: function (tab, navigation, index) {
            var $total = navigation.find('li').length - 1;
            var $current = index;
            var $percent = Math.floor(($current / $total) * 100);
            $('#w4').find('.progress-indicator').css({ 'width': $percent + '%' });
            tab.prevAll().addClass('completed');
            tab.next().addClass('active');
            //tab.nextAll().removeClass('completed');
        }
    });

});

$('#save_basic_info').click(function () {
    SaveBasicInfo();
});
$('#save_association_info').click(function () {
    SaveAssociationInfo();
});
$('#save_amenities').click(function () {
    SaveAmenities();
});
$('#country').change(function () {
    var id = $('#country').val();
    populateDropdown('city', '/Admin/City?countryId=' + id, 'id', 'name');
    $('#area').empty();
    $('#sub_area').empty();
});
$('#city').change(function () {
    var id = $('#city').val();
    populateDropdown('area', '/Admin/Area?cityId=' + id, 'id', 'name');
    $('#sub_area').empty();
});
$('#area').change(function () {
    var id = $('#area').val();
    populateDropdown('sub_area', '/Admin/SubArea?areaId=' + id, 'id', 'name');

});


function populateDropdown(id, url, valcol, textcol) {
    $('#' + id).empty();
    var v = $('#' + id).attr('data-id');
    $('<option/>').val("").html("[Select]").appendTo('#' + id);
    $.get({
        url: url,
        success: function (countries) {
            for (var index = 0; index < countries.length; index++) {
                if (v != "" && v == countries[index][valcol]) {
                    $('<option selected="selected"/>').val(countries[index][valcol]).html(countries[index][textcol]).appendTo('#' + id);
                }
                else {
                    $('<option/>').val(countries[index][valcol]).html(countries[index][textcol]).appendTo('#' + id);
                }
            }
            if (v != "") {
                $('#' + id).trigger("change");
            }
        }
    });
}
function SaveBasicInfo() {
    var dataToPost = {
        "source": "basic",
        "community_id": $("#community_id").val(),
        "community_name": $("#community_name").val(),
        "builder_name": $("#builder_name").val(),
        "sub_area": $("#sub_area").val(),
        "address": $("#address").val(),
        "landmark": $("#landmark").val(),
        "location_link": $("#location_link").val()
    };
    $.ajax(
        {
            url: '/Admin/Community/Save',
            type: 'POST',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(dataToPost),
            success: function (res) {
                if (res.status == "Success") {
                    $("#community_id").val(res.data.community_id);
                }
            }
        });
}
function SaveAssociationInfo() {
    var dataToPost = {
        "community_id": $("#community_id").val(),
        "source": "association",
        "association_name": $("#association_name").val(),
        "association_number": $("#association_number").val(),
        "bank_name": $("#bank_name").val(),
        "account_number": $("#account_number").val(),
        "branch_address": $("#branch_address").val(),
        "ifsc": $("#ifsc").val()
    };
    $.ajax(
        {
            url: '/Admin/Community/Save',
            type: 'POST',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(dataToPost),
            success: function (data) {
            }
        });
}
function SaveAmenities() {
    var checkedAmenities = $('#amenityForm input:checked');
    var amenityIds = "";
    $('#amenityForm input:checked').each(function () {
        if (amenityIds.length > 0) {
            amenityIds += ",";
        }
        amenityIds += $(this).attr("data-id");
    });
    var dataToPost = {
        "community_id": $("#community_id").val(),
        "amenity_ids": amenityIds,
        "source": "amenity"
    };
    $.ajax(
        {
            url: '/Admin/Community/Save',
            type: 'POST',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(dataToPost),
            success: function (data) {
            }
        });
}