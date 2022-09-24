namespace DocWrite;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
public class LerTodoArquivo
{
     public static string LerTudo(string path){
          using (StreamReader sr = new StreamReader(path))
          { 
                return sr.ReadToEnd();
          }
     }
}