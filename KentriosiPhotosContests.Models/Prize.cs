namespace KentriosiPhotoContest.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Prize
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public int WinnerPlace { get; set; }

        
    }
}
