namespace DocWrite;
public class CreatorFiles 
{
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