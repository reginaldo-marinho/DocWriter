namespace DocWrite.tag;
public class MappingModelo{
    public  Modelo[] Modelo{ get;set;}
 }
public class Modelo{
    public string Identificador {get;set;}
    public string Html {get;set;}
    public  Atributo[] Atributo { get;set;}    
 }

public class Atributo{
    public string Identificador {get;set;}
    public string Html {get;set;}
    public bool IsClass {get;set;}
 }
