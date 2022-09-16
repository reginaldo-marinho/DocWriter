namespace DocWrite.Diretorios;

using System.Text.RegularExpressions;
using System.IO;

public class ArquivoConfiguracaoFconf
{
    public static IModeloArquivoProjeto CheckDiretorio(string projeto)
     {
          var conf = @"/home/reginaldo/Desenvolvimento/DocWriter/fconf.fconf";
          IModeloArquivoProjeto modeloArquivo = new ModeloArquivoProjeto();
          using (StreamReader sr = new StreamReader(conf))
          {
               Regex rg = new  Regex(@"^[A-Z-a-z-0-9]+",RegexOptions.Compiled);
               byte linhaProjeto = 0;
               bool encontrou = false;
               string ChaveModeloConfiguracao ="";
               string ConteudoModeloConfiguracao ="";
               string line;
               
               while ((line = sr.ReadLine()!) != null)
               {
                    ChaveModeloConfiguracao = rg.Match(line).Value;
                    ConteudoModeloConfiguracao = Regex.Replace(line,rg.Match(line).Value+":","");

                    if (line.Equals($"proj:{projeto}"))
                         encontrou = true;
                    if (encontrou){
                         linhaProjeto++;
                         switch(ChaveModeloConfiguracao){
                              case "proj":
                                   modeloArquivo.Projeto = ConteudoModeloConfiguracao;
                                   break;
                              case "endpoint":
                                   modeloArquivo.EndPoint = ConteudoModeloConfiguracao;
                                   break;
                              case "paginas":
                                   modeloArquivo.Paginas = ConteudoModeloConfiguracao;
                                   break;
                              case "assets":
                                   modeloArquivo.Assets = ConteudoModeloConfiguracao;
                                   break;
                              case "docs":
                                   modeloArquivo.Docs = ConteudoModeloConfiguracao;
                                   break;
                         }
                         if(linhaProjeto == 4){
                              break;
                         }
                    }              
               }
          }
          return   modeloArquivo;
     }
}
