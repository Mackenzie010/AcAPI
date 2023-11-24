function logar() {
    $('#loading').show();
    let email = $("#email").val();
    let senha = $("#senha").val();

    $.post("https://localhost:7152/Login/Login?email=" + email + "&Password=" + senha, function (data) {
        $('#loading').hide();
        sessionStorage.setItem("Logado", "true");
        sessionStorage.setItem("Usuario", data.id);
        window.location.href = "/Index";
    })
        .fail(function (retorno) {
            alert(retorno.responseJSON.data.errors);
        })
}