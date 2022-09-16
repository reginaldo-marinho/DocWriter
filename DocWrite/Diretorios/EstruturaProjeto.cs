namespace DocWrite;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
public class EstruturaProjeto 
{
     private readonly IModeloArquivoProjeto Projeto;
     private readonly string Fogx;
     public EstruturaProjeto(IModeloArquivoProjeto configProjeto, string fogx){
          this.Fogx = fogx;
          this.Projeto = configProjeto;
     } 
     public void  RunProjeto(){
          CreateCheckFolder(this.Projeto.Livro);
          CreateCheckFolder(this.Projeto.Pagina);
          CreateFileText(this.Projeto.CSS);
          CreateFileText(this.Projeto.HTML);
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
     private void CreateFileText(string PathFile)
     {
          ChecarCriarFile(PathFile);
           using (FileStream fileStream = File.Open(PathFile, FileMode.Open,FileAccess.ReadWrite))
          {
               Byte[] conteudo = new UTF8Encoding(true).GetBytes(this.Fogx);

               fileStream.Write(conteudo, 0, conteudo.Length);
          }
     }  
     private void ChecarCriarFile(string path){
          
          if (!File.Exists(path))
          {
               File.Create(path);
          }
     }
}