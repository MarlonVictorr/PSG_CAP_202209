var caminhoEnvelope = '';
$(function(){
  carregarUsuario();
  $("#ddlDescricao").change(function(){
      var codigoTipoUsuario = $(this).children("option:selected").val();
      var limite = $("#ddlTakeSkip").children("option:selected").val();
      var salto = 0;
      if (limite != 0){
       caminhoEnvelope = caminho + "/envelope/PorTipoUsuario/" + codigoTipoUsuario + "?limite=" + limite + "&salto=" + salto;
       carregar(caminhoEnvelope);
      }
      else{
        limite = 10;
        caminhoEnvelope = caminho + "/envelope/PorTipoUsuario/"+ codigoTipoUsuario + "?limite=" + limite + "&salto=" + salto;
        carregar(caminhoEnvelope);
      }
  });

  $("#ddlTakeSkip").change(function(){
    var limite = $(this).children("option:selected").val();
    var codigoTipoUsuario = $("#ddlDescricao").children("option:selected").val();
    var salto = 0;
    if (codigoTipoUsuario != 0){
      caminhoEnvelope = caminho + "/envelope/PorTipoUsuario/"+ codigoTipoUsuario + "?limite=" + limite + "&salto=" + salto;
        carregar(caminhoEnvelope);
    }
    else{
      alert("Informe uma descrição para a pesquisa.")
    }
  });
});

function carregar(caminhoEnvelope){
    $.ajax({
      url:caminhoEnvelope,
      type: "get",
      dataType: "json",
      contentType: "application/json",
      data: null,
      async: false,
      success: function(data, status, xhr){
        var codigoStatus = data.status.codigo;
        var mensagemStatus = data.status.mensagem;

        if  (codigoStatus == 404){
            $("#liPagina").hide();
            $("#liPosterior").hide();          
            alert(mensagemStatus);
            return;
        }

        $("#tblDados tbody").empty(); 

        for (let index = 0; index < data.dados.length; index++) {
          const usuario = data.dados[index];

          var codigoUsuario = usuario.codigoUsuario;
          var nome = usuario.nome;
          var sobrenome = usuario.sobrenome;
          var email = usuario.email;

          var hasPrev = data.paginacao.hasPrev;
          var hasNext = data.paginacao.hasNext;
          var pageNumber = data.paginacao.pageNumber;   
        
          var linha = '';
          linha += "<tr>";
          linha +=  "<td class='table-active text-center'>";
          linha +=    "<button id='btnExibir' class='border-light border-0' onclick='exibirAtual("+ codigoUsuario +");'>";
          linha +=      "<img src='/img/att.png''width=35 height=35'>";
          linha +=    "</button>";
          linha +=  "</td>";
          linha += "<td class='table-active text-center'>" + codigoUsuario + "</td>";
          linha += "<td class='table-active text-center'>" + nome + "</td>";
          linha += "<td class='table-active text-center'>" + sobrenome + "</td>";
          linha += "<td class='table-active text-center'>" + email + "</td>";
          linha += "<td class='table-active text-center'>";
          linha +=    "<button id='btnAlterar' class='btn-warning' onclick='alterarAtual("+ codigoUsuario +");'>Alterar</button>";
          linha +=    "</td>";
          linha += "<td class='table-active text-center'>";
          linha +=    "<button id='btnExcluir' class='btn-danger' onclick='excluirAtual("+ codigoUsuario +");'>Excluir</button>";
          linha +=    "</td>";
          linha += "</tr>"; 
            $("#tblDados tbody").append(linha);
        }
        carregarLinkPaginacao(pageNumber, hasPrev, hasNext)
      },
      error: function(xhr, status, errorThrown){
        alert("Erro ao obter os dados. " + status);
        return;  
      }
});
}

function exibirAtual(codigo){
  localStorage.setItem("usuarioAcao",JSON.stringify(0));
  localStorage.setItem("codigoUsuarioSelecionado",JSON.stringify(codigo));
  window.location.href = "detail.html";
}

function cadastrarNovo(){
  localStorage.setItem("usuarioAcao",JSON.stringify(1));
  window.location.href = "detail.html";
}


function alterarAtual(codigo){
  localStorage.setItem("usuarioAcao",JSON.stringify(2));
  localStorage.setItem("codigoUsuarioSelecionado",JSON.stringify(codigo));
  window.location.href = "detail.html";
}

function excluirAtual(codigo){
  localStorage.setItem("usuarioAcao",JSON.stringify(3));
  localStorage.setItem("codigoUsuarioSelecionado",JSON.stringify(codigo));
  window.location.href = "detail.html";
}

var pessoas = [];

function carregarUsuario(){
  var caminhoUsuario  = servidor + "/" + "TipoUsuario";
  $.get(caminhoUsuario, function(data){

        for (let index = 0; index < data.length; index++) {
          const usuario = data[index];
          $("#ddlDescricao").append(
            $('<option></option>').val(usuario.codigoTipoUsuario).html(usuario.descricao)
        );
        }     
  });
}

function carregarLinkPaginacao(numeroPagina, anterior, posterior){
  $("#navPaginacao ul").empty();

    var linha = '';
    linha += "<li class='page-item'>";
    linha +=  "<a class='page-link' id='liAnterior' onclick='carregar(\""+ anterior +"\")' tabindex='-1'>Anterior</a>";
    linha += "</li>";
    linha += "<li class='page-item'>";
    linha +=  "<a class='page-link' id='liPagina'> "+ numeroPagina +"</a>";
    linha += "</li>";
    linha += "<li class='page-item'>";
    linha +=  "<a class='page-link' id='liPosterior' onclick='carregar(\""+ posterior +"\")'>Próximo</a>";
    linha += "</li>";
    $("#navPaginacao ul").html(linha);

    if(numeroPagina == 1){
      $("#liAnterior").hide();
    }
}
