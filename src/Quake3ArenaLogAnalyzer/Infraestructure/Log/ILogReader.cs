namespace Quake3ArenaLogAnalyzer.Infraestructure.Log
{
    public interface ILogReader
    {
        public void ReadToEnd(string filePath);
    }
}
