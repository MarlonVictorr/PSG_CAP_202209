function alterar(){
    var codigoTipoUsuario = $("#txtCodigoTipoUsuario").val();
    var descricao = $("#txtDescricao").val();
    var ativo = $("#chbAtivo").prop('checked');

    var novo = {
        codigoTipoUsuario,
        descricao,
        ativo
    };

    $.ajax({
        url: caminho,
        type: "put",
        dataType: "json",
        data: JSON.stringify(novo),
        contentType: "application/json",
        success: function(data, status, xhr){
            console.log(data);
            codigoTipoUsuario = data.codigoTipoUsuario;
            alert("Dados alterados com sucesso. [codigoTipoUsuario = " + codigoTipoUsuario + "]");
            window.location.href = "list.html";
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao alterar os dados. " + status);
            return;
        }
    });

}