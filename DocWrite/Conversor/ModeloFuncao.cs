namespace DocWrite.Conversor;
public class ModeloFuncao:IExpressaoRegular
 {
     private readonly string ExpressaoRegular = @"([A-Z-0-9]+)(\(([^()};]*)\){)([^{}]*)(\})"; 
     public string GetExpressao(){
          return this.ExpressaoRegular;
     }
}