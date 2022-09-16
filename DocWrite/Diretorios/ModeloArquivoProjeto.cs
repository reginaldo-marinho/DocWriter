namespace DocWrite;
using System.Text.RegularExpressions;
using System.IO;
public class ModeloArquivoProjeto : IModeloArquivoProjeto
{
     public string Projeto {get;set;} = "";
     public string Paginas {get;set;} = "";
     public string EndPoint {get;set;} = "";     
     public string Assets{get;set;} = "";
     public string Docs {get;set;} = "";
}