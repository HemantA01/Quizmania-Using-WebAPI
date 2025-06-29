$(document).ready(function () {
  
});
$('#btnLogin').click(function () {
   // 
    var model = new FormData();
    model.append('Username', $('#txtUserName').val().trim());
    model.append('Password', $('#txtPassword').val().trim());
    $.ajax({
        method: 'POST',
        url: '/Login/Index',
        //contentType: 'application/json; charset=utf-8',
        data: model,
        processData: false,
        contentType: false,
        async: false,
        success: function (response) {
            debugger;
            $('#credResult').html('User has logged in successfully.');
            setTimeout(function () {
                window.location = '/Home/Dashboard';
            }, 5000);
            
        },
        error: function (err) {
            debugger;
            console.log(err);
            alert('error occured');
        }
    });
});