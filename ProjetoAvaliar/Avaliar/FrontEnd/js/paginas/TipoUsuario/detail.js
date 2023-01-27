var codigo = 0;

$(function(){
    avaliarAcao('tipoUsuarioAcao');
    if (acao == 0){
        carregarDetalhe();
        somenteLeitura();    
        $("#btnNovo").hide();
        $("#btnAlterar").hide();
        $("#btnExcluir").hide();
        $("#Data").hide();
        $("#Texto").hide();
        $("#chbAtivo").attr('disabled', true);
    }
    
    if (acao == 1){
        $("#txtCodigoTipoUsuario").attr('readonly',true);
        $("#txtAtivo").attr('readonly',true);
        $("#txtDataInclusao").attr('readonly', true); 
        $("#btnAlterar").hide();
        $("#btnExcluir").hide();
        $("#Texto").hide();
        $("#divAtivoInclusao").hide();
        $("#chbAtivo").attr('checked', true);
        $("#chbAtivo").attr('disabled', true);
    }
    
    if (acao == 2){
        carregarDetalhe();
        $("#txtCodigoTipoUsuario").attr('readonly',true);
        $("#txtDataInclusao").attr('readonly', true);  
        $("#btnNovo").hide();
        $("#btnExcluir").hide();
        $("#Texto").hide();
        $("#divAtivoInclusao").hide();
        $("#DatDataContratacao").attr('readonly', true);  
    }

    if (acao == 3){
        carregarDetalhe();
        somenteLeitura();
        $("#btnNovo").hide();
        $("#btnAlterar").hide();
        $("#Data").hide();
        $("#divAtivoInclusao").hide();
        $("#chbAtivo").attr('disabled', true);
    }
});

function somenteLeitura(){
    $("#txtCodigoTipoUsuario").attr('readonly',true);
    $("#txtDescricao").attr('readonly',true);
    $("#chbAtivo").attr('readonly',true);
    $("#txtDataInclusao").attr('readonly',true);
}

function carregarDetalhe(){
    var tmp = localStorage.getItem("codigoTipoUsuarioSelecionado");
    codigo = JSON.parse(tmp)

    if ((codigo == undefined) || (codigo == 0)){
        alert("código inválido!!");
        window.location.href = "list.html";
    }
    else{
        localStorage.removeItem("codigoTipoUsuarioSelecionado");
    }
    
    var caminhoComValor = caminho + '/' + codigo;

    $.get(caminhoComValor, function(data, status){
        if (data.length == 0){
            alert("Erro ao obter os dados.")
            return;
        }
        else{
            console.log(data);
            $("#txtCodigoTipoUsuario").val(data.codigoTipoUsuario);
            $("#txtDescricao").val(data.descricao);
            $("#chbAtivo").prop('checked', data.ativo);
            $("#txtAtivo").val(data.ativo);
            $("#txtDataInclusao").val(data.dataInclusao.substring(0,10));   
        }
    });
}

function stringToBoolean(value){
    return (String(value) === '1' || String(value).toLowerCase() === 'true');
}