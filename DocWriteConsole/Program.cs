using System.CommandLine;

namespace DocWriteConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var delayOption = new Option<int>
    (name: "--delay",
    description: "An option whose argument is parsed as an int.",
    getDefaultValue: () => 42);
var messageOption = new Option<string>
    ("--message", "An option whose argument is parsed as a string.");

var rootCommand = new RootCommand();
rootCommand.Add(delayOption);
rootCommand.Add(messageOption);

rootCommand.SetHandler((delayOptionValue, messageOptionValue) =>
    {
        Console.WriteLine($"--delay = {delayOptionValue}");
        Console.WriteLine($"--message = {messageOptionValue}");
    },
    delayOption, messageOption);
            rootCommand.Invoke(args);

        }   
    }
}