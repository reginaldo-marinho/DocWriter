namespace DocWrite;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
public class NovoProjeto
{
     
     public static void RegistraProjetoNaListaDeProjetos(string path,string projeto){
          var pathListaProjetos = GetPathBaseConf();
          EscreverArquivo.AdicionarLinha(pathListaProjetos,$"{projeto}:{path}/{projeto}".Replace("//","/"));
     }
     public static string GetPathBaseConf(){
          //using (StreamReader rdBase = new StreamReader("/home/reginaldo/Desenvolvimento/DocWriter/DocWriteConsole/bin/Debug/net6.0/base.conf"))
          using (StreamReader rdBase = new StreamReader($"{Directory.GetCurrentDirectory()}/base.conf"))
          {
               return $"{rdBase.ReadLine()!.Replace("path:","")}/ProjectsDocWrite/projects.conf".Replace("//","/"); 
          }
     }
     public static void CriarNovoProjeto(string path,string projeto,string tamplete){
          RegistraProjetoNaListaDeProjetos(path,projeto);
          StringBuilder build = new StringBuilder();
          build.AppendLine($"proj:{projeto}");
          build.AppendLine($"endpoint:{path}");
          build.AppendLine("livro:{endpoint}/{proj}");
          build.AppendLine("pagina:{livro}/{pagina}");
          build.AppendLine("assets:{pagina}/assets");
          build.AppendLine("docs:{pagina}/docs");
          build.AppendLine("html:{pagina}/{nome}.html");
          build.AppendLine("fogx:{pagina}/{nome}.fogx");
          build.AppendLine("css:{pagina}/{nome}.css");
          build.AppendLine($"tamplate:{tamplete}");
          CriacaoPasta.ChecarCriarDiretorio($"{path}/{projeto}".Replace("//","/"));
          CriacaoArquivo.ChecarCriarArquivo($"{path}/{projeto}/{projeto}.conf".Replace("//","/"));
          EscreverArquivo.Escrever($"{path}/{projeto}/{projeto}.conf".Replace("//","/"),build.ToString());
     }
}