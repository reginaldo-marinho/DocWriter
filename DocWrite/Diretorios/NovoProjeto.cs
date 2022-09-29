namespace DocWrite;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
public class NovoProjeto
{
     
     public static void RegistraProjetoNaListaDeProjetos(string path,string projeto){
          var pathListaProjetos = PathBase.GetPathBaseConf();
          EscreverArquivo.AdicionarLinha(pathListaProjetos,$"{projeto}:{path}/{projeto}".Replace("//","/"));
     }
     public static void CriarNovoProjeto(string path,string projeto,string tamplete){
          RegistraProjetoNaListaDeProjetos(path,projeto);
          StringBuilder build = new StringBuilder();
          build.AppendLine($"proj:{projeto}");
          build.AppendLine($"endpoint:{path}");
          build.AppendLine("livro:{endpoint}/{proj}");
          build.AppendLine("pagina:{livro}/pages/{pagina}");
          build.AppendLine("assets:/pages/{pagina}/assets");
          build.AppendLine("html:/pages/{pagina}/{nome}.html");
          build.AppendLine("fogx:/pages/{pagina}/{nome}.fogx");
          build.AppendLine($"tamplate:{tamplete}");
          CriacaoPasta.ChecarCriarDiretorio($"{path}/{projeto}".Replace("//","/"));
          CriacaoArquivo.ChecarCriarArquivo($"{path}/{projeto}/{projeto}.conf".Replace("//","/"));
          EscreverArquivo.Escrever($"{path}/{projeto}/{projeto}.conf".Replace("//","/"),build.ToString());
          CriarContentsDefult(path,projeto);
     }
     private static void CriarContentsDefult(string path,string projeto){
          CriacaoPasta.ChecarCriarDiretorio($"{path}/{projeto}/pages".Replace("//","/"));
          CriacaoArquivo.ChecarCriarArquivo($"{path}/{projeto}/index.html".Replace("//","/"));
          CriacaoArquivo.ChecarCriarArquivo($"{path}/{projeto}/style.css".Replace("//","/"));
          CriacaoPasta.ChecarCriarDiretorio($"{path}/{projeto}/lc".Replace("//","/"));
          CriacaoArquivo.ChecarCriarArquivo($"{path}/{projeto}/lc/lc.html".Replace("//","/"));
          CriacaoArquivo.ChecarCriarArquivo($"{path}/{projeto}/lc/lc.fogx".Replace("//","/"));
     }
}