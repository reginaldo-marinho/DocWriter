
using DocWrite;
using DocWrite.tag;
using System.Text.RegularExpressions;
using System.Linq;

namespace DocWriterTest;

[TestClass]
public class TransforHTML
{
    private string texto = @"H(B,I,S,C=RED){ sage X3} T(){Tudo que e S(B,I,S){importante} para voce aplicar no sage}";
    ExtracaoModeloHTML extracao = new ExtracaoModeloHTML();
   
    [TestMethod]
    public void PreparaAtributo()
    {
         MappingModelo  Modelo = extracao.GetMappingModelo(); 
         
         var modelo = (from m in Modelo.Modelo
                          where  m.Identificador ==  "H"
                          select m).First(); 
     
        var atributos = extracao.PreparaAtributos("B,I,S",modelo.Atributo);
       
       Assert.Equals(atributos, "class=\" B I S\"");
        
    }

    [TestMethod]
    public void VerificarHTMLFormado()
    {
        MatchCollection maths = extracao.GetMatchCollection(new ModeloFuncao(),ref texto);
       string teste =  extracao.PreparaHTML(maths[0].Groups);  
         
    }


    
}