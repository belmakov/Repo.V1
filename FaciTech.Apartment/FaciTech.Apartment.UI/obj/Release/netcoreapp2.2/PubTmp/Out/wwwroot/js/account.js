function authenticate() {

    if (!validateForm()) {
        return false;
    }
  
    var userName = $('#userid').val();
    var password = $('#password').val();
    var dataToPost = { "username": userName, "password": password };
    $.ajax({
        method: "POST",
        url: "/Account/Authenticate",
        data: JSON.stringify(dataToPost),
        contentType:"application/json",
        dataType:"json",
        success: function (data) {
            if (data.status == "Error") {
                displayErrorMessage(data.message);
            }
            else {
                window.location.replace("/Admin");
            }
        },
        error: function (err) {
            showError(err);
        }
   });
}
function validateForm() {
    var form = $('form')[0];
    if (form.checkValidity() === false) {
        event.preventDefault();
        event.stopPropagation();
        form.classList.add('was-validated');
        return false;
    }
    return true;
}
function displayErrorMessage(message) {

    showError(message);
    $('form').on('keypress', function () {
        hideError();
    });
}
function showError(errorMessage) {
    $('.alert').html(errorMessage);
    $('#errorPanel').show();
}
function hideError() {
    $('.alert').html("");
    $('#errorPanel').hide();
    var form = $('form')[0];
    form.classList.remove('was-validated');
}