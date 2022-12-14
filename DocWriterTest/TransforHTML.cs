
using DocWrite;
using DocWrite.Conversor;
using DocWrite.tag;
using System.Text.RegularExpressions;
using DocWrite.Diretorios;

namespace DocWriterTest;

[TestClass]
public class TransforHTML
{
      string texto = @"H(B,I,S,C=RED){ sage X3} T(){Tudo que e S(B,I,S){importante} para voce aplicar no sage}";
      ExtracaoModelo? extracao;
      
      [TestMethod]
      public void PreparaAtributo()
      {
            extracao = new ExtracaoModelo(new ModeloInput(texto),new ModeloFuncao());
            ModeloHTML  Modelo = extracao.GetMappingModeloHTML("T"); 
            
      
             var atributos  = extracao.PreparaAtributos("B,I,S",Modelo.AtributosDefaut!);

             Assert.AreEqual(atributos, " class=\" B I S\"");
      }
      [TestMethod]
      public void VerificarHTMLFormado()
      {
            extracao = new ExtracaoModelo(new ModeloInput(texto),new ModeloFuncao());
            MatchCollection maths = extracao.GetMatchCollection(new ModeloFuncao(),ref texto);
            string teste =  extracao.PreparaHTML(maths[0].Groups,ref texto);  
      }
      [TestMethod]
      public void ReplaceModelo()
      {
            extracao = new ExtracaoModelo(new ModeloInput(texto),new ModeloFuncao());
            MatchCollection maths = extracao.GetMatchCollection(new ModeloFuncao(),ref texto);
            string html =  extracao.PreparaHTML(maths[0].Groups,ref texto);  
            extracao.ReplaceModelo(maths[0].Groups[1].Value,html,ref texto);

            var retorno = texto;
      }
      [TestMethod]
      public void IndicarIndicadoNaoExiste()
      {
            extracao = new ExtracaoModelo(new ModeloInput(texto),new ModeloFuncao());
            var indicacao =  extracao.AdicionarIndicadorInexistente("XER(B,I,S,C=RED)");
            Assert.AreEqual(indicacao,"XER????");
      }
      [TestMethod]
      public void ChegarHTMLCriado()
      {
            string textoTest = @"H(){s} T(){ P(){ola mundo} S(B,I,S){importante} no sage} IM(S=https://image.webmotors.com.br/_fotos/anunciousados/gigante/2022/202207/20220730/honda-cb-600f-hornet-wmimagem13432887665.jpg?s=fill&w=1920&h=1440&q=75){}"
            +"A(L=./introducao){}";
            extracao = new ExtracaoModelo(new ModeloInput(textoTest),new ModeloFuncao());
            extracao.ExtrairFuncao();
            textoTest = extracao.GetDocumentoFormatado();
      }
     
      
}
