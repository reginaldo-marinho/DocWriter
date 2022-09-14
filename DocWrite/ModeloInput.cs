namespace DocWrite;
public class ModeloInput:IModeloInput 
{
     public ModeloInput(string modelo){
          this.Modelo = modelo;
     }
     private string Modelo{get;set;}
     public string GetModelo (){
          return this.Modelo;
     }    
}