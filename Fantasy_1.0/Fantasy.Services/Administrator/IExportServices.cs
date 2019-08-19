namespace Fantasy.Services.Administrator
{
    public interface IExportServices
    {
        //todo refactor
        void ExportFootballPlayers();

        //todo refactor
        void ExportFootballPlayerInfos();

        int ExportStatistics(int gameweekId);
    }
}
