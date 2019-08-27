using System.ComponentModel.DataAnnotations;

namespace Fantasy.Data.Models.Statistics
{
    public class DefenceStatistics : BaseStatistics
    {
        [Range(0, short.MaxValue)]
        public short Tackles { get; set; }

        [Range(0, short.MaxValue)]
        public short BlockedShots { get; set; }

        [Range(0, short.MaxValue)]
        public short Interceptions { get; set; }

        [Range(0, short.MaxValue)]
        public short Clearances { get; set; }

        [Range(0, short.MaxValue)]
        public short HeadedClearance { get; set; }

        [Range(0, short.MaxValue)]
        public short Recoveries { get; set; }

        [Range(0, short.MaxValue)]
        public short DuelsWon { get; set; }

        [Range(0, short.MaxValue)]
        public short DuelsLost { get; set; }

        [Range(0, short.MaxValue)]
        public short SuccessfulFiftyFifties { get; set; }

        [Range(0, short.MaxValue)]
        public short AerialBattlesWon { get; set; }

        [Range(0, short.MaxValue)]
        public short AerialBattlesLost { get; set; }

        [Range(0, short.MaxValue)]
        public short CleanSheets { get; set; }

        [Range(0, short.MaxValue)]
        public short GoalsConceded { get; set; }

        [Range(0, short.MaxValue)]
        public short LastManTackles { get; set; }

        [Range(0, short.MaxValue)]
        public short OwnGoals { get; set; }

        [Range(0, short.MaxValue)]
        public short ErrorsLeadingToGoal { get; set; }
    }
}
