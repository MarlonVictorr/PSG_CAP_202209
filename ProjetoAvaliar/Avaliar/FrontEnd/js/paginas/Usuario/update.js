function alterar(){
    var codigoUsuario = $("#txtCodigoUsuario").val();
    var nome = $("#txtNome").val();
    var sobrenome = $("#txtSobrenome").val();
    var email = $("#txtEmail").val();
    var codigoTipoUsuario = $("#txtCodigoTipoUsuario").val();
    var dataInclusao = $("#txtDataInclusao").val();
    var ativo = $("#chbAtivo").prop('checked');
    
    var novo = {
        codigoUsuario,
        nome,
        sobrenome,
        email,
        codigoTipoUsuario,
        dataInclusao,
        ativo
    };

    $.ajax({
        url: caminho,
        type: "put",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(novo),
        success: function(data, status, xhr){
            console.log(data);
            codigoUsuario = data.codigoUsuario;
            alert("Dados alterados com sucesso. [CodigoUsuario = " + codigoUsuario + "]");
            window.location.href = "list.html"
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao altera os dados. " + status);
            return;
        }
    });
}

