using System.ComponentModel.DataAnnotations;

namespace Fantasy.Data.Models.Statistics
{
    public class AttackStatistics : BaseStatistics
    {
        [Range(0, short.MaxValue)]
        public short Goals { get; set; }

        [Range(0, short.MaxValue)]
        public short PenaltiesScored { get; set; }

        [Range(0, short.MaxValue)]
        public short FreeKicksScored { get; set; }

        [Range(0, short.MaxValue)]
        public short Shots { get; set; }

        [Range(0, short.MaxValue)]
        public short ShotsOnTarget { get; set; }

        [Range(0, short.MaxValue)]
        public short HitWoodwork { get; set; }

        [Range(0, short.MaxValue)]
        public short BigChancesMissed { get; set; }
    }
}
