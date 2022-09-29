namespace DocWrite.Diretorios;

using System.Text.RegularExpressions;
using System.IO;

public class ArquivoConfiguracaoConf
{
     public static string PathDoProjeto(string projeto){
          
          using (StreamReader sr = new StreamReader(NovoProjeto.GetPathBaseConf()))
          {
               string linhaEmLeitura = ""; 
               Regex rg = new  Regex(@"^.+:",RegexOptions.Compiled);
               while ((linhaEmLeitura = sr.ReadLine()!) != null)
               {
                    if (rg.Match(linhaEmLeitura).Value == $"{projeto}:")
                    {
                         return Regex.Replace(linhaEmLeitura,@"^.+:","");
                    }      
               }
               return "";
          }
     } 
     public static IModeloArquivoProjeto CheckDiretorio(string projeto,string nomePagina)
     {
          IModeloArquivoProjeto modeloArquivo = new ModeloArquivoProjeto();
          using (StreamReader sr = new StreamReader($"{PathDoProjeto(projeto)}/{projeto}.conf".Replace("//","/")))
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
                              case "html":
                                   modeloArquivo.HTML = ConteudoModeloConfiguracao;
                                   break;
                              case "fogx":
                                   modeloArquivo.FOGX = ConteudoModeloConfiguracao;
                                   break;
                         }
                         if(linhaProjeto == 7){
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
                                   modeloArquivo.HTML = modeloArquivo.HTML
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
