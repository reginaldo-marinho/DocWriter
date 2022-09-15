using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using DocWrite.tag;

namespace DocWrite;
public class ExtracaoModeloHTML:IExtracaoModelo
 {
    private string ModeloInput;
    IExpressaoRegular ExpessaoRegular;
    private Regex rx;
    public ExtracaoModeloHTML(){}  
    public ExtracaoModeloHTML(IModeloInput modeloInput,IExpressaoRegular expessaoRegular){
        this.ExpessaoRegular = expessaoRegular;
        this.ModeloInput = modeloInput.GetModelo();
    }
    public string GetDocumentoFormatado(){
        return ModeloInput;
    }
    public string ExtrairFuncao(){
        PreparaMatchGroups();
        return "";
    }
    public MatchCollection GetMatchCollection(IExpressaoRegular expessaoRegular,ref string modelo)
    {
        rx = new Regex($@"{expessaoRegular.GetExpressao()}", RegexOptions.Compiled);
        return rx.Matches(modelo);
    }

    public void PreparaMatchGroups()
    {  
        MatchCollection matches = GetMatchCollection(this.ExpessaoRegular,ref this.ModeloInput);
        if(matches.Count  < 1)
        {
            return;
        }
        if (matches.Count >= 1 )
        {
            foreach (Match match in matches)
            {
                PreparaHTML(match.Groups,ref this.ModeloInput); 
            }
        }
        PreparaMatchGroups();
    }
    public string  PreparaHTML(GroupCollection groups, ref string texto){
        MappingModelo mappingModelo =  GetMappingModelo();

        var modelo = (from m in mappingModelo.Modelo
                        where  m.Identificador ==  groups[1].Value
                        select m).FirstOrDefault(); 
        if (modelo is null)
        {
            ReplaceModelo(groups[0].Value,AdicionarIndicadorInexistente(groups[0].Value),ref texto);
            return "";
        }
        var atributos = PreparaAtributos(groups[3].Value,modelo?.Atributo!);

        string HTML = $"<{modelo?.TagHtml} {atributos}> {groups[4].Value}</{modelo?.TagHtml}>";

        ReplaceModelo(groups[0].Value,HTML,ref texto);

        return "";
        
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
            AtributosHTML+= $" {atributoHTML.AtributoHtml}";

        if (! atributoHTML.IsClass && atributoDesmembrado.Length == 2)
            AtributosHTML+= $" {atributoHTML.Identificador}=\"{atributoDesmembrado[1]}\"";
            
        }
        }
        return AtributosHTML+= $" class=\"{AtributoClass}\"";
    }
    public void ReplaceModelo(string Mathfuncao,string html,ref string modelo){
        modelo = modelo.Replace(Mathfuncao,html);
    }
    public string AdicionarIndicadorInexistente(string grupo){
        rx = new Regex(@"^[A-Z]+", RegexOptions.Compiled);
        var math = rx.Match(grupo);
        return Regex.Replace(grupo,@"^[A-Z]+",$"{math.Groups[0].Value}????");
    }
    public MappingModelo GetMappingModelo(){
        using (StreamReader r = new StreamReader("/home/reginaldo/Desenvolvimento/DocWriter/DocWrite/modelo.json"))
        {
            string json = r.ReadToEnd();
            MappingModelo? modelo = JsonSerializer.Deserialize<MappingModelo>(json);
            return modelo!;
        }
    }
 }
 
 
 