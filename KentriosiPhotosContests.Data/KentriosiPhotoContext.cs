namespace KentriosiPhotoContest.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;
    using Migrations;

    public class KentriosiPhotoContext : IdentityDbContext<User>
    {
        public KentriosiPhotoContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<KentriosiPhotoContext, Configuration>());
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.ContestsInvitedIn)
                .WithMany(u => u.InvitedVoters)
                .Map(m =>
                    m.MapLeftKey("UserId")
                    .MapRightKey("ContestId")
                    .ToTable("ContestsInvitations"));

            modelBuilder.Entity<User>()
                .HasMany(u => u.ContestsParticipated)
                .WithMany(u => u.AllowedParticipants)
                .Map(m =>
                    m.MapLeftKey("UserId")
                    .MapRightKey("ContestId")
                    .ToTable("ContestsParticipants"));

            modelBuilder.Entity<User>()
                .HasMany(u => u.ContestsWon)
                .WithMany(u => u.Winners)
                .Map(m =>
                    m.MapLeftKey("UserId")
                    .MapRightKey("ContestId")
                    .ToTable("ContestsWinners"));
            base.OnModelCreating(modelBuilder);
        }
    }
}