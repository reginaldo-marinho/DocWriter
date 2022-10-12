
using DocWrite;
using DocWrite.Conversor;
using DocWrite.tag;
using System.Text.RegularExpressions;
using DocWrite.Diretorios;

namespace DocWriterTest;

[TestClass]
public class DiretoriosArquivosTest
{
    
      [TestMethod]
      public void CheckDiretorio()
      {
            var teste =  ArquivoConfiguracaoConf.CheckDiretorio("sage","introducao");
      }

      [TestMethod]
      public void CriarNovoProjeto(){
            NovoProjeto.CriarNovoProjeto("/home/reginaldo/Desenvolvimento","docwrite2","documentation");
      }

       [TestMethod]
      public void ObterPathDoProjeto(){
            var teste  = ArquivoConfiguracaoConf.PathDoProjeto("sage");
      }
      [TestMethod]
      public void ChecarPastaInicialProjeto(){
            Assert.AreEqual("/home/reginaldo/Desenvolvimento/DocWriter",PathBase.GetPathBaseDocWriter());
      }
      [TestMethod]
      public void ChecarBasePathProjetoDocWriter(){
            Assert.AreEqual("/home/reginaldo/Desenvolvimento/DocWriter/DocWrite/base.conf",PathBase.GetPathBaseProjecs());
      }

      [TestMethod]
      public void ChecarCriarPasta(){
            EstruturaProjeto EstruturaProjeto = new EstruturaProjeto(ArquivoConfiguracaoConf.CheckDiretorio("sage-x3","introducao"));
            EstruturaProjeto.ChecaPreparaEstruturaProjeto();
      }

      [TestMethod]
      public void RunPage(){
            EstruturaProjeto EstruturaProjeto = new EstruturaProjeto(ArquivoConfiguracaoConf.CheckDiretorio("sage-x3","introducao"));
            EstruturaProjeto.ChecaPreparaEstruturaProjeto();
            EstruturaProjeto.Run();
      }
}
