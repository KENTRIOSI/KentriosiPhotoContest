namespace KentriosiPhotoContest.Models
{
    using System.ComponentModel.DataAnnotations;
    using Enums;

    public class ContestStrategy
    {
        [Key]
        public int Id { get; set; }

        public int WinnersCount { get; set; }

        public DeadLine DeadlineStrategy { get; set; }

        [Required]
        public bool IsOpenForAllContesters { get; set; }

        [Required]
        public bool IsOpenForAllVoters { get; set; }
    }
}
