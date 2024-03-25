namespace Quake3ArenaLogAnalyzer.Infraestructure.Printer.Abstractions
{
    public interface IPrinterStrategy
    {
        void Print(string title, object value);
    }
}
