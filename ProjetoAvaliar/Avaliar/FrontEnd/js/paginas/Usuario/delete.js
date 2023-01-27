function excluir(){
    var codigoUsuario = $("#txtCodigoUsuario").val();
    var caminhoComValor = caminho + '/' + codigo;

    $.ajax({
        url: caminhoComValor,
        type: "delete",
        dataType: "json",
        contentType: "application/json",
        data: null,
        success: function(data, status, xhr){
            console.log(data);
            codigoUsuario = data.codigoUsuario;
            alert("Dados excluídos com sucesso. [CodigoUsuario = " + codigoUsuario + "]");
            window.location.href = "list.html"
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao excluir os dados. " + status);
            return;
        }
    });
}