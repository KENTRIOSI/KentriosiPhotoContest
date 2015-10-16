namespace KentriosiPhotoContest.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using KentriosiPhotoContest.Models;

    public class KentriosiPhotoContext : IdentityDbContext<User>
    {
        public KentriosiPhotoContext()
            : base("KentriosiPhotosContest")
        {
        }

        public IDbSet<Contest> Contests { get; set; }

        public IDbSet<ContestStrategy> ContestStrategies { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<Prize> Prizes { get; set; }

        public IDbSet<Vote> Votes { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public static KentriosiPhotoContext Create()
        {
            return new KentriosiPhotoContext();
        }
    }
}