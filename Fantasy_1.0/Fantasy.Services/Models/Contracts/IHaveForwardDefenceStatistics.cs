namespace Fantasy.Services.Models.Contracts
{
    public interface IHaveForwardDefenceStatistics
    {
        short Tackles { get; set; }

        short BlockedShots { get; set; }

        short Interceptions { get; set; }

        short Clearances { get; set; }

        short HeadedClearance { get; set; }
    }
}