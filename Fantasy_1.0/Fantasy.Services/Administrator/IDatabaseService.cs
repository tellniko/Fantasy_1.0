using Fantasy.Data.Models.Common;

namespace Fantasy.Services.Administrator
{
    public interface IDatabaseService
    {
        int ImportPlayers();

        string SeedStatistics(int gameweekId);

        void ExportFootballPlayers();

        void ExportFootballPlayerInfos();

        int ExportStatistics(int gameweekId);

        string ImportStatistics(int gameweekId);
    }
}
