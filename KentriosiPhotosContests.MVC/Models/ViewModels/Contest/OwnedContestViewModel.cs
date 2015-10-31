namespace KentriosiPhotoContest.MVC.Models.ViewModels.Contest
{
    using System;
    using KentriosiPhotoContest.MVC.Infrastructure.Mapping;

    public class OwnedContestViewModel : IMapFrom<KentriosiPhotoContest.Models.Contest>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DeadLineDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
