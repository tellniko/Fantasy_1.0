using Fantasy.Data.Models.Common;

namespace Fantasy.Services.Administrator
{
    public interface IDatabaseService
    {
        string SeedPlayers();

        string SeedStatistics();

        void CreateJsonFilePlayers();

        void CreateJsonFilePlayerInfos();

        void CreateJsonFilesStatistics(Gameweek gameweek);

        string SeedStatisticsFromJsonFiles(int gameweekNumber);
    }
}
