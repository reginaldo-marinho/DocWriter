namespace DocWrite;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
public class EscreverArquivo
{
     public static void CreateFile(string PathFile,string html)
     {
          using (StreamWriter fileStream = new StreamWriter(PathFile))
          {
               fileStream.Write(html);
          }
     }
}