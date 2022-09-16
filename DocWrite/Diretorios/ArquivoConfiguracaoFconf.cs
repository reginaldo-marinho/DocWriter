namespace DocWrite.Diretorios;

using System.Text.RegularExpressions;
using System.IO;

public class ArquivoConfiguracaoFconf
{
    public static IModeloArquivoProjeto CheckDiretorio(string projeto,string nomePagina)
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
                              case "pagina":
                                   modeloArquivo.Pagina = ConteudoModeloConfiguracao;
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
                              case "fogx":
                                   modeloArquivo.FOGX = ConteudoModeloConfiguracao;
                                   break;
                         }
                         if(linhaProjeto == 9){
                              if (modeloArquivo  is not null)
                              {
                                   modeloArquivo.Livro = modeloArquivo.Livro
                                   .Replace("{proj}",modeloArquivo.Projeto)
                                   .Replace("{endpoint}",modeloArquivo.EndPoint); 
                                   modeloArquivo.Pagina = modeloArquivo.Pagina
                                   .Replace("{livro}",modeloArquivo.Livro).
                                   Replace("{pagina}",nomePagina);  
                                   modeloArquivo.Assets = modeloArquivo.Assets
                                   .Replace("{pagina}",modeloArquivo.Pagina); 
                                   modeloArquivo.Docs = modeloArquivo.Docs
                                   .Replace("{pagina}",modeloArquivo.Pagina);   
                                   modeloArquivo.HTML = modeloArquivo.HTML
                                   .Replace("{pagina}",modeloArquivo.Pagina)
                                   .Replace("{nome}",nomePagina); 
                                   modeloArquivo.CSS = modeloArquivo.CSS
                                   .Replace("{pagina}",modeloArquivo.Pagina)
                                   .Replace("{nome}",nomePagina); 
                                    modeloArquivo.FOGX = modeloArquivo.FOGX
                                   .Replace("{pagina}",modeloArquivo.Pagina)
                                   .Replace("{nome}",nomePagina); 
                              }

                              break;
                         }
                    }              
               }
          }
          return   modeloArquivo!;
     }
}
