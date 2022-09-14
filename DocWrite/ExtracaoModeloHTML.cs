using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using DocWrite.tag;

namespace DocWrite;
public class ExtracaoModeloHTML:IExtracaoModelo
 {
    private string ModeloInput;
    public ExtracaoModeloHTML(){
    }  
    public ExtracaoModeloHTML(IModeloInput modeloInput){
        this.ModeloInput = modeloInput.GetModelo();
    }
    public string ExtrairFuncao(IExpressaoRegular expessaoRegular){
        var mathces = GetMatchCollection(expessaoRegular,ref this.ModeloInput);
        return "";
    }
    public string ExtrairCaixa(IExpressaoRegular expessaoRegular){
        return "";
    }

    public MatchCollection GetMatchCollection(IExpressaoRegular expessaoRegular,ref string modelo)
    {
        Regex rx = new Regex($@"{expessaoRegular.GetExpressao()}", RegexOptions.Compiled);
        return rx.Matches(modelo);
    }

    public void PreparaMatchGroups(MatchCollection matches, ref string modelo)
    {
        if(matches.Count  < 1){
            return;
        }
        if (matches.Count >= 1 )
            foreach (Match match in matches)
            {
                PreparaHTML(match.Groups); 
            }
            PreparaMatchGroups(matches, ref modelo);
    }

    public string  PreparaHTML(GroupCollection groups){
           MappingModelo mappingModelo =  GetMappingModelo();

            var modelo = (from m in mappingModelo.Modelo
                          where  m.Identificador ==  groups[1].Value
                          select m).FirstOrDefault(); 

            var HTML = modelo.Html;

            var atributos = PreparaAtributos(groups[3].Value,modelo.Atributo);

            return  $"<{HTML} {atributos}> {groups[4].Value}</{HTML}>";
    }
    public string GetAtributos(string identificador,string atributos){
        return "";
    }
    public string PreparaAtributos(string modeloAtributos, Atributo[] atributo){

        string AtributosHTML = "";
        string AtributoClass = "";

        foreach(string atr in modeloAtributos.Split(",")){
            var atributoHTML = 
            (from _atributo in atributo
            where _atributo.Identificador == atr
            select _atributo).FirstOrDefault();

        if (atributoHTML is not null){
            if (atributoHTML.IsClass)
            AtributoClass += $" {atributoHTML.Identificador}";     
        
        var atributoDesmembrado = atr.Split("=");
        if (!atributoHTML.IsClass && atributoDesmembrado.Length == 1)
            AtributosHTML+= $" {atributoHTML.Html}";

        if (! atributoHTML.IsClass && atributoDesmembrado.Length == 2)
            AtributosHTML+= $" {atributoHTML.Identificador}=\"{atributoDesmembrado[1]}\"";
            
        }
        }
        return AtributosHTML+= $" class=\"{AtributoClass}\"";
    }
    public MappingModelo GetMappingModelo(){
        using (StreamReader r = new StreamReader("/home/reginaldo/Desenvolvimento/DocWriter/DocWrite/modelo.json"))
        {
            string json = r.ReadToEnd();
            MappingModelo? modelo = JsonSerializer.Deserialize<MappingModelo>(json );
            return modelo ;
        }
    }
    public void ReplaceModelo(string Mathfuncao,string html,ref string modelo){
        modelo = modelo.Replace(Mathfuncao,html);
    }

 }
 
 
 