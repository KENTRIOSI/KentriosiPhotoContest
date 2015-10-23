namespace KentriosiPhotoContest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;


    public class Vote
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0,5)]
        public int Value { get; set; }

        public virtual User Owner { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
    }
}
