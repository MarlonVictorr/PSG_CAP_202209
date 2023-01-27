function excluir(){
    var codigoTipoUsuario = $("#txtCodigoTipoUsuario").val();   
    var caminhoComValor = caminho + '/' + codigo;

    $.ajax({
        url: caminhoComValor,
        type: "delete",
        dataType: "json",
        data: null,
        contentType: "application/json",
        success: function(data, status, xhr){
            console.log(data);
            codigoTipoUsuario = data.codigoTipoUsuario;
            alert("Dados excluídos com sucesso. [CodigoTipoUsuario = " + codigoTipoUsuario + "]");
            window.location.href = "list.html";
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao excluir os dados. " + status);
            return;
        }
    });
}