namespace DocWrite;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
public class NovoProjeto
{
     public void CriarNovoProjeto(string projeto, string path){

          CriacaoPasta.ChecarCriarDiretorio($"{path}/{projeto}");
          CriacaoArquivo.ChecarCriarArquivo($"{path}/{projeto}.conf");
          EscreverArquivo.CreateFile($"{path}/{projeto}.conf",ConfiguracaoProjeto(projeto,path));
     }
     private string ConfiguracaoProjeto(string projeto, string path){
          StringBuilder build = new StringBuilder();
          build.AppendFormat("proj:{0}",projeto);
          build.AppendFormat("endpoint:{0}",path);
          build.AppendLine("livro:{endpoint}/{proj}");
          build.AppendLine("pagina:{livro}/{pagina}");
          build.AppendLine("assets:{pagina}/assets");
          build.AppendLine("docs:{pagina}/docs");
          build.AppendLine("html:{pagina}/{nome}.html");
          build.AppendLine("fogx:{pagina}/{nome}.fogx");
          build.AppendLine("css:{pagina}/{nome}.css");
          return build.ToString();
     }
}