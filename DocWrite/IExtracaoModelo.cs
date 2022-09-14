namespace DocWrite;
public interface IExtracaoFuncao{
     public string ExtrairFuncao(IExpressaoRegular expessaoRegular);            
}

public interface IExtracaoCaixa{
     string ExtrairCaixa(IExpressaoRegular expessaoRegular);            
}
public interface IExtracaoModelo:IExtracaoFuncao,IExtracaoCaixa{} 