namespace DocWrite.Conversor;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;


public class EstruturaProjeto 
{
     private readonly IModeloArquivoProjeto Projeto;
     private readonly string Fogx;
     private ExtracaoModelo extracao;
     public EstruturaProjeto(IModeloArquivoProjeto configProjeto){
            this.Projeto = configProjeto;
     } 
     public void  ChecaPreparaEstruturaProjeto(){

          Regex rg = new Regex (@"\/lc$",RegexOptions.Compiled);
          if(!rg.Match(this.Projeto.Pagina).Value.Equals("/lc")){
               CriacaoPasta.ChecarCriarDiretorio(this.Projeto.Livro);
               CriacaoPasta.ChecarCriarDiretorio(this.Projeto.Pagina);
               CriacaoArquivo.ChecarCriarArquivo(this.Projeto.HTML);
               CriacaoArquivo.ChecarCriarArquivo(this.Projeto.FOGX);
               CriacaoPasta.ChecarCriarDiretorio(this.Projeto.Assets);
          }
     }
     private  void ChecarCriarArquivoHTML(string path){
          CriacaoArquivo.ChecarCriarArquivo(path);
     }
    
     public void Run(){
          GravarHTML();
     }
     private void GravarHTML(){
          extracao = new ExtracaoModelo(new ModeloInput(LerTodoArquivo.LerTudo(Projeto.FOGX)),new ModeloFuncao());
          extracao.ExtrairFuncao();
          EscreverArquivo.Escrever(Projeto.HTML,extracao.GetDocumentoFormatado());
     }
}