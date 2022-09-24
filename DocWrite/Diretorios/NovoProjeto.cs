namespace DocWrite;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
public class NovoProjeto
{
     private static void GuardaLocalidadeProjeto(string path,string projeto){
          using (StreamReader rdBase = new StreamReader($"{Directory.GetCurrentDirectory()}/base.conf")){
               var arquivoBaseProjetos = $"{rdBase.ReadLine()!.Replace("base:/","")}/BaseDocWrite/projects.conf".Replace("//","/"); 
               EscreverArquivo.Escrever(arquivoBaseProjetos,$"{projeto}:{path}");
          }
     }
     public static void CriarNovoProjeto(string path,string projeto,string tamplete){

          GuardaLocalidadeProjeto(path,projeto);
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