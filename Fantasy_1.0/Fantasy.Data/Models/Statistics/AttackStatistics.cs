using Fantasy.Common.Attributes;
using Fantasy.Data.Models.Statistics.Contracts;

namespace Fantasy.Data.Models.Statistics
{
    public class AttackStatistics : BaseStatistics, IAttackStatistics
    {
        public short Goals { get; set; }

        public short PenaltiesScored { get; set; }

        public short FreeKicksScored { get; set; }

        public short Shots { get; set; }

        public short ShotsOnTarget { get; set; }

        public short HitWoodwork { get; set; }

        public short BigChancesMissed { get; set; }
    }
}
