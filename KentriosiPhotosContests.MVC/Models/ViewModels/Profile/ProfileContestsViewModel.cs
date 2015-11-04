namespace KentriosiPhotoContest.MVC.Models.ViewModels.Profile
{
    using System;

    using KentriosiPhotoContest.Models;
    using KentriosiPhotoContest.MVC.Infrastructure.Mapping;

    public class ProfileContestsViewModel:IMapFrom<Contest>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DeadLineDate { get; set; }

        public DateTime EndDate { get; set; }


    }
}
