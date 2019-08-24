using System.CodeDom.Compiler;

namespace Fantasy.Services.Models.Contracts
{
    public interface IHaveStatistics
        : IHaveMatchStatistics, IHaveDisciplineStatistics
    {
       string Goalkeeping { get; }
       string Defence { get; }
       string Attack { get; }
       string TeamPlay { get; }
       string Discipline { get; }
       string Match { get; }
    }
}