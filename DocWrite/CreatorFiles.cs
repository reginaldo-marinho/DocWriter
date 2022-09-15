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
}