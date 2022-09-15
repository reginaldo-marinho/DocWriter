namespace DocWrite;
using System.Text.RegularExpressions;
using System.IO;
public class CreatorFiles 
{
     private const string configuracoes = @"/home/reginaldo/Desenvolvimento/DocWriter/";
     private string Projeto {get;set;}= "Projeto.fconf";
     public CreatorFiles(string project){
          this.Projeto = project;
     }     
     public string ConfiguracoesProjeto(){
          string line;
          Regex rx = new Regex($@"^[a-z]+",RegexOptions.Compiled);
          using (StreamReader sr = new StreamReader($"{configuracoes}{Projeto}"))
          {
                while ((line = sr.ReadLine()!) != null)
                {
                    switch (rx.Match(line).Value)
                    {
                         case "path":
                              var path = line.Replace($"path:","");
                         break;
                    }
                }
           
            return "";
          }
     }
     public static async Task CreatorFileFgBackup(string docFogx){
          string  path = @"/home/reginaldo/Desenvolvimento/DocWriter/DocWrite/";
          using (StreamWriter writer = File.CreateText($"{path}backup.fogx"))
          {
               await writer.WriteAsync(docFogx);
          }
     }
     public static async Task CreatorFileHTML(string docFogx){
          string  path = @"/home/reginaldo/Desenvolvimento/DocWriter/DocWrite/";
          using (StreamWriter writer = File.CreateText($"{path}html.html"))
          {
               await writer.WriteAsync(docFogx);
          }
     }
     public bool CreatorNewPasteForProject(string path)
     {
          if (!File.Exists(path))
          {
               Directory.CreateDirectory(path);
               return true;
          }
          return false;
     }
     public void CriarChecarPagina(string path)
     {
          Regex rx = new Regex($@"[^\/]+$",RegexOptions.Compiled);
          if (!File.Exists(path))
          {
               Directory.CreateDirectory(path);
          }
          string nomePrincipal = rx.Match(path).Value.Replace(" ","-");

          if (!File.Exists($"{path}/{nomePrincipal}.fogx"))
          {
               File.Create($"{path}/{nomePrincipal}.fogx");
          }
          if (!File.Exists($"{path}/{nomePrincipal}.css"))
          {
               File.Create($"{path}/{nomePrincipal}.css");
          }
          if (!File.Exists($"{path}/{nomePrincipal}.html"))
          {
               File.Create($"{path}/{nomePrincipal}.html");
          }
          if (!File.Exists($"{path}/assets"))
          {
               Directory.CreateDirectory($"{path}/assets");
          }
          if (!File.Exists($"{path}/docs"))
          {
               Directory.CreateDirectory($"{path}/docs");
          }
           
     }
}