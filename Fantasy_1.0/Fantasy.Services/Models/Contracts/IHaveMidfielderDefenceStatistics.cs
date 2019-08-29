namespace Fantasy.Services.Models.Contracts
{
    public interface IHaveMidfielderDefenceStatistics 
    {
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

        short ErrorsLeadingToGoal { get; set; }
    }
}