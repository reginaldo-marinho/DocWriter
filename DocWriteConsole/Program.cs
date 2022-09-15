using DocWrite;
class Program
{
    static void Main(string[] args)
    {
        string text = @"HHHHH(BIS,C=RED){ sage X3} T(){Tudo que e S(BIS,){importante} para voce aplicar no sage}";

         DocWrite.ExtracaoModeloHTML HTML = new ExtracaoModeloHTML(new ModeloInput(text),new ModeloFuncao());
        Console.Read();
        }
    }
