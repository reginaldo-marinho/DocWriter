
using DocWrite;
using DocWrite.tag;
using System.Text.RegularExpressions;

namespace DocWriterTest;

[TestClass]
public class SintaxeModel
{    
    private string texto = @"H(B,I,S,C=RED){ sage X3} T(){Tudo que e S(B,I,S){importante} para voce aplicar no sage}";
    ExtracaoModeloHTML extracao = new ExtracaoModeloHTML();
    [TestMethod]
    public void EncontrarDoisMaths()
    {
        // 1 => H(BIS,C=RED){ sage X3}
        // 2 => S(BIS,){importante}
        MatchCollection maths = extracao.GetMatchCollection(new ModeloFuncao(),ref texto);
        Assert.AreEqual(maths.Count,2);
    }

    [TestMethod]
    public void EncontrarCincoGrupos()
    {
        MatchCollection maths = extracao.GetMatchCollection(new ModeloFuncao(),ref texto);
        foreach (Match match in maths)
        {
            GroupCollection groups = match.Groups;
            Assert.AreEqual(groups.Count,5+1); // + 1 refere-se ao conjunto total dos grupos
        }
    }

    [TestMethod]
    public void EncontrarGrupoCompleto()
    {
        MatchCollection maths = extracao.GetMatchCollection(new ModeloFuncao(),ref texto);
        Match match = maths[0];
        GroupCollection groups = match.Groups;
        Assert.AreEqual(groups[0].Value,"H(B,I,S,C=RED){ sage X3}"); 
    }

    [TestMethod]
    public void EncontrarGrupoUM()
    {
        MatchCollection maths = extracao.GetMatchCollection(new ModeloFuncao(),ref texto);
        Match match = maths[0];
        GroupCollection groups = match.Groups;
        Assert.AreEqual(groups[1].Value,"H"); 
    }

     [TestMethod]
    public void EncontrarGrupoTRES()
    {
        MatchCollection maths = extracao.GetMatchCollection(new ModeloFuncao(),ref texto);
        Match match = maths[0];
        GroupCollection groups = match.Groups;
        Assert.AreEqual(groups[3].Value,"B,I,S,C=RED"); 
    }


    [TestMethod]
    public void EncontrarGrupoQUATRO()
    {
        MatchCollection maths = extracao.GetMatchCollection(new ModeloFuncao(),ref texto);
        Match match = maths[0];
        GroupCollection groups = match.Groups;
        Assert.AreEqual(groups[4].Value," sage X3"); 
    }

    [TestMethod]
    public void EncontrarGrupoCINCO()
    {
        MatchCollection maths = extracao.GetMatchCollection(new ModeloFuncao(),ref texto);
        Match match = maths[0];
        GroupCollection groups = match.Groups;
        Assert.AreEqual(groups[5].Value,"}"); 
    }
}