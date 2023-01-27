var codigo = 0;

$(function(){
    avaliarAcao('usuarioAcao');
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
        $("#txtCodigoUsuario").attr('readonly',true);
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
        $("#txtCodigoUsuario").attr('readonly',true);
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
    $("#txtCodigoUsuario").attr('readonly',true);
    $("#txtNome").attr('readonly',true);
    $("#txtSobrenome").attr('readonly',true);
    $("#txtEmail").attr('readonly',true);
    $("#txtCodigoTipoUsuario").attr('readonly',true);
    $("#txtAtivo").attr('readonly',true);
    $("#txtDataInclusao").attr('readonly', true);
}

function carregarDetalhe(){
    var tmp = localStorage.getItem("codigoUsuarioSelecionado");
    codigo = JSON.parse(tmp)

    if ((codigo == undefined) || (codigo == 0)){
        alert("código inválido!!");
        window.location.href = "list.html";
    }
    else{
        localStorage.removeItem("codigoUsuarioSelecionado");
    }
    
    var caminhoComValor = caminho + '/' + codigo;

    $.get(caminhoComValor, function(data, status){
        if (data.length == 0){
            alert("Erro ao obter os dados.")
            return;
        }
        else{
            console.log(data);
            $("#txtCodigoUsuario").val(data.codigoUsuario);
            $("#txtNome").val(data.nome)
            $("#txtSobrenome").val(data.sobrenome);
            $("#txtEmail").val(data.email);
            $("#txtCodigoTipoUsuario").val(data.codigoTipoUsuario);
            $("#txtAtivo").val(data.ativo);
            $("#txtDataInclusao").val(data.dataInclusao.substring(0,10));
            $("#chbAtivo").prop('checked', data.ativo);
        }
    });
}

function stringToBoolean(value){
    return (String(value) === '1' || String(value).toLowerCase() === 'true');
}