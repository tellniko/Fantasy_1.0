using System;
using System.Threading.Tasks;
using Fantasy.Data.Models;

namespace Fantasy.Services
{
    public interface IGameweekService
    {
        Task<DateTime?> GetStart(int gameweekId);

        Task<Gameweek> GetLast(DateTime? date);

        Task<Gameweek> GetNext(DateTime? date);

    }
}
