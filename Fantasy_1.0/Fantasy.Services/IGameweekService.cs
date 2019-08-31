using Fantasy.Data.Models;
using Fantasy.Services.Administrator.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fantasy.Services
{
    public interface IGameweekService
    {
        Task<DateTime?> GetStart(int gameweekId);

        Task<Gameweek> GetLast(DateTime? date);

        Task<Gameweek> GetNext(DateTime date);

        List<TModel> GetAll<TModel>();

        TModel GetById<TModel>(int gameweekId);

        bool? Edit(GameweekServiceModel model);

        Task<Gameweek> GetByStart(DateTime start);

    }
}
