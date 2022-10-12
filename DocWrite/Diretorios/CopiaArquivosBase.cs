
namespace DocWrite;

public class CopiaArquivosBase
{
    public static void  CorpiarArquivosBase(string file, string destino)    
    {
        System.IO.File.Copy(file,destino,true);
    }

}