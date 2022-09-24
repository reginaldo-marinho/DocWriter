
using DocWrite;
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
      [TestMethod]
      public void CheckDiretorio()
      {
            var teste =  ArquivoConfiguracaoFconf.CheckDiretorio("sage","int roducao");
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
            "}"+
            "&#128512; &#128512; &#128512; &#128512; &#128512; &#128512; &#128512;"+
            "IM(SR=https://raw.githubusercontent.com/mdn/beginner-html-site/gh-pages/images/firefox-icon.png){}"+
            "CODE(){"+
            "Module Module1"+
            "Sub Main()"+
                  "While True"+
                        "Read value."+
                        "Dim s As String = Console.ReadLine()\n"+
                        " Test the value.\n"+
                        "If s = \"1\" Then"+
                        "Console.WriteLine(\"One\")\n"+
                        "ElseIf s = \"2\" Then\n"+
                        "Console.WriteLine(\"Two\")\n"+
                        "End If\n"+
                        "Write the value.\n"+
                        "Console.WriteLine(\"You typed a\" + s)\n"+
                  "End While"+
            "End Sub"+
            "End Module"+
            "}"+
            "VIDEO(SR=https://archive.org/download/Popeye_forPresident/Popeye_forPresident_512kb.mp4){}"+
            "TT(){Sintaxe Doc Write}"+
            "P(){--run livro pagina }";

            EstruturaProjeto projeto = new  EstruturaProjeto(ArquivoConfiguracaoFconf.CheckDiretorio("sage","index"),Test);
            projeto.Run();
      }
}