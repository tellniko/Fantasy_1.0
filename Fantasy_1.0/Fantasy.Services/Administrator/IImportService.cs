namespace Fantasy.Services.Administrator
{
    public interface IImportService
    {
        int ImportPlayers();

        string ImportStatistics(int gameweekId);
    }
}
