
using DocWrite;
using DocWrite.tag;
using System.Text.RegularExpressions;

namespace DocWriterTest;

[TestClass]
public class SintaxeModel
{    
    private string texto = @"H(B,I,S,C=RED){ sage X3} T(){Tudo que e S(B,I,S){importante} para voce aplicar no sage}";
    ExtracaoModelo? extracao;
    [TestMethod]
    public void EncontrarDoisMaths()
    {
        extracao = new ExtracaoModelo(new ModeloInput(texto),new ModeloFuncao());
        MatchCollection maths = extracao.GetMatchCollection(new ModeloFuncao(),ref texto);
        Assert.AreEqual(maths.Count,2);
    }

    [TestMethod]
    public void EncontrarCincoGrupos()
    {
        extracao = new ExtracaoModelo(new ModeloInput(texto),new ModeloFuncao());
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
        extracao = new ExtracaoModelo(new ModeloInput(texto),new ModeloFuncao());
        MatchCollection maths = extracao.GetMatchCollection(new ModeloFuncao(),ref texto);
        Match match = maths[0];
        GroupCollection groups = match.Groups;
        Assert.AreEqual(groups[0].Value,"H(B,I,S,C=RED){ sage X3}"); 
    }

    [TestMethod]
    public void EncontrarGrupoUM()
    {
        extracao = new ExtracaoModelo(new ModeloInput(texto),new ModeloFuncao());
        MatchCollection maths = extracao.GetMatchCollection(new ModeloFuncao(),ref texto);
        Match match = maths[0];
        GroupCollection groups = match.Groups;
        Assert.AreEqual(groups[1].Value,"H"); 
    }

     [TestMethod]
    public void EncontrarGrupoTRES()
    {
        extracao = new ExtracaoModelo(new ModeloInput(texto),new ModeloFuncao());
        MatchCollection maths = extracao.GetMatchCollection(new ModeloFuncao(),ref texto);
        Match match = maths[0];
        GroupCollection groups = match.Groups;
        Assert.AreEqual(groups[3].Value,"B,I,S,C=RED"); 
    }


    [TestMethod]
    public void EncontrarGrupoQUATRO()
    {
        extracao = new ExtracaoModelo(new ModeloInput(texto),new ModeloFuncao());
        MatchCollection maths = extracao.GetMatchCollection(new ModeloFuncao(),ref texto);
        Match match = maths[0];
        GroupCollection groups = match.Groups;
        Assert.AreEqual(groups[4].Value," sage X3"); 
    }

    [TestMethod]
    public void EncontrarGrupoCINCO()
    {
        extracao = new ExtracaoModelo(new ModeloInput(texto),new ModeloFuncao());
        MatchCollection maths = extracao.GetMatchCollection(new ModeloFuncao(),ref texto);
        Match match = maths[0];
        GroupCollection groups = match.Groups;
        Assert.AreEqual(groups[5].Value,"}"); 
    }
}