$(document).ready(function () {
    $('#tblState').DataTable();
});
$('#btnAddStates').click(function () {
    if ($('#btnAddStates').val() == 'Add States') {
        if ($('#ddlCountry').val() == '0') {
            $('#spnCountry').text('Select country name');
            return false;
        } else {
            $('#spnCountry').text('');
        }
        if ($('#txtState').val().trim() == '') {
            $('#spnState').text('Enter state name');
            return false;
        } else {
            $('#spnState').text('');
        }
    } else if ($('#btnAddStates').val() == 'Add States') {
    }
});