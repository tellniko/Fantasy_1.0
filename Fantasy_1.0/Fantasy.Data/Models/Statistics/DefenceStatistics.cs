using Fantasy.Data.Models.Common;

namespace Fantasy.Data.Models.Statistics
{
    public class DefenceStatistics
    {
        public ushort Tackles { get; set; }

        public ushort BlockedShots { get; set; }

        public ushort Interceptions { get; set; }

        public ushort Clearances { get; set; }

        public ushort HeadedClearance { get; set; }

        public ushort Recoveries { get; set; }

        public ushort DuelsWon { get; set; }

        public ushort DuelsLost { get; set; }

        public ushort SuccessfulFiftyFifties { get; set; }

        public ushort AerialBattlesWon { get; set; }

        public ushort AerialBattlesLost { get; set; }

        public ushort CleanSheets { get; set; }

        public ushort GoalsConceded { get; set; }

        public ushort LastManTackles { get; set; }

        public ushort OwnGoals { get; set; }

        public ushort ErrorsLeadingToGoal { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int FixtureId { get; set; }
        public Fixture Fixture { get; set; }
    }
}
