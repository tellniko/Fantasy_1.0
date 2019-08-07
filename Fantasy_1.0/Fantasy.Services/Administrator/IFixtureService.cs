using Fantasy.Services.Administrator.Models;
using System.Collections.Generic;

namespace Fantasy.Services.Administrator
{
    public interface IFixtureService
    {
        string Create(FixtureServiceModel model);

        IEnumerable<FixtureServiceModel> GetByGameweek(int id);
    }
}
