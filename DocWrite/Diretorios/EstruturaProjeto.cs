namespace DocWrite;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

public class EstruturaProjeto 
{
     private readonly IModeloArquivoProjeto Projeto;
     private readonly string Fogx;
     private ExtracaoModelo extracao;
     public EstruturaProjeto(IModeloArquivoProjeto configProjeto, string fogx){
          this.Fogx = fogx;
          this.Projeto = configProjeto;
     } 
     private void  ChecaPreparaEstruturaProjeto(){
          CriacaoPasta.ChecarCriarDiretorio(this.Projeto.Livro);
          CriacaoPasta.ChecarCriarDiretorio(this.Projeto.Pagina);
          CriacaoArquivo.ChecarCriarArquivo(this.Projeto.CSS);
          CriacaoArquivo.ChecarCriarArquivo(this.Projeto.HTML);
          CriacaoArquivo.ChecarCriarArquivo(this.Projeto.FOGX);
          CriacaoPasta.ChecarCriarDiretorio(this.Projeto.Assets);
          CriacaoPasta.ChecarCriarDiretorio(this.Projeto.Docs);
     }
     private  void ChecarCriarArquivoHTML(string path){
          CriacaoArquivo.ChecarCriarArquivo(path);
     }
    
     public void Run(){
          ChecaPreparaEstruturaProjeto();
          GravarFOGX();
          GravarHTML();
     }
      private void GravarFOGX(){
          extracao = new ExtracaoModelo(new ModeloInput(this.Fogx),new ModeloFuncao());
          extracao.ExtrairFuncao();
          EscreverArquivo.Escrever(Projeto.FOGX,this.Fogx);          

     }
     private void GravarHTML(){
          extracao = new ExtracaoModelo(new ModeloInput(this.Fogx),new ModeloFuncao());
          extracao.ExtrairFuncao();
          string estrutura = EstruraInicialHTML();
          estrutura = Regex.Replace(estrutura,@"{body}",extracao.GetDocumentoFormatado());
          EscreverArquivo.Escrever(Projeto.HTML,estrutura);

     }

     private string EstruraInicialHTML(){

          StringBuilder Estrutura = new StringBuilder();

          Estrutura.AppendLine("<!DOCTYPE html>");
          Estrutura.AppendLine("<html>");
          Estrutura.AppendLine("   <head>");
          Estrutura.AppendLine("        <link rel=\"stylesheet\" type=\"text/css\" href=\"/home/reginaldo/Desenvolvimento/DocWriter/DocWrite/style.css\">");
          Estrutura.AppendLine("        <title> {title} </title>");
          Estrutura.AppendLine(    "</head>");
          Estrutura.AppendLine("   <body>");
          Estrutura.AppendLine("   <div class=\"container\">");
          Estrutura.AppendLine("        {body}");
          Estrutura.AppendLine("   <div>");
          Estrutura.AppendLine("   </body>");
          Estrutura.AppendLine("</html>");

          return Estrutura.ToString();
     }  
}