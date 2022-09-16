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
     public void GravarHTML(){
          extracao = new ExtracaoModeloHTML(new ModeloInput(this.Fogx),new ModeloFuncao());
          extracao.ExtrairFuncao();
          CreateFile(Projeto.HTML,extracao.GetDocumentoFormatado());
     }
     private void CreateFile(string PathFile,string html)
     {
          using (FileStream fileStream = File.Open(PathFile, FileMode.OpenOrCreate,FileAccess.ReadWrite))
          {
               Byte[] conteudo = new UTF8Encoding(true).GetBytes(html);

               fileStream.Write(conteudo, 0, conteudo.Length);
          }
     }  
}