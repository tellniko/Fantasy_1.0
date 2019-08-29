﻿namespace Fantasy.Services.Models.Contracts
{
    public interface IHaveDefenderDefenceStatistics
    {
        short CleanSheets { get; set; }

        short GoalsConceded { get; set; }

        short ErrorsLeadingToGoal { get; set; }

        short OwnGoals { get; set; }

        short Recoveries { get; set; }

        short DuelsWon { get; set; }

        short DuelsLost { get; set; }

        short SuccessfulFiftyFifties { get; set; }

        short AerialBattlesWon { get; set; }

        short AerialBattlesLost { get; set; }

        short Tackles { get; set; }

        short BlockedShots { get; set; }

        short Interceptions { get; set; }

        short Clearances { get; set; }

        short HeadedClearance { get; set; }
    }
}