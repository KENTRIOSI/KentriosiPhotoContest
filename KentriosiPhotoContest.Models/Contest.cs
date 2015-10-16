using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KentriosiPhotoContest.Models
{
    public class Contest
    {
        private ICollection<Prize> prizes;
        private ICollection<ApplicationUser> invitedvoters;
        private ICollection<ApplicationUser> allowedparticipants;
        private ICollection<ApplicationUser> winners;
        private ICollection<Image> images;

        public Contest()
        {
            this.images = new HashSet<Image>();
            this.prizes = new HashSet<Prize>();
            this.invitedvoters = new HashSet<ApplicationUser>();
            this.winners = new HashSet<ApplicationUser>();
            this.allowedparticipants = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }

        public string StatusDescription { get; set; }

        public int ContestStrategyId { get; set; }

        public virtual ContestStrategy ContestStrategy { get; set; }

        public int OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime DeadLineDate { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Prize> Prizes
        {
            get { return this.prizes; }
            set { this.prizes = value; }
        }

        public virtual ICollection<ApplicationUser> InvitedVoters
        {
            get { return this.invitedvoters; }
            set { this.invitedvoters = value; }
        }

        public virtual ICollection<ApplicationUser> AllowedParticipants
        {
            get { return this.allowedparticipants; }
            set { this.allowedparticipants = value; }
        }

        public virtual ICollection<ApplicationUser> Winners
        {
            get { return this.winners; }
            set { this.winners = value; }
        }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }



    }
}
