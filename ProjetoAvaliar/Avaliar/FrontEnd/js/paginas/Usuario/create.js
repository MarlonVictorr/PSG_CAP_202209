function cadastrar(){
    var codigoUsuario = 0;
    var nome = $("#txtNome").val();
    var sobrenome = $("#txtSobrenome").val();
    var email = $("#txtEmail").val();
    var codigoTipoUsuario = $("#txtCodigoTipoUsuario").val();
    var ativo = null;
    var dataInclusao = null;

    var novo = {
        codigoUsuario,
        nome,
        sobrenome,
        email,
        codigoTipoUsuario,
        ativo,
        dataInclusao
    };

    $.ajax({
        url: caminho,
        type: "post",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(novo),
        success: function(data, status, xhr){
            console.log(data);
            codigoUsuario = data.codigoUsuario;
            alert("Dados gravados com sucesso. [CodigoUsuario = " + codigoUsuario + "]");
            window.location.href = "list.html";
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao gravar os dados. " + status);
            return;
        }
    });
}

