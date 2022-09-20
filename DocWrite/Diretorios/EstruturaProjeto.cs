namespace DocWrite;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
public class EstruturaProjeto 
{
     private readonly IModeloArquivoProjeto Projeto;
     private readonly string Fogx;
     private ExtracaoModeloHTML extracao;
     public EstruturaProjeto(IModeloArquivoProjeto configProjeto, string fogx){
          this.Fogx = fogx;
          this.Projeto = configProjeto;
     } 
     public void  PreparaEstruturaProjeto(){
          CreateCheckFolder(this.Projeto.Livro);
          CreateCheckFolder(this.Projeto.Pagina);
          ChecarCriarArquivo(this.Projeto.CSS);
          ChecarCriarArquivo(this.Projeto.HTML);
          ChecarCriarArquivo(this.Projeto.FOGX);
          CreateCheckFolder(this.Projeto.Assets);
          CreateCheckFolder(this.Projeto.Docs);
     }
     private void  CreateCheckFolder(string Pathfolder)
     {          
          if (!File.Exists(Pathfolder))
          {
               Directory.CreateDirectory(Pathfolder);
          }
     }  
     private  void ChecarCriarArquivoHTML(string path){
          ChecarCriarArquivo(path);
     }
     private void ChecarCriarArquivo(string path)
     {
          if (!File.Exists(path))
          {
               File.Create(path);
          }
     }
     private void ChecarCriarDiretorio(string path)
     {
          if (!Directory.Exists(path))
          {
               Directory.CreateDirectory(path);
          }
     }
     public void Run(){
          GravarFOGX();
          GravarHTML();
     }
      private void GravarFOGX(){
          extracao = new ExtracaoModeloHTML(new ModeloInput(this.Fogx),new ModeloFuncao());
          extracao.ExtrairFuncao();
          CreateFile(Projeto.FOGX,this.Fogx);          

     }
     private void GravarHTML(){
          extracao = new ExtracaoModeloHTML(new ModeloInput(this.Fogx),new ModeloFuncao());
          extracao.ExtrairFuncao();
          string estrutura = EstruraInicialHTML();
          estrutura = Regex.Replace(estrutura,@"{body}",extracao.GetDocumentoFormatado());
          CreateFile(Projeto.HTML,estrutura);

     }
     private void CreateFile(string PathFile,string html)
     {
          using (FileStream fileStream = File.Open(PathFile, FileMode.Open,FileAccess.ReadWrite))
          {
               Byte[] conteudo = new UTF8Encoding(true).GetBytes(html);

               fileStream.Write(conteudo, 0, conteudo.Length);
          }
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
          Estrutura.AppendLine("        {body}");
          Estrutura.AppendLine("   </body>");
          Estrutura.AppendLine("</html>");

          return Estrutura.ToString();
     }  
}