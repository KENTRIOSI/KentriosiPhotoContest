namespace KentriosiPhotoContest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
