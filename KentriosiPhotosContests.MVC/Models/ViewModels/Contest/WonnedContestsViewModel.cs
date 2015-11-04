using System;
using System.Collections.Generic;
using System.Linq;namespace KentriosiPhotoContest.MVC.Models.ViewModels.Contest
{
    using KentriosiPhotoContest.MVC.Infrastructure.Mapping;

    public class WonnedContestsViewModel:IMapFrom<KentriosiPhotoContest.Models.Contest>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DeadLineDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
