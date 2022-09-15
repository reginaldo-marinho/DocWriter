namespace DocWrite;
using System.Text.RegularExpressions;
public class CreatorFiles 
{
     private const string configuracoes = @"/home/reginaldo/Desenvolvimento/DocWriter/";
     private string Projeto {get;set;}= "Projeto.conf";
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
}