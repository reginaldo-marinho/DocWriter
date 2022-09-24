using System.CommandLine;

using DocWrite;

namespace DocWriteConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var rootCommand = new RootCommand();
            var docCommmand = new Command("doc", "Commando inicial para todos dos outros comandos");
            rootCommand.Add(docCommmand);

            var docConfCommmand =  new Command("conf", "configuração do DocWrite"); // doc --base-path

            docCommmand.Add(docConfCommmand);
             var basePath = new Option<string>(
                name:"--base-path"
            );
            docConfCommmand.Add(basePath); 
            docConfCommmand.SetHandler(basePath => {
                ConfiguracaoDiretorioBase.ConfigurarDiretorioBase(basePath);
            },basePath);
            
            var docNewCommmand =  new Command("new", "Indica a criação de um novo projeto"); // doc new
            docNewCommmand.AddAlias("-n");

            docCommmand.Add(docNewCommmand);
            var TamplateArgument = new Argument<string>
            (name: "tamplate",
                description: "Define o tipo do tamplete do projeto"
            ).FromAmong(
                "documentation",
                "tutorial",
                "list"
            );
            var path = new Option<string>(
                name:"--path"
            ){IsRequired =true};
            var nameProject = new Option<string>(
                name:"--name"
            ){IsRequired =true};

            docNewCommmand.Add(TamplateArgument);
            docNewCommmand.Add(path);
            docNewCommmand.Add(nameProject);

            docNewCommmand.SetHandler((path,nomeProjeto,tamplate) => {
                NovoProjeto.CriarNovoProjeto(path,nomeProjeto,tamplate);
            },path,nameProject,TamplateArgument);
 // string[] args2 = {"doc","new","documentation","--path=\"/home/reginaldo/Desenvolvimento\"","--name=\"docwrite\""};

            
            rootCommand.Invoke(args);
        }
    }
}