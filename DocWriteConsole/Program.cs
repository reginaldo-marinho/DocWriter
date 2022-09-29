using System.CommandLine;
using DocWrite;
using DocWrite.Diretorios;

namespace DocWriteConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var rootCommand = new RootCommand();
            var docCommmand = new Command("doc", "Comando inicial para todos dos outros comandos");
            rootCommand.Add(docCommmand);

            var docConfCommmand =  new Command("conf", "configuração"); 
            docCommmand.Add(docConfCommmand);
            var basePath = new Option<string>(
                name:"--base-path",
                description:"localização do arquivo de configuração"
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

            var docProjectCommmand =  new Command("project", "indica um  projeto já criado"); 
            docProjectCommmand.AddAlias("p");
            docCommmand.Add(docProjectCommmand);
            var ProjectArgument = new Argument<string> (name: "nome-projeto",description: "nome do projeto");
            docProjectCommmand.Add(ProjectArgument);

            var docAddCommmand =  new Command("add", "adicionada  uma  no pagina no projeto");
            docAddCommmand.AddAlias("a");
            docProjectCommmand.Add(docAddCommmand); 

            var PaginaArgument = new Argument<string> (name: "pagina",description: "Pagina do projeto"); 
            docAddCommmand.Add(PaginaArgument);
            docAddCommmand.SetHandler((projeto,pagina) => {
                EstruturaProjeto EstruturaProjeto = new EstruturaProjeto(ArquivoConfiguracaoConf.CheckDiretorio(projeto,pagina));
                EstruturaProjeto.ChecaPreparaEstruturaProjeto();
            },ProjectArgument,PaginaArgument);

            var docRunCommmand =  new Command("run", "Cria o documento Html");
            docRunCommmand.AddAlias("r");
            docCommmand.Add(docRunCommmand);
            docRunCommmand.Add(ProjectArgument);
            docRunCommmand  .Add(PaginaArgument);

            docRunCommmand.SetHandler((projeto,pagina) => {
                EstruturaProjeto EstruturaProjeto = new EstruturaProjeto(ArquivoConfiguracaoConf.CheckDiretorio(projeto,pagina));
                EstruturaProjeto.ChecaPreparaEstruturaProjeto();
                EstruturaProjeto.Run();
            },ProjectArgument,PaginaArgument);
            
            rootCommand.Invoke(args);
        }
    }
}