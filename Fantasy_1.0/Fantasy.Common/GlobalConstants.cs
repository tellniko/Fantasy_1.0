namespace Fantasy.Common
{
    public static class GlobalConstants
    {
        public const string DefaultPlayerBigImageUrl =
            "https://premierleague-static-files.s3.amazonaws.com/premierleague/photos/players/250x250/Photo-Missing.png";

        public const string DefaultPlayerSmallImageUrl =
            "https://premierleague-static-files.s3.amazonaws.com/premierleague/photos/players/40x40/Photo-Missing.png";

        public const string AdministratorRole = "Administrator";

        public const string TempDataSuccessMessageKey = "SuccessMessage";
        public const string TempDataErrorMessageKey = "ErrorMessage";

        public const string Goalkeeper = "Goalkeeper";
        public const string Defender = "Defender";
        public const string Midfielder = "Midfielder";
        public const string Forward = "Forward";

        public const int SquadPlayersCount = 22;
        public const int SquadGoalkeeperCount = 3;
        public const int SquadMidfielderCount = 7;
        public const int SquadDefenderCount = 7;
        public const int SquadForwardCount = 5;
        public const int PermittedPlayerFromSameClubCount = 4;
        public const decimal SquadBudget = 200;

        public const int SeasonGamewwekCount = 38;

        public const int PlayersListingPageSize = 13;
    }
}
