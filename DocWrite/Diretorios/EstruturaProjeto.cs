namespace DocWrite.Conversor;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using DocWrite.Content;


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
               CopiaArquivosBase.CorpiarArquivosBase($"{PathBase.GetPathBaseDocWriter()}DocWrite/Files-base/content.json",this.Projeto.Content);
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
          extracao.ExtrairFuncao ();
          Content? content = JsonSerializer.Deserialize<Content>(this.Projeto.Content);
          content.Body =  extracao.GetDocumentoFormatado();
          EscreverArquivo.Escrever(Projeto.Content,JsonSerializer.Serialize<Content>(content));;
     }
}