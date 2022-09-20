namespace DocWrite.tag;

public class ModeloHTML{
    public string? Codigo {get;set;}
    public string? Identificador {get;set;}
    public string? TagHtml {get;set;}
    public  string[]? Atributos  { get;set;} 
 }

public class ModeloAtributo{
    public string? Codigo {get;set;}
    public string? Identificador {get;set;}
    public string? AtributoHtml {get;set;}
    public  bool IsClass  { get;set;} 
    public  string? Descricao  { get;set;} 
 }
