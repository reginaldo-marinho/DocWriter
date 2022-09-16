namespace DocWrite.Diretorios;

using System.Text.RegularExpressions;
using System.IO;

public class ArquivoConfiguracaoFconf
{
    public static IModeloArquivoProjeto CheckDiretorio(string projeto,string pagina)
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
               string linhaEmLeitura;
               
               while ((linhaEmLeitura = sr.ReadLine()!) != null)
               {
                    ChaveModeloConfiguracao = rg.Match(linhaEmLeitura).Value;
                    ConteudoModeloConfiguracao = Regex.Replace(linhaEmLeitura,rg.Match(linhaEmLeitura).Value+":","");

                    if (linhaEmLeitura.Equals($"proj:{projeto}"))
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
                              case "livro":
                                   modeloArquivo.Livro = ConteudoModeloConfiguracao;
                                   break;
                              case "assets":
                                   modeloArquivo.Assets = ConteudoModeloConfiguracao;
                                   break;
                              case "docs":
                                   modeloArquivo.Docs = ConteudoModeloConfiguracao;
                                   break; 
                              case "html":
                                   modeloArquivo.HTML = ConteudoModeloConfiguracao;
                                   break;
                              case "css":
                                   modeloArquivo.CSS = ConteudoModeloConfiguracao;
                                   break;
                         }
                         if(linhaProjeto == 7){
                              if (modeloArquivo  is not null)
                              {
                                   modeloArquivo.Livro = modeloArquivo.Livro.Replace("{proj}",modeloArquivo.Projeto);
                                   modeloArquivo.Assets = modeloArquivo.Assets.Replace("{livro}",modeloArquivo.Livro);
                                   modeloArquivo.Docs = modeloArquivo.Docs.Replace("{livro}",modeloArquivo.Livro);   
                                   modeloArquivo.HTML = modeloArquivo.HTML.Replace("{livro}",modeloArquivo.Livro).Replace("{pagina}",pagina);   
                                   modeloArquivo.CSS = modeloArquivo.CSS.Replace("{livro}",modeloArquivo.Livro).Replace("{pagina}",pagina);  
                              }

                              break;
                         }
                    }              
               }
          }
          return   modeloArquivo!;
     }
}
