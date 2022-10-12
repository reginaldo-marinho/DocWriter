namespace DocWrite;
using System.Text.RegularExpressions;
using System.IO;
public class ModeloArquivoProjeto : IModeloArquivoProjeto
{
     public string Projeto {get;set;} = "";
     public string EndPoint {get;set;} = "";     
     public string Livro {get;set;} = "";
     public string Pagina {get;set;} = "";
     public string Assets{get;set;} = "";
     public string Content {get;set;} = "";
     public string FOGX {get;set;} = "";
}