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
            var docNewCommmand =  new Command("new", "Indica a criação de um novo projeto"); // doc new
            docCommmand.Add(docNewCommmand);
            var docDelCommmand =  new Command("remove", "Remove um projeto criado"); // doc remove
            docCommmand.Add(docDelCommmand); // doc new --path
            var path = new Option<string>(
                name: "--path",
                description: "recebe o caminho dos projetos desejados"
                
            ){IsRequired = true};
            docNewCommmand.Add(path);
            var project = new Option<string>(
                name: "--project",
                description: "recebe o nome do projeto"
            ){IsRequired = true};
            docNewCommmand.Add(project);

            string[] argsTest = {"doc","new","--path","scscscscscsc"};
            rootCommand.Invoke(argsTest);
        }

    }
}