namespace Fantasy.Services.Models.Contracts
{
    public interface IHaveMidfielderDefenceStatistics : IHaveForwardDefenceStatistics
    {
        short DefenceRecoveries { get; set; }

        short DefenceDuelsWon { get; set; }

        short DefenceDuelsLost { get; set; }

        short DefenceSuccessfulFiftyFifties { get; set; }

        short DefenceAerialBattlesWon { get; set; }

        short DefenceAerialBattlesLost { get; set; }
    }
}