$(function(){
  carregar();
});

function carregar(){
  $.get(caminho, function(data, status){
      if (data == 0){
        alert("Erro ao obter os dados.")
        return;
      }
      else{
        for (let index = 0; index < data.length; index++) {
          const tipoUsuario = data[index];
          
          console.log(tipoUsuario);

          var codigoTipoUsuario = tipoUsuario.codigoTipoUsuario;
          var descricao = tipoUsuario.descricao;
          var ativo = tipoUsuario.ativo;

          var linha = '';
          linha += "<tr>";
          linha += "  <td class='table-active text-center'>";
          linha += "    <button id='btnExibir' class='border-light border-0' onclick='exibirAtual("+ codigoTipoUsuario +");'> ";
          linha += "      <img src='/img/att.png''width=35 height=35'>";
          linha += "    </button>";
          linha += "  </td>";
          linha += "  <td class='table-active text-center'>" + codigoTipoUsuario + "</td>";
          linha += "  <td class='table-active text-center'>" + descricao + "</td>";
          linha += "  <td class='table-active text-center'>" + ativo + "</td>";
          linha += "  <td class='table-active text-center'>";
          linha += "    <button id='btnAlterar' class='btn-warning' onclick='alterarAtual("+ codigoTipoUsuario +");'>Alterar</button>";
          linha += "  </td>";
          linha += "  <td class='table-active text-center'>";
          linha += "    <button id='btnExcluir' class='btn-danger' onclick='excluirAtual("+ codigoTipoUsuario +");'>Excluir</button>";
          linha += "  </td>";
          linha += "</tr>";
          $("#tblDados tbody").append(linha);
        }
      }

  });
}

function exibirAtual(codigo){
localStorage.setItem("tipoUsuarioAcao", JSON.stringify(0));
localStorage.setItem("codigoTipoUsuarioSelecionado",JSON.stringify(codigo));
window.location.href = "detail.html";
}

function cadastrarNovo(){
localStorage.setItem("tipoUsuarioAcao", JSON.stringify(1));
window.location.href = "detail.html";
}

function alterarAtual(codigo){
localStorage.setItem("tipoUsuarioAcao", JSON.stringify(2));
localStorage.setItem("codigoTipoUsuarioSelecionado",JSON.stringify(codigo));
window.location.href = "detail.html";
}

function excluirAtual(codigo){
localStorage.setItem("tipoUsuarioAcao", JSON.stringify(3));
localStorage.setItem("codigoTipoUsuarioSelecionado",JSON.stringify(codigo));
window.location.href = "detail.html";
}