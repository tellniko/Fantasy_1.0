namespace Fantasy.Services.Administrator
{
    public interface IExportServices
    {
        //todo refactor
        bool ExportFootballPlayers();

        //todo refactor
        bool ExportFootballPlayerInfos();

        int ExportStatistics(int gameweekId);
    }
}
