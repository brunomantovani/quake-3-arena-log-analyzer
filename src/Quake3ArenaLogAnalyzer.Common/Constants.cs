using System.Text.Json;

namespace Quake3ArenaLogAnalyzer.Common
{
    public abstract class Constants
    {
        public const int Zero = 0;
        public const int PlayerWorldId = 1022;
        public const string PlayerWorldName = "<world>";
        public readonly static JsonSerializerOptions DefaultJsonSerializerOptions = new()
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };
    }
}
