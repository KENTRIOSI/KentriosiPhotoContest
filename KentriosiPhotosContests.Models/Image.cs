namespace KentriosiPhotoContest.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Image
    {
        private ICollection<Vote> votes;
        private ICollection<Comment> comments;
        private ICollection<Contest> profilingContests;

        public Image()
        {
            this.votes = new HashSet<Vote>();
            this.comments = new HashSet<Comment>();
            this.profilingContests = new HashSet<Contest>();
        }

        [Key]
        public int Id { get; set; }

        public int AppertainingContestId { get; set; }

        [ForeignKey("AppertainingContestId")]
        public virtual Contest AppertainingContest { get; set; }

        [Required(ErrorMessage = "Image Name is required.")]
        [MaxLength(100, ErrorMessage = "Name should be shorter than 100 chars.")]
        public string Name { get; set; }

        [MaxLength(1000, ErrorMessage = "Description should be shorter than 1000 chars.")]
        public string Description { get; set; }

        [MaxLength(500, ErrorMessage = "Path should be shorter than 500 chars.")]
        public string Path { get; set; }

        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public bool IsDeleted { get; set; }

        public string Extension { get; set; }

        [NotMapped]
        public byte[] Content { get; set; }

        [NotMapped]
        public string MimeType { get; set; }

        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Contest> ProfilingContests
        {
            get { return this.profilingContests; }
            set { this.profilingContests = value; }
        }
    }
}
