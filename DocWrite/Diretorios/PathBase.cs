namespace DocWrite;
using System.IO;
public class PathBase
{
     public static string GetPathBaseConf(){
          using (StreamReader rdBase = new StreamReader($"{Directory.GetCurrentDirectory()}/base.conf"))
          {
               return $"{rdBase.ReadLine()!.Replace("path:","")}/ProjectsDocWrite/projects.conf".Replace("//","/"); 
          }
       
     }
}