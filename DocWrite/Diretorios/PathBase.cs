namespace DocWrite;
using System.Text.RegularExpressions;
using System.IO;
public class PathBase
{
     public static string GetPathBaseDocWriter(){     
          Regex rg = new Regex(@".*\/DocWriter\/",RegexOptions.Compiled);
          return  $"{rg.Match(Directory.GetCurrentDirectory()).Value}";
     }
     public static string GetPathBaseProjecs(){
          var pathPrjects = $"{GetPathBaseDocWriter()}/DocWrite/base.conf".Replace("//","/");
           if (File.Exists(pathPrjects))
               using (StreamReader rdBase = new StreamReader(pathPrjects))
               {
                    return $"{rdBase.ReadLine()!.Replace("path:","")}/ProjectsDocWrite/projects.conf".Replace("//","/"); 
               }
          return "";
     }
}