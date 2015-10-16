namespace KentriosiPhotoContest.Models
{
    public class ContestStrategy
    {
        public int Id { get; set; }

        public int WinnersCount { get; set; }

        public DeadLine DeadlineStrategy { get; set; }

        public bool IsOpenForAllContesters { get; set; }

        public bool IsOpenForAllVoters { get; set; }
    }
}
