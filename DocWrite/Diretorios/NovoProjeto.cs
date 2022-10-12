namespace DocWrite;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
public class NovoProjeto
{
     public static void RegistraProjetoNaListaDeProjetos(string path,string projeto){
          var pathListaProjetos = PathBase.GetPathBaseProjecs();
          EscreverArquivo.AdicionarLinha(pathListaProjetos,$"{projeto}:{path}/{projeto}".Replace("//","/"));
     }
     public static void CriarNovoProjeto(string path,string projeto,string tamplete){
          RegistraProjetoNaListaDeProjetos(path,projeto);
          CriacaoPasta.ChecarCriarDiretorio($"{path}/{projeto}".Replace("//","/"));
          CreateFileConfigurationPages(path,projeto,tamplete);
          CriarContentsDefult(path,projeto);
     }
     private static void CriarContentsDefult(string path,string projeto){
          CriacaoPasta.ChecarCriarDiretorio($"{path}/{projeto}/pages".Replace("//","/"));
          CriacaoPasta.ChecarCriarDiretorio($"{path}/{projeto}/lc".Replace("//","/"));
          CriacaoArquivo.ChecarCriarArquivo($"{path}/{projeto}/lc/lc.json".Replace("//","/"));
          CriacaoArquivo.ChecarCriarArquivo($"{path}/{projeto}/lc/lc.fogx".Replace("//","/"));
     }
     private static void CreateFileConfigurationPages(string path,string projeto,string tamplete){
          StringBuilder build = new StringBuilder();
          build.AppendLine($"proj:{projeto}");
          build.AppendLine($"endpoint:{path}");
          build.AppendLine("livro:{endpoint}/{proj}");
          build.AppendLine("pagina:{livro}/pages/{pagina}");
          build.AppendLine("assets:/{pagina}/assets");
          build.AppendLine("html:/{pagina}/{nome}.html");
          build.AppendLine("fogx:/{pagina}/{nome}.fogx");
          build.AppendLine($"tamplate:{tamplete}");
          CriacaoArquivo.ChecarCriarArquivo($"{path}/{projeto}/{projeto}.conf".Replace("//","/"));
          EscreverArquivo.Escrever($"{path}/{projeto}/{projeto}.conf".Replace("//","/"),build.ToString());
     }
}