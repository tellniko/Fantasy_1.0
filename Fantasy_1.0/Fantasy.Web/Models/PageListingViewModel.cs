﻿namespace Fantasy.Web.Models
{
    public class PageListingViewModel
    {
        public int CurrentPage { get; set; }

        //public int TotalPages { get; set; }

        //public int PreviousPage => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;

        //public int NextPage => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;
    }
}
