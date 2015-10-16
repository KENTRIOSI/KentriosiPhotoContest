using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KentriosiPhotoContest.Models
{
    public class Image
    {
        private ICollection<Vote> votes;

        public Image()
        {
            this.votes = new HashSet<Vote>();
        }

        public int Id { get; set; }

        public int ContestId { get; set; }

        public virtual Contest Contest { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Path { get; set; }

        public int OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public bool isDeleted { get; set; }
        
        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }

    }
}
