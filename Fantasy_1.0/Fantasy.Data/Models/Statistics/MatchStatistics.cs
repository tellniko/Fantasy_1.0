
using Fantasy.Data.Models.Statistics.Contracts;

namespace Fantasy.Data.Models.Statistics
{
    public class MatchStatistics : BaseStatistics, IMatchStatistics
    {
        public short Appearances { get; set; }

        public short Wins { get; set; }

        public short Losses { get; set; }
    }
}
