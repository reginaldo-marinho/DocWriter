
using DocWrite;
using DocWrite.tag;
using System.Text.RegularExpressions;
using DocWrite.Diretorios;

namespace DocWriterTest;

[TestClass]
public class TransforHTML
{
      private string texto = @"H(B,I,S,C=RED){ sage X3} T(){Tudo que e S(B,I,S){importante} para voce aplicar no sage}";
      ExtracaoModelo extracao = new ExtracaoModelo();
      
      [TestMethod]
      public void PreparaAtributo()
      {
            ModeloHTML  Modelo = extracao.GetMappingModeloHTML("T"); 
            
      
             var atributos  = extracao.PreparaAtributos("B,I,S",Modelo.AtributosDefaut!);

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
      [TestMethod]
      public void CheckDiretorio()
      {
            var teste =  ArquivoConfiguracaoFconf.CheckDiretorio("sage","introducao");
      }

      [TestMethod]
      public void PreparaExtruturaProjeto()
      {
            string Test = @"T(){HTML básico}"+
            "HTML (Linguagem de Marcação de Hipertexto) é o código que você usa para estruturar uma página"+      
            "ALERT1(){Meu gatinho é muito mal humorado}"+
            "TT(){animais}"+
            "LNO(){"+
                  "LI(){macaco}"+
                  "LI(){cachorro}"+
                  "LI(){lebre}"+
                  "LI(){tartatura}"+
                  "LI(){gato}"+
            "}"+
            "TB(){"+
                  "TBR(){"+
                        "TBH(){nome}"+
                        "TBH(){idade}"+
                        "TBH(){sexo}"+
                  "}"+
                  "TBR(){"+
                        "TBD(){reginado}"+
                        "TBD(){25}"+
                        "TBD(){M}"+
                  "}"+
            "}";
            EstruturaProjeto projeto = new  EstruturaProjeto(ArquivoConfiguracaoFconf.CheckDiretorio("sage","animais"),Test);
            projeto.Run();
      }
}