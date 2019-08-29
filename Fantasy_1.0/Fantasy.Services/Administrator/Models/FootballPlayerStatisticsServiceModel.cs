using Fantasy.Common.Mapping;
using Fantasy.Services.Models;
using Fantasy.Services.Models.Contracts;
using System.ComponentModel.DataAnnotations;
using Fantasy.Data.Models;

namespace Fantasy.Services.Administrator.Models
{
    public class FootballPlayerStatisticsServiceModel : IMapFrom<GameweekStatistics>, IMapTo<GameweekStatistics>
    {
        [Range(0, short.MaxValue)] public short Goals { get; set; }
        [Range(0, short.MaxValue)] public short PenaltiesScored { get; set; }
        [Range(0, short.MaxValue)] public short FreeKicksScored { get; set; }
        [Range(0, short.MaxValue)] public short Shots { get; set; }
        [Range(0, short.MaxValue)] public short ShotsOnTarget { get; set; }
        [Range(0, short.MaxValue)] public short HitWoodwork { get; set; }
        [Range(0, short.MaxValue)] public short BigChancesMissed { get; set; }


        [Range(0, short.MaxValue)] public short Tackles { get; set; }
        [Range(0, short.MaxValue)] public short BlockedShots { get; set; }
        [Range(0, short.MaxValue)] public short Interceptions { get; set; }
        [Range(0, short.MaxValue)] public short Clearances { get; set; }
        [Range(0, short.MaxValue)] public short HeadedClearance { get; set; }
        [Range(0, short.MaxValue)] public short Recoveries { get; set; }
        [Range(0, short.MaxValue)] public short DuelsWon { get; set; }
        [Range(0, short.MaxValue)] public short DuelsLost { get; set; }
        [Range(0, short.MaxValue)] public short SuccessfulFiftyFifties { get; set; }
        [Range(0, short.MaxValue)] public short AerialBattlesWon { get; set; }
        [Range(0, short.MaxValue)] public short AerialBattlesLost { get; set; }
        [Range(0, short.MaxValue)] public short CleanSheets { get; set; }
        [Range(0, short.MaxValue)] public short GoalsConceded { get; set; }
        [Range(0, short.MaxValue)] public short LastManTackles { get; set; }
        [Range(0, short.MaxValue)] public short OwnGoals { get; set; }
        [Range(0, short.MaxValue)] public short ErrorsLeadingToGoal { get; set; }


        [Range(0, short.MaxValue)] public short YellowCards { get; set; }
        [Range(0, short.MaxValue)] public short RedCards { get; set; }
        [Range(0, short.MaxValue)] public short Fouls { get; set; }
        [Range(0, short.MaxValue)] public short Offsides { get; set; }


        [Range(0, short.MaxValue)] public short Saves { get; set; }
        [Range(0, short.MaxValue)] public short PenaltiesSaved { get; set; }
        [Range(0, short.MaxValue)] public short Punches { get; set; }
        [Range(0, short.MaxValue)] public short HighClaims { get; set; }
        [Range(0, short.MaxValue)] public short Catches { get; set; }
        [Range(0, short.MaxValue)] public short SweeperClearances { get; set; }
        [Range(0, short.MaxValue)] public short GoalKicks { get; set; }


        [Range(0, short.MaxValue)] public short Assists { get; set; }
        [Range(0, short.MaxValue)] public short Passes { get; set; }
        [Range(0, short.MaxValue)] public short BigChancesCreated { get; set; }
        [Range(0, short.MaxValue)] public short Crosses { get; set; }
        [Range(0, short.MaxValue)] public short ThroughBalls { get; set; }
        [Range(0, short.MaxValue)] public short AccurateLongBalls { get; set; }


        [Range(0, short.MaxValue)] public short Appearances { get; set; }
        [Range(0, short.MaxValue)] public short Wins { get; set; }
        [Range(0, short.MaxValue)] public short Losses { get; set; }

        public int PlayerId { get; set; }
        public int GameweekId { get; set; }

    }
}
