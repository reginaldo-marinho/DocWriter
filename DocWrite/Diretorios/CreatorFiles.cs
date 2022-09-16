namespace DocWrite;
using System.Text.RegularExpressions;
using System.IO;
public class CreatorFiles 
{
     private const string configuracoes = @"/home/reginaldo/Desenvolvimento/DocWriter/";
     private readonly IModeloArquivoProjeto Projeto;
     private readonly string Fogx;
     public CreatorFiles(IModeloArquivoProjeto configProjeto, string fogx){
          this.Fogx = fogx;
          this.Projeto = configProjeto;
     } 
     private void  CreateCheckFolder(string Pathfolder)
     {          
          if (!File.Exists(Pathfolder))
          {
               Directory.CreateDirectory(Pathfolder);
          }
     }  
     private async Task  CreateFileText(string PathFile)
     {
          ChecarCriarFile(PathFile);
          using (StreamWriter writer = File.CreateText(PathFile))
          {
               await writer.WriteAsync(this.Fogx);
          }
     }  
     private void ChecarCriarFile(string path){
          if (!File.Exists(path))
          {
               File.Create(path);
          }
     }
}