using System;

namespace KentriosiPhotoContest.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        private ICollection<Contest> contestsOwned;
        private ICollection<Contest> contestsInvitedIn;
        private ICollection<Contest> contestsParticipated;
        private ICollection<Contest> contestsWon;


        private ICollection<Vote> votes;
        private ICollection<Image> images;
        private ICollection<Prize> prizesWon;
        private ICollection<Comment> comments;

        private DateTime registeredOn = DateTime.Now;

        public User()
        {
            this.contestsOwned = new HashSet<Contest>();
            this.contestsInvitedIn = new HashSet<Contest>();
            this.contestsParticipated = new HashSet<Contest>();
            this.contestsWon = new HashSet<Contest>();
            this.votes = new HashSet<Vote>();
            this.images = new HashSet<Image>();
            this.prizesWon = new HashSet<Prize>();
            this.comments = new HashSet<Comment>();
        }

        public virtual ICollection<Contest> ContestsOwned
        {
            get { return this.contestsOwned; }
            set { this.contestsOwned = value; }
        }
        [InverseProperty("InvitedVoters")]
        public virtual ICollection<Contest> ContestsInvitedIn
        {
            get { return this.contestsWon; }
            set { this.contestsWon = value; }
        }
        [InverseProperty("AllowedParticipants")]
        public virtual ICollection<Contest> ContestsParticipated
        {
            get { return this.contestsParticipated; }
            set { this.contestsParticipated = value; }
        }
        
        [InverseProperty("Winners")]
        public virtual ICollection<Contest> ContestsWon
        {
            get { return this.contestsWon; }
            set { this.contestsWon = value; }
        }

        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

        public virtual ICollection<Prize> PrizesWon
        {
            get { return this.prizesWon; }
            set { this.prizesWon = value; }
        }
        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public DateTime RegisteredOn
        {
            get { return this.registeredOn; }
            private set { this.registeredOn = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
