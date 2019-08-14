using Fantasy.Services.Models.Contracts;

namespace Fantasy.Services.Models
{
    public interface IHaveStatistics 
        : IHaveMatchStatistics, IHaveDisciplineStatistics
    {
    }
}