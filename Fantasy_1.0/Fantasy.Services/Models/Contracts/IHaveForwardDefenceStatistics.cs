namespace Fantasy.Services.Models.Contracts
{
    public interface IHaveForwardDefenceStatistics
    {
        short DefenceTackles { get; set; }

        short DefenceBlockedShots { get; set; }

        short DefenceInterceptions { get; set; }

        short DefenceClearances { get; set; }

        short DefenceHeadedClearance { get; set; }
    }
}