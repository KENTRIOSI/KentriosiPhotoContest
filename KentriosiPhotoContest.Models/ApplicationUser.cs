using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;

namespace KentriosiPhotoContest.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        private ICollection<Contest> contestowned;
        private ICollection<Contest> contestparticipated;
        private ICollection<Contest> contestwon;
        private ICollection<Vote> votes;
        private ICollection<Image> images;
        private ICollection<Prize> prizeswon;

        public ApplicationUser()
        {
            this.contestowned = new HashSet<Contest>();
            this.contestparticipated = new HashSet<Contest>();
            this.contestwon = new HashSet<Contest>();
            this.votes = new HashSet<Vote>();
            this.images = new HashSet<Image>();
            this.prizeswon = new HashSet<Prize>();
        }

        public virtual ICollection<Contest> ContestsParticipated
        {
            get { return this.contestparticipated; }
            set { this.contestparticipated = value; }
        }

        public virtual ICollection<Contest> ContestsWon
        {
            get { return this.contestwon; }
            set { this.contestwon = value; }
        }

        public virtual ICollection<Contest> ContestsOwned
        {
            get { return this.contestowned; }
            set { this.contestowned = value; }
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
            get { return this.prizeswon; }
            set { this.prizeswon = value; }
        }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
