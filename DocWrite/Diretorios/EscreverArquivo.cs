namespace DocWrite;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
public class EscreverArquivo
{
     public static void Escrever(string PathFile,string conteudo)
     {
          using (StreamWriter fileStream = new StreamWriter(PathFile))
          {
               fileStream.Write(conteudo);
          }
     }
}