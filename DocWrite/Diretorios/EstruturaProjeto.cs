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
          ChecarCriarDiretorio(this.Projeto.Livro);
          ChecarCriarDiretorio(this.Projeto.Pagina);
          ChecarCriarArquivo(this.Projeto.CSS);
          ChecarCriarArquivo(this.Projeto.HTML);
          ChecarCriarArquivo(this.Projeto.FOGX);
          ChecarCriarDiretorio(this.Projeto.Assets);
          ChecarCriarDiretorio(this.Projeto.Docs);
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
          ChecaPreparaEstruturaProjeto();
          GravarFOGX();
          GravarHTML();
     }
      private void GravarFOGX(){
          extracao = new ExtracaoModelo(new ModeloInput(this.Fogx),new ModeloFuncao());
          extracao.ExtrairFuncao();
          CreateFile(Projeto.FOGX,this.Fogx);          

     }
     private void GravarHTML(){
          extracao = new ExtracaoModelo(new ModeloInput(this.Fogx),new ModeloFuncao());
          extracao.ExtrairFuncao();
          string estrutura = EstruraInicialHTML();
          estrutura = Regex.Replace(estrutura,@"{body}",extracao.GetDocumentoFormatado());
          CreateFile(Projeto.HTML,estrutura);

     }
     private void CreateFile(string PathFile,string html)
     {
          using (FileStream fileStream = File.Open(PathFile,FileMode.OpenOrCreate))
          {
               fileStream.Seek(0, SeekOrigin.End);
               Byte[] conteudo = new UTF8Encoding(true).GetBytes(html);
               fileStream.WriteAsync(conteudo, 0, conteudo.Length).Wait();
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