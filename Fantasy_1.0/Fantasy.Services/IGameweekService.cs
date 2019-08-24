using System;
using System.Threading.Tasks;

namespace Fantasy.Services
{
    public interface IGameweekService
    {
        Task<DateTime?> GetStart(int gameweekId);
    }
}
