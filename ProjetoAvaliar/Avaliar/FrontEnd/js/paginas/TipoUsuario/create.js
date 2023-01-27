function cadastrar(){
    var codigoTipoUsuario = 0;
    var descricao = $("#txtDescricao").val();
    var ativo = null; 
    var dataInclusao = null;

    var novo = {
        codigoTipoUsuario,
        descricao,
        ativo,
        dataInclusao
    };

    $.ajax({
        url: caminho,
        type: "post",
        dataType: "json",
        data: JSON.stringify(novo),
        contentType: "application/json",
        success: function(data, status, xhr){
            console.log(data);
            codigoTipoUsuario = data.codigoTipoUsuario;
            alert("Dados gravados com sucesso. [codigoTipoUsuario = " + codigoTipoUsuario + "]");
            window.location.href = "list.html";
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao gravar os dados. " + status);
            return;
        }
    });

}