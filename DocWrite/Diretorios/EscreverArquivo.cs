namespace DocWrite;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;



public class EscreverArquivo
{
     public static void Escrever(string PathFile,string conteudo)
     {
          try
          {
               using (FileStream fs = new FileStream(PathFile, FileMode.OpenOrCreate))
               {         
                    byte[] info = new UTF8Encoding(false).GetBytes(conteudo);
                    fs.Write(info, 0, info.Length);
               }
          }
          catch(Exception ex)
          {
               Console.WriteLine(ex.Message);
          }
     }
     public static void AdicionarLinha(string PathFile,string conteudo)
     {
          try
          {
     
               using (FileStream fs = new FileStream(PathFile, FileMode.Append))
               {         
                    byte[] info = new UTF8Encoding(false).GetBytes($"{conteudo}\n");
                    fs.Write(info, 0, info.Length);
               }
          }
          catch(Exception ex)
          {
               Console.WriteLine(ex.Message);
          }
     }
}