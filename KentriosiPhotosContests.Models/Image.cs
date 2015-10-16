namespace KentriosiPhotoContest.Models
{
    using System.Collections.Generic;

    public class Image
    {
        private ICollection<Vote> votes;
        private ICollection<Comment> comments;

        public Image()
        {
            this.votes = new HashSet<Vote>();
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public int ContestId { get; set; }

        public virtual Contest Contest { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Path { get; set; }

        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public bool IsDeleted { get; set; }

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
    }
}
