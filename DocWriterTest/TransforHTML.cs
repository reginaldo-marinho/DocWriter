
using DocWrite;
using DocWrite.tag;
using System.Text.RegularExpressions;
using DocWrite.Diretorios;

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
                        where  m.Identificador == "H"
                        select m).First(); 
      
            var atributos  = extracao.PreparaAtributos("B,I,S",modelo.Atributo);

            Assert.AreEqual(atributos, " class=\" B I S\"");
      }
      [TestMethod]
      public void VerificarHTMLFormado()
      {
            MatchCollection maths = extracao.GetMatchCollection(new ModeloFuncao(),ref texto);
            string teste =  extracao.PreparaHTML(maths[0].Groups,ref texto);  
      }
      [TestMethod]
      public void ReplaceModelo()
      {
            MatchCollection maths = extracao.GetMatchCollection(new ModeloFuncao(),ref texto);
            string html =  extracao.PreparaHTML(maths[0].Groups,ref texto);  
            extracao.ReplaceModelo(maths[0].Groups[1].Value,html,ref texto);

            var retorno = texto;
      }
      [TestMethod]
      public void IndicarIndicadoNaoExiste()
      {
            extracao = new ExtracaoModeloHTML(new ModeloInput(texto),new ModeloFuncao());
            var indicacao =  extracao.AdicionarIndicadorInexistente("XER(B,I,S,C=RED)");
            Assert.AreEqual(indicacao,"XER????");
      }
      [TestMethod]
      public void ChegarHTMLCriado()
      {
            string textoTest = @"H(){s} T(){ P(){ola mundo} S(B,I,S){importante} no sage} IM(S=https://image.webmotors.com.br/_fotos/anunciousados/gigante/2022/202207/20220730/honda-cb-600f-hornet-wmimagem13432887665.jpg?s=fill&w=1920&h=1440&q=75){}";
            extracao = new ExtracaoModeloHTML(new ModeloInput(textoTest),new ModeloFuncao());
            extracao.ExtrairFuncao();
            textoTest = extracao.GetDocumentoFormatado();
      }
      [TestMethod]
      public void CheckDiretorio()
      {
            var teste =  ArquivoConfiguracaoFconf.CheckDiretorio("sage","introducao");
      }

      [TestMethod]
      public void EstruturaProjeto()
      {
            string textoTest = @"H(){s} T(){ P(){ola mundo} S(B,I,S){importante} no sage} IM(S=https://image.webmotors.com.br/_fotos/anunciousados/gigante/2022/202207/20220730/honda-cb-600f-hornet-wmimagem13432887665.jpg?s=fill&w=1920&h=1440&q=75){}";
            extracao = new ExtracaoModeloHTML(new ModeloInput(textoTest),new ModeloFuncao());
            extracao.ExtrairFuncao();
            textoTest = extracao.GetDocumentoFormatado();
            EstruturaProjeto projeto = new  EstruturaProjeto(ArquivoConfiguracaoFconf.CheckDiretorio("sage","casamentos"),textoTest);
            projeto.RunProjeto();
      }
}