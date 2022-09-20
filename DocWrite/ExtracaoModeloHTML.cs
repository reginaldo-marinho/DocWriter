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
        ModeloHTML mappingModelo =  GetMappingModeloHTML(groups[1].Value);
 
        if (mappingModelo is null)
        {
            ReplaceModelo(groups[0].Value,AdicionarIndicadorInexistente(groups[0].Value),ref texto);
            return "";
        }
        string atributos = "";
        string HTML = "";

        atributos = PreparaAtributos(groups[3].Value,mappingModelo.Atributos!,mappingModelo.AtributosDefaut!);

        if(atributos != "")
            HTML = $"<{mappingModelo?.TagHtml} {atributos}>{groups[4].Value}</{mappingModelo?.TagHtml}>";
        if(atributos == "")
            HTML = $"<{mappingModelo?.TagHtml}>{groups[4].Value}</{mappingModelo?.TagHtml}>";

        ReplaceModelo(groups[0].Value,HTML,ref texto);   
        
        return "";
        
    }
    public string PreparaAtributos(string modeloAtributos, string[] atributos,string[] atributosDefaut)
    {

        string AtributosHTML = "";
        string AtributoClass = "";
        
        if (atributosDefaut is not null)
        {
            foreach (var defaut in atributosDefaut)
            {
                AtributosHTML += PreparaAtributos(defaut,null,null);   
            }
        }
        foreach(string atr in modeloAtributos.Split(","))
        {
            if (atr == "")
            {
                break;
            }
            string identificador ="";
            string conteudo = "";

            Int32 posiscao = atr.IndexOf("=");

            if ( posiscao > -1)
            {
                identificador = atr.Substring(0,posiscao);
                posiscao+=1;
                conteudo = atr.Substring(posiscao);
            }
            else
            {
                identificador = atr;
            }
            // Verifica se o atributo passado no modelo de função existe na sua lista de atributos permitidos 


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
        if(AtributoClass != ""){
            return AtributosHTML+= $" class=\"{AtributoClass}\"";
        }
        return AtributosHTML;
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
 }
 
 
 