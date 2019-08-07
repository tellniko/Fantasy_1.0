using System.Collections.Generic;
using Fantasy.Services.Administrator.Models;

namespace Fantasy.Services.Administrator
{
    public interface IGameweekService
    {
        IEnumerable<GameweekServiceModel> GetAll();

        GameweekServiceModel Get(int id);

        bool Edit(GameweekServiceModel model);
    }
}
