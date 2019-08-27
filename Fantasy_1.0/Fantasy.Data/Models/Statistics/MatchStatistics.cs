using System.ComponentModel.DataAnnotations;

namespace Fantasy.Data.Models.Statistics
{
    public class MatchStatistics : BaseStatistics
    {
        [Range(0, short.MaxValue)]
        public short Appearances { get; set; }
        [Range(0, short.MaxValue)]

        public short Wins { get; set; }
        [Range(0, short.MaxValue)]
        public short Losses { get; set; }
    }
}
