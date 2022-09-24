namespace DocWrite;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

public class ConfiguracaoDiretorioBase
{
     public static void ConfigurarDiretorioBase(string basePath){
          CriacaoArquivo.ChecarCriarArquivo($"{Directory.GetCurrentDirectory()}/base.conf");
          EscreverArquivo.Escrever($"{Directory.GetCurrentDirectory()}/base.conf",$"path:{basePath}");
          CriacaoPasta.ChecarCriarDiretorio( $"{basePath}/BaseDocWrite/".Replace("//","/"));
          CriacaoArquivo.ChecarCriarArquivo($"{basePath}/BaseDocWrite/projects.conf".Replace("//","/"));
     } 
 }