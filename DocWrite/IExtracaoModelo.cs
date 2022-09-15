namespace DocWrite;
public interface IExtracaoFuncao{
     public string ExtrairFuncao();            
}

public interface IExtracaoCaixa{
     string ExtrairCaixa(IExpressaoRegular expessaoRegular);            
}
public interface IExtracaoModelo:IExtracaoFuncao{} 