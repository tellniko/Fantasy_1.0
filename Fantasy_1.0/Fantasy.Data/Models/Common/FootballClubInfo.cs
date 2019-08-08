namespace Fantasy.Data.Models.Common
{
    public class FootballClubInfo : BaseModel<int>
    {
        public string StadiumImgUrl { get; set; }

        public bool Playable { get; set; } = true;

        public string ManagerName { get; set; }

        public string Ground { get; set; }

        public string BadgeUrl { get; set; }

        public string PrimaryKitColor { get; set; }

        public string SecondaryKitColor { get; set; }


        public int ClubId { get; set; }
        public FootballClub FootballClub { get; set; }
    }
}
