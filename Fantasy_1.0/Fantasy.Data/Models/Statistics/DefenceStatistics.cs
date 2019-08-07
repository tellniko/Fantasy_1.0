using Fantasy.Data.Models.Common;
using Fantasy.Data.Models.Players;

namespace Fantasy.Data.Models.Statistics
{
    public class DefenceStatistics
    {
        public short Tackles { get; set; }

        public short BlockedShots { get; set; }

        public short Interceptions { get; set; }

        public short Clearances { get; set; }

        public short HeadedClearance { get; set; }

        public short Recoveries { get; set; }

        public short DuelsWon { get; set; }

        public short DuelsLost { get; set; }

        public short SuccessfulFiftyFifties { get; set; }

        public short AerialBattlesWon { get; set; }

        public short AerialBattlesLost { get; set; }

        public short CleanSheets { get; set; }

        public short GoalsConceded { get; set; }

        public short LastManTackles { get; set; }

        public short OwnGoals { get; set; }

        public short ErrorsLeadingToGoal { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int FixtureId { get; set; }
        public Fixture Fixture { get; set; }
    }
}
