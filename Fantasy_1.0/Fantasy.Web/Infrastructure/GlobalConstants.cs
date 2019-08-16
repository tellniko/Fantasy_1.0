namespace Fantasy.Web.Infrastructure
{
    public static class GlobalConstants
    {
        public const string DefaultPlayerImageUrl =
            "//premierleague-static-files.s3.amazonaws.com/premierleague/photos/players/250x250/Photo-Missing.png";

        public const string AdministratorRole = "Administrator";

        public const string TempDataSuccessMessageKey = "SuccessMessage";
        public const string TempDataErrorMessageKey = "ErrorMessage";

        public const string Goalkeeper = "Goalkeeper";
        public const string Defender = "Defender";
        public const string Midfielder = "Midfielder";
        public const string Forward = "Forward";

        public const string Goalkeeping = "Goalkeeping";
        public const string Defence = "Defence";
        public const string Attack = "Attack";
        public const string TeamPlay = "TeamPlay";
        public const string Discipline = "Discipline";
        public const string Match = "Match";

        public const int PlayersListingPageSize = 35;
    }
}
