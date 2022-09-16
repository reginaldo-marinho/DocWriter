namespace DocWrite;
using System.Text.RegularExpressions;
using System.IO;
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
          using (StreamWriter writer = File.CreateText(PathFile))
          {
               writer.WriteAsync(this.Fogx).Wait();
          }
     }  
     private void ChecarCriarFile(string path){
          if (!File.Exists(path))
          {
               File.Create(path);
          }
     }
}