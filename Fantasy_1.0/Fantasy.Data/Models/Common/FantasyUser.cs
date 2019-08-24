﻿using Fantasy.Common;
using Fantasy.Data.Models.Game;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fantasy.Data.Models.Common
{

    public class FantasyUser : IdentityUser<string>
    {
        [Required]
        [MinLength(DataConstants.CommonNameMinLength)]
        [MaxLength(DataConstants.CommonNameMaxLength)]
        public string FullName { get; set; }

        [MinLength(DataConstants.CommonNameMinLength)]
        [MaxLength(DataConstants.CommonNameMaxLength)]
        public string SquadName { get; set; }

        public List<FantasyPlayer> Squad { get; set; } = new List<FantasyPlayer>();
    }
}
