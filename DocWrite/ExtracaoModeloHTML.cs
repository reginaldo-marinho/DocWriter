using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using DocWrite.tag;

namespace DocWrite;
public class ExtracaoModelo:IExtracaoModelo
 {
    private string ModeloInput;
    IExpressaoRegular ExpessaoRegular;
    private Regex rx;
    public ExtracaoModelo(){}  
    public ExtracaoModelo(IModeloInput modeloInput,IExpressaoRegular expessaoRegular){
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
        ModeloHTML mappingModelo =  GetMappingModeloHTML(groups[1].Value);
 
        if (mappingModelo is null)
        {
            ReplaceModelo(groups[0].Value,AdicionarIndicadorInexistente(groups[0].Value),ref texto);
            return "";
        }
        string atributos = "";
        string HTML = "";

        atributos = PreparaAtributos(groups[3].Value!,mappingModelo.AtributosDefaut!);

        if(atributos != "")
            HTML = $"<{mappingModelo?.TagHtml} {atributos}>{groups[4].Value}</{mappingModelo?.TagHtml}>";
        if(atributos == "")
            HTML = $"<{mappingModelo?.TagHtml}>{groups[4].Value}</{mappingModelo?.TagHtml}>";

        ReplaceModelo(groups[0].Value,HTML,ref texto);   
        
        return "";   
    }
    public void ReplaceModelo(string Mathfuncao,string html,ref string modelo){
        modelo = modelo.Replace(Mathfuncao,html);
    }
    public string AdicionarIndicadorInexistente(string grupo){
        rx = new Regex(@"^[A-Z]+", RegexOptions.Compiled);
        var math = rx.Match(grupo);
        return Regex.Replace(grupo,@"^[A-Z]+",$"{math.Groups[0].Value}????");
    }
    public ModeloHTML GetMappingModeloHTML(string identificador){
        using (StreamReader r = new StreamReader("/home/reginaldo/Desenvolvimento/DocWriter/DocWrite/modelohtml.json"))
        {
            string json = r.ReadToEnd();
            return (from modeloHTML in  JsonSerializer.Deserialize<ModeloHTML[]>(json)
                where modeloHTML.Identificador == identificador
                select modeloHTML
             ).FirstOrDefault()!;      
        }
    }
    public ModeloAtributo GetMappingModeloAtributo(string atributo){
        using (StreamReader r = new StreamReader("/home/reginaldo/Desenvolvimento/DocWriter/DocWrite/modelocss.json"))
        {
            string json = r.ReadToEnd();

            return (from modeloCSS in  JsonSerializer.Deserialize<ModeloAtributo[]>(json)
                where modeloCSS.Identificador == atributo
                select modeloCSS
             ).FirstOrDefault()!;            
        }
    }

    public Atributo GetAtributo(string atributo){
        
        string AtributosHTML = "";
        string AtributoClass = "";

        if (atributo is not null)
        {
            string identificador ="";
            string conteudo = "";

            Int32 posiscao = atributo.IndexOf("=");

            if ( posiscao > -1)
            {
                identificador = atributo.Substring(0,posiscao);
                posiscao+=1;
                conteudo = atributo.Substring(posiscao);
            }
            else
            {
                identificador = atributo;
            }

            ModeloAtributo atributoHTML =  GetMappingModeloAtributo(identificador);

            if (atributoHTML is not null)
            {
                if (atributoHTML.IsClass)
                {
                    AtributoClass += $"{atributoHTML.Identificador} ";    
                }
                if (!atributoHTML.IsClass && conteudo == "")
                {
                    AtributosHTML+= $" {atributoHTML.AtributoHtml}";
                }
                if (!atributoHTML.IsClass && conteudo != "")
                {
                    AtributosHTML+= $" {atributoHTML.AtributoHtml}=\"{conteudo}\""; 
                }        
            }
            
        }
        return new Atributo {AtributosHTML = AtributosHTML, AtributoClass = AtributoClass};
    }
    public string PreparaAtributos(string modeloAtributos, string[] atributosDefaut)
    {
              
        Atributo Atributo = new Atributo(){
                AtributoClass = "",
                AtributosHTML = ""
        };
        Atributo ReturnAtributo;

        if (atributosDefaut is not null)
        {
            foreach (var defaut in atributosDefaut)
            {
                ReturnAtributo =  GetAtributo(defaut);   
                Atributo.AtributoClass+= $" {ReturnAtributo.AtributoClass}"; 
                Atributo.AtributosHTML+= $" {ReturnAtributo.AtributosHTML}"; 
            }
        }
        foreach(string atr in modeloAtributos.Split(","))
        {
            if (atr == "")
            {
                break;
            }
            ReturnAtributo =  GetAtributo(atr);   
            Atributo.AtributoClass+= $" {ReturnAtributo.AtributoClass}"; 
            Atributo.AtributosHTML+= $" {ReturnAtributo.AtributosHTML}"; 
        }
        if(Atributo.AtributoClass != ""){
            return Atributo.AtributosHTML+= $" class=\"{Atributo.AtributoClass}\"";
        }
        return Atributo.AtributosHTML;
    }
 }
 
 
 