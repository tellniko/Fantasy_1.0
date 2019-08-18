using Fantasy.Data.Models.Common;

namespace Fantasy.Services.Administrator
{
    public interface IDatabaseService
    {
        string SeedPlayers();

        string SeedStatistics(int gameweekId);

        void ExportFootballPlayers();

        void ExportFootballPlayerInfos();

        void ExportStatistics(Gameweek gameweek);

        string ImportStatistics(int gameweekNumber);
    }
}
