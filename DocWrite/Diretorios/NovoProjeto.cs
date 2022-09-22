namespace DocWrite;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
public class NovoProjeto
{
     public static void CriarNovoProjeto(string path,string projeto,string tamplete){

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
          EscreverArquivo.CreateFile($"{path}/{projeto}/{projeto}.conf".Replace("//","/"),build.ToString());
     }
}