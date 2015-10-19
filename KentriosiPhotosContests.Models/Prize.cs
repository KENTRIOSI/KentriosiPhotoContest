namespace KentriosiPhotoContest.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Prize
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int WinnerPlace { get; set; }

        
    }
}
