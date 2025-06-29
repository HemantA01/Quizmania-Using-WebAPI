$(document).ready(function () {
    $('#tblCountry').dataTable();
});
$('#btnAddCountry').click(function () {
    //alert('1');
    if ($('#txtCountry').val().trim() == '') {
        $('#spnCountry').text('Enter the country name');
        return false;
    }
    if ($('#txtCountryAbb').val().trim() == '') {
        $('#spnCountryAbb').text('Enter the country Abbreviation');
        return false;
    }
    var model = new FormData();
    model.append('CountryName', $('#txtCountry').val());
    model.append('CountryAbb', $('#txtCountryAbb').val());
    if ($('#btnAddCountry').val() == 'Add Country') {
        $.ajax({
            method: 'POST',
            url: '/Master/InsertCountry',
            data: model,
            processData: false,
            contentType: false,
            async: false,
            success: function (response) {
                debugger;
                //alert('Inserted successfully. Response is : ' + response);
                setTimeout(function () {
                    window.location = '/Master/GetAllCountries';
                }, 2000);
            },
            error: function (err) {
                debugger;
                console.log(err);
                alert('error occured');
            }
        })
    } else if ($('#btnAddCountry').val() == 'Update Country') {
        model.append('Id', $('#hdnCountry').val());
        $.ajax({
            method: 'PUT',
            url: '/Master/UpdateCountry?Id=',
            data: model,
            processData: false,
            contentType: false,
            async: false,
            success: function (response) {
                debugger;
                //alert('Inserted successfully. Response is : ' + response);
                if (response == 0) {
                    alert('None of the columns have been updated.');
                    clearFields();
                } else if(response>0) {
                    clearFields();
                    setTimeout(function () {
                        window.location = '/Master/GetAllCountries';
                    }, 2000);
                }
                
            },
            error: function (err) {
                debugger;
                console.log(err);
                alert('error occured');
            }
        })
    }
});
function clearFields() {
    $('#hdnCountry').val('');
    $('#txtCountry').val('');
    $('#txtCountryAbb').val('');
    $('#btnAddCountry').val('Add Country');
}
$('.aDelete').click(function () {
    debugger;
    var ret = confirm('Are you sure to update the country status?')
    if (ret == true) {
        debugger;
        var countryId = $(this).closest('tr').find('#hdnCountryId').val();
        var status = $(this).closest('tr').find('td:eq(3)').text();
        var updatedstatus = status == false ? true : false;
        //$('#hdnCountry').val(countryId);
        model = new FormData();
        model.append('Id', countryId);
        model.append('IsActive', updatedstatus);
        $.ajax({
            method: 'PATCH',
            url: '/Master/UpdateCountryStatus?Id=',
            data: model,
            processData: false,
            contentType: false,
            async: false,
            success: function (response) {
                if (response >= 0) {
                    clearFields();
                    setTimeout(function () {
                        window.location = '/Master/GetAllCountries';
                    }, 2000);
                } else {
                    alert('error occured. Please try again after some times.')
                    return false;
                }
            },
            error: function (response) {
                alert('error occured');
                return false;
            }
        });
    }
});

$('.aEdit').click(function () {
    //debugger;
    //alert('sgdgds');
    var countryId = $(this).closest('tr').find('#hdnCountryId').val();
    var country = $(this).closest('tr').find('td:eq(1)').text();
    var countryAbb = $(this).closest('tr').find('td:eq(2)').text();
    var status = $(this).closest('tr').find('td:eq(3)').text();
    $('#txtCountry').val(country);
    $('#txtCountryAbb').val(countryAbb);
    $('#hdnCountry').val(countryId);
    $('#btnAddCountry').val('Update Country');
})
$('.aRemove').click(function () {
    var isTrue = confirm('Do you want to remove the details permanently?');
    if (isTrue == true) {
        debugger;
        var countryId = $(this).closest('tr').find('#hdnCountryId').val();
        $.ajax({
            method: 'DELETE',
            url: '/Master/DeleteCountry?Id=' + parseInt(countryId),
            data: '',
            processData: false,
            contentType: false,
            async: false,
            success: function (response) {
                if (response == true) {
                    clearFields();
                    setTimeout(function () {
                        window.location = '/Master/GetAllCountries';
                    }, 2000);
                } else {
                    alert('error occured. Please try again after some times.')
                    return false;
                }
            },
            error: function (response) {
                alert('error occured.');
                return false;
            }
        });
    }
});