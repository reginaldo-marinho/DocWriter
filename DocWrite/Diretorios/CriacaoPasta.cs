namespace DocWrite;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
public class CriacaoPasta
{
    public static void ChecarCriarDiretorio(string path)
     {
          if (!Directory.Exists(path))
          {
               Directory.CreateDirectory(path);
          }
     }
}