

function visualizarLista(){
    $("#tabelaUsuario").toggle();
    let texto = $("#btnVisualizarLista").text() == 'Visualizar Lista' ? 'Fechar Lista' : 'Visualizar Lista';
    $("#btnVisualizarLista").text(texto);

}


obterUsuarios();
function obterUsuarios() {

    $.get("https://localhost:7152/Usuario/Listar", function (data) {
        console.log(data);
        $("#tbodyUsuario").html("");
        for (var i = 0; i < data.length; i++) {
            $("#tbodyUsuario").append("<tr>" +
                "<td>" + data[i].name + "</td>" +
                "<td>" + data[i].cpf + "</td>" +
                "<td>" + (data[i].active ? "Ativo" : "Inativo") + "</td>" +
                "<td>" +
                (data[i].active ? " <button onclick=inativar('" + data[i].id + "')> Inativar </button> " : " <button onclick=ativar('" + data[i].id + "')> Ativar </button> ") +
                ("<button onclick=editar('" + data[i].id + "')> Editar </button> </td>") +
                "</tr> ")
        }
    })
        .fail(function (retorno) {
            alert(retorno.responseJSON.data.errors);
        })
}

function inativar(id) {
    $.ajax({
        type: "PUT",
        url: "https://localhost:7152/Usuario/Inativar?id=" + id,
        contentType: 'application/json'
    }).done(function (retorno) {
        obterUsuarios();
        alert("Usuario atualizado com sucesso");
    })
        .fail(function (retorno) {
            alert(retorno.responseJSON.data.errors);
        })
}
function ativar(id) {
    $.ajax({
        type: "PUT",
        url: "https://localhost:7152/Usuario/Ativar?id=" + id,
        contentType: 'application/json'
    }).done(function (retorno) {
        obterUsuarios();
        alert("Usuario ativado com sucesso");
    })
        .fail(function (retorno) {
            alert(retorno.responseJSON.data.errors);
        })
}

function salvar() {
    let id = $("#id").val();

    var objeto = {
        id: id != "" ? id : 0,
        name: $("#name").val(),
        birthday: $("#birthday").val(),
        email: $("#email").val(),
        cpf: $("#cpf").val(),
        phone: $("#phone").val(),
        password: $("#password").val(),
        active: true
    }

    if (id != "") {
        atualizar(objeto);
    }
    else {
        adicionar(objeto);
    }
}

function adicionar(objeto) {

    $.ajax({
        type: "POST",
        url: "https://localhost:7152/Usuario/Adicionar",
        data: JSON.stringify(objeto),
        contentType: 'application/json'
    }).done(function (retorno) {
        obterUsuarios();
        limpar();
        alert("Dados salvos com Sucesso");
    })
        .fail(function (retorno) {
            alert(retorno.responseJSON.data.errors);
        })
}

function atualizar(objeto) {

    $.ajax({
        type: "PUT",
        url: "https://localhost:7152/Usuario/Atualizar",
        data: JSON.stringify(objeto),
        contentType: 'application/json'
    }).done(function (retorno) {
        obterUsuarios();
        limpar();
        alert("Dados salvos com Sucesso");
    })
        .fail(function (retorno) {
            alert(retorno.responseJSON.data.errors);
        })
}

function editar(id) {
    $.get("https://localhost:7152/Usuario/ListarPorId?id=" + id, function (data) {
        console.log(data);
        $("#name").val(data.name);
        $("#birthday").val(data.birthday.substring(0, 10));
        $("#email").val(data.email);
        $("#cpf").val(data.cpf);
        $("#phone").val(data.phone);
        $("#password").val(data.password);
        $("#active").val(data.active);
        $("#id").val(data.id);
    })
        .fail(function (retorno) {
            alert(retorno.responseJSON.data.errors);
        })
}

function limpar() {
    $("#name").val("");
    $("#birthday").val("");
    $("#email").val("");
    $("#cpf").val("");
    $("#phone").val("");
    $("#password").val("");
    $("#active").val("");
    $("#id").val("");
}