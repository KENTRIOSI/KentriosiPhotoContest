namespace KentriosiPhotoContest.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using KentriosiPhotoContest.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class KentriosiPhotoContext : IdentityDbContext<ApplicationUser>
    {
        public KentriosiPhotoContext()
            : base("KentriosiPhotoContext")
        {
        }

        public IDbSet<Contest> Contests { get; set; }

        public IDbSet<ContestStrategy> ContestStrategies { get; set; }

        public IDbSet<DeadLineStrategy> DeadLineStrategies { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<Prize> Prizes { get; set; }

        public IDbSet<Vote> Votes { get; set; }

        public static KentriosiPhotoContext Create()
        {
            return new KentriosiPhotoContext();
        }
       
    }

   
}