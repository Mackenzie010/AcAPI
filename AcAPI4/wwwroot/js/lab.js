obterLab();
function obterLab() {
    $('#loading').show();

    $.get("https://localhost:7152/Lab/Listar", function (data) {
        $('#loading').hide();
        console.log(data);
        $("#tbodyLab").html("");
        for (var i = 0; i < data.length; i++) {
            $("#tbodyLab").append("<tr>" +
                "<td>" + data[i].lab + "</td>" +
                "<td>" + data[i].andar + "</td>" +
                "<td>" + (data[i].ativo ? "Ativo" : "Inativo") + "</td>" +
                (data[i].ativo ? "<td> <button onclick=inativar('" + data[i].id + "')> Inativar </button>" : "<td> <button onclick=ativar('" + data[i].id + "')> Ativar </button>") +
                ("<button onclick=editar('" + data[i].id + "')> Editar </button>") +
                (" <button onclick=horarios('" + data[i].id + "')> Agendamento </button> </td>") +
                "</tr> ")
        }
    })
        .fail(function (retorno) {
            alert(retorno.responseJSON.data.errors);
        })
}

function horarios(idLab) {
    $('#loading').show();
    $("#idLabAgendamento").val(idLab);
    $("#divHorarios").css("display", "block");
    $.get("https://localhost:7152/Lab/ListarAgendamentosPorLab?idLab=" + idLab, function (data) {
        $('#loading').hide();
        console.log(data);
        $("#tbodyHorarios").html("");
        if (data.length == 0) {
            $("#tbodyHorarios").html("Nenhuma data agendada");
        }
        for (var i = 0; i < data.length; i++) {
            let dataAgendamento = data[i].data.substring(0, 10).split("-");
            $("#tbodyHorarios").append("<tr>" +
                "<td>" + dataAgendamento[2] + "/" + dataAgendamento[1] + "/" + dataAgendamento[0] + "</td>" +
                "<td>" + data[i].nmUsuario + "</td>" +
                "</tr> ")
        }
    })
}

function salvarHorario() {

    var objeto = {
        idUsuario: sessionStorage.getItem("Usuario"),
        data: $("#dataLab").val(),
        idLab: $("#idLabAgendamento").val(),
        nmUsuario: "",
        nmLab: ""
    }

    let dataAgendamento = $("#dataLab").val().split("-");
    let dataFormatada = dataAgendamento[2] + "/" + dataAgendamento[1] + "/" + dataAgendamento[0];
    if ($("#tbodyHorarios").html().includes(dataFormatada)) {
        alert("Data ja Agendada");
        return;
    }
    $('#loading').show();
    $.ajax({
        type: "POST",
        url: "https://localhost:7152/Lab/IncluirAgendamento",
        data: JSON.stringify(objeto),
        contentType: 'application/json'
    }).done(function (retorno) {
        $('#loading').hide();
        horarios(objeto.idLab);
        alert("Data agendada com Sucesso");
    })
}

function inativar(id) {
    $('#loading').show();
    $.ajax({
        type: "PUT",
        url: "https://localhost:7152/Lab/Inativar?id=" + id,
        contentType: 'application/json'
    }).done(function (retorno) {
        obterLab();
        $('#loading').hide();
    })
        .fail(function (retorno) {
            alert(retorno.responseJSON.data.errors);
        })
}
function ativar(id) {
    $('#loading').show();
    $.ajax({
        type: "PUT",
        url: "https://localhost:7152/Lab/Ativar?id=" + id,
        contentType: 'application/json'
    }).done(function (retorno) {
        $('#loading').hide();
        obterLab();

    })
        .fail(function (retorno) {
            alert(retorno.responseJSON.data.errors);
        })
}

function salvar() {
    let id = $("#id").val();

    var objeto = {
        id: id != "" ? id : 0,
        lab: $("#lab").val(),
        descricao: $("#descricao").val(),
        dt_Cadastro: $("#dt_Cadastro").val(),
        andar: $("#andar").val(),
        ativo: true
    }

    if (id != "") {
        atualizar(objeto);
    }
    else {
        adicionar(objeto);
    }
}

function adicionar(objeto) {
    if ($("#tbodyLab").html().includes(objeto.lab)) {
        alert("Lab já cadastrado");
        return;
    }
    $('#loading').show();
    $.ajax({
        type: "POST",
        url: "https://localhost:7152/Lab/Adicionar",
        data: JSON.stringify(objeto),
        contentType: 'application/json'
    }).done(function (retorno) {
        obterLab();
        limpar();
        $('#loading').hide();
    })
        .fail(function (retorno) {
            alert(retorno.responseJSON.data.errors);
        })
}

function atualizar(objeto) {
    $('#loading').show();
    $.ajax({
        type: "PUT",
        url: "https://localhost:7152/Lab/Atualizar",
        data: JSON.stringify(objeto),
        contentType: 'application/json'
    }).done(function (retorno) {
        $('#loading').hide();
        obterLab();
        limpar();
    })
        .fail(function (retorno) {
            alert(retorno.responseJSON.data.errors);
        })
}

function editar(id) {
    $('#loading').show();
    $.get("https://localhost:7152/Lab/ListarPorId?id=" + id, function (data) {
        console.log(data);
        $("#lab").val(data.lab);
        $("#dt_Cadastro").val(data.dt_Cadastro.substring(0, 10));
        $("#descricao").val(data.descricao);
        $("#ativo").val(data.ativo);
        $("#andar").val(data.andar);
        $("#id").val(data.id);
        $('#loading').hide();
    })
        .fail(function (retorno) {
            alert(retorno.responseJSON.data.errors);
        })
}

function limpar() {
    $("#lab").val("");
    $("#dt_Cadastro").val("");
    $("#andar").val("");
    $("#ativo").val("");
    $("#id").val("");
}

