namespace DocWrite;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
public class CriacaoArquivo
{
     public static void ChecarCriarArquivo(string path)
     {
          if (!File.Exists(path))
          {
               File.Create(path);
          }
     }
}