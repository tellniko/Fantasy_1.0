using Fantasy.Services.Administrator.Models;

namespace Fantasy.Services.Administrator
{
    public interface IFixtureService
    {
        string Create(FixtureServiceModel model);
    }
}
