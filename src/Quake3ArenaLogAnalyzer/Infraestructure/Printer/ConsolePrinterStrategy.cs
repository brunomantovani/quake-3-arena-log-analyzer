using Quake3ArenaLogAnalyzer.Common;
using Quake3ArenaLogAnalyzer.Infraestructure.Printer.Abstractions;
using System.Text.Json;

namespace Quake3ArenaLogAnalyzer.Infraestructure.Printer
{
    public sealed class ConsolePrinterStrategy
        : IPrinterStrategy
    {
        const string HeaderSeparator = "############################################";

        public void Print(string title, object body)
        {
            WriteTitle(title);
            WriteBody(body);
        }

        private static void WriteTitle(string title)
        {
            Console.WriteLine(HeaderSeparator);
            Console.WriteLine(title);
            Console.WriteLine(HeaderSeparator);
        }

        private static void WriteBody(object value)
        {
            var outputJson = JsonSerializer.Serialize(value, options: Constants.DefaultJsonSerializerOptions);
            Console.WriteLine(outputJson);
        }
    }
}
