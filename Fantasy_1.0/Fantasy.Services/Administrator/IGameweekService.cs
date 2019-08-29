using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fantasy.Data.Models;
using Fantasy.Services.Administrator.Models;

namespace Fantasy.Services.Administrator
{
    public interface IGameweekService
    {
        List<TModel> GetAll<TModel>();

        TModel GetById<TModel>(int gameweekId);

        bool? Edit(GameweekServiceModel model);

        Task<Gameweek> GetByStart(DateTime start);
    }
}
