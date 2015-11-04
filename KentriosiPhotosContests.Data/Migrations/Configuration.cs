namespace KentriosiPhotoContest.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using KentriosiPhotosContests.Common;
    using Models;
    using Models.Enums;
    using System.Collections.Generic;

    public sealed class Configuration : DbMigrationsConfiguration<KentriosiPhotoContext>
    {
        private IRandomGenerator randomGenerator;
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
            this.randomGenerator = new RandomGenerator();

        }

        public void ExposedSeed()
        {
            this.Seed(new KentriosiPhotoContext());
        }

        protected override void Seed(KentriosiPhotoContext context)
        {
            this.userManager = new UserManager<User>(new UserStore<User>(context));
            this.roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            this.SeedContestStrategies(context);        
            this.SeedUsers(context);
            this.SeedContests(context);
            this.SeedImages(context);
            this.SeedPrizes(context);
            this.SeedVotes(context);

        }

        private void SeedVotes(KentriosiPhotoContext context)
        {
            if (context.Votes.Any())
            {
                return;
            }

            var users = context.Users.ToList();
            var images = context.Images.Where(i => i.Id < 10 && i.Id > 0).ToList();
            for (int i = 0; i < 300; i++)
            {
                var vote = new Vote()
                {
                    Owner = users[this.randomGenerator.RandomNumber(0, users.Count() - 1)],
                    Image = images[this.randomGenerator.RandomNumber(1, images.Count() - 1)],
                    Value = this.randomGenerator.RandomNumber(0, 5),
                    Date = DateTime.Now
                };

                context.Votes.AddOrUpdate(vote);
            }

            context.SaveChanges();
        }

        private void SeedImages(KentriosiPhotoContext context)
        {
            if (context.Images.Any())
            {
                return;
            }

            var users = context.Users.ToList();
            var contests = context.Contests.ToList();
            for (int i = 1; i < 100; i++)
            {
                var contest = contests[this.randomGenerator.RandomNumber(1, contests.Count() - 1)];
                var image = new Image()
                {
                    Name = this.randomGenerator.RandomString(2, 100),
                    AppertainingContest = contest,
                    Description = this.randomGenerator.RandomString(0, 500),
                    Owner = users[this.randomGenerator.RandomNumber(0, users.Count() - 1)],
                    Path = "/",
                    IsDeleted = this.randomGenerator.RandomNumber(0, 100) % 6 == 0,
                    Extension = "jpg"
                };
                context.Images.AddOrUpdate(image);
            }

            context.SaveChanges();

            var images = context.Images.ToList();
            foreach (var contest in contests)
            {
                contest.ContestProfileImage = images[this.randomGenerator.RandomNumber(0, images.Count() - 1)];
            }

            context.SaveChanges();
        }

        private void SeedContests(KentriosiPhotoContext context)
        {
            if (context.Contests.Any())
            {
                return;
            }

            var users = context.Users.ToList();
            var prizes = context.Prizes.ToList();
            var strategies = context.ContestStrategies.ToList();

            for (int i = 0; i < 80; i++)
            {
                var strategy = strategies[this.randomGenerator.RandomNumber(0, strategies.Count() - 1)];
                var previousDate = DateTime.Now - new TimeSpan(this.randomGenerator.RandomNumber(200, 500), 0, 0);
                var futureDate = DateTime.Now + new TimeSpan(this.randomGenerator.RandomNumber(200, 500), 0, 0);
                var deadLineDate = this.randomGenerator.RandomNumber(0, 10) % 3 == 0 ?
                    DateTime.Now - new TimeSpan(this.randomGenerator.RandomNumber(200, 500), 0, 0) :
                    DateTime.Now + new TimeSpan(this.randomGenerator.RandomNumber(200, 500), 0, 0);
                var endDate = this.randomGenerator.RandomNumber(0, 10) % 3 == 0 ?
                    DateTime.Now - new TimeSpan(this.randomGenerator.RandomNumber(200, 500), 0, 0) :
                    DateTime.Now + new TimeSpan(this.randomGenerator.RandomNumber(200, 500), 0, 0);
                var status = (endDate < DateTime.Now || deadLineDate < DateTime.Now) ?
                    ContestStatus.Closed :
                    ContestStatus.Open;
                var images = context.Images.ToList();
                //var image = images[this.randomGenerator.RandomNumber(0, images.Count() - 1)];

                var contest = new Contest()
                {
                    AllowedParticipants = users.Where(ap => ap.UserName.Length % (i + 4) == 0).ToList(),
                    InvitedVoters = users.Where(ap => ap.UserName.Length % (i + 4) == 0).ToList(),
                    Prizes = prizes.Where(p => p.Id % (i + 3) == 0).Take(strategy.WinnersCount).ToList(),
                    ContestStrategy = strategy,
                    Winners = (endDate < DateTime.Now || deadLineDate < DateTime.Now) ?
                    users.Where(ap => ap.UserName.Length % (i + 4) == 0).ToList() :
                    users.Take(0).ToList(),
                    Status = status,
                    DateCreated = previousDate,
                    DateModified = previousDate,
                    EndDate = endDate,
                    DeadLineDate = deadLineDate,
                    //ContestProfileImage = image,
                    Description = this.randomGenerator.RandomString(2, 500),
                    Title = this.randomGenerator.RandomString(2, 99),
                    StatusDescription = status == ContestStatus.Closed ? this.randomGenerator.RandomString(0, 250) : string.Empty,
                    IsDeleted = this.randomGenerator.RandomNumber(0, 100) % 6 == 0,
                    Owner = users[this.randomGenerator.RandomNumber(0, users.Count - 1)]
                };
                context.Contests.AddOrUpdate(contest);
            }

            context.SaveChanges();
        }

        private void SeedPrizes(KentriosiPhotoContext context)
        {
            if (context.Prizes.Any())
            {
                return;
            }

            for (int i = 0; i < 40; i++)
            {
                var prize = new Prize()
                {
                    Name = this.randomGenerator.RandomString(2, 50),
                    Description = this.randomGenerator.RandomString(10, 250),
                    WinnerPlace = this.randomGenerator.RandomNumber(1, 10)
                };
                context.Prizes.AddOrUpdate(prize);
            }

            context.SaveChanges();
        }

        private void SeedContestStrategies(KentriosiPhotoContext context)
        {
            if (context.ContestStrategies.Any())
            {
                return;
            }

            for (int i = 0; i < 15; i++)
            {
                var strategy = new ContestStrategy()
                {
                    DeadlineStrategy = (DeadLine)Enum.Parse(typeof(DeadLine), this.randomGenerator.RandomNumber(1, 2).ToString()),
                    IsOpenForAllContesters = this.randomGenerator.RandomNumber(0, 100) % 2 == 0,
                    IsOpenForAllVoters = this.randomGenerator.RandomNumber(0, 100) % 2 == 0,
                    WinnersCount = this.randomGenerator.RandomNumber(0, 10)
                };
                context.ContestStrategies.AddOrUpdate(strategy);
            }

            context.SaveChanges();
        }

        private void SeedUsers(KentriosiPhotoContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                var user = new User
                {
                    UserName = this.randomGenerator.RandomString(6, 50),
                    Email = string.Format("{0}@{1}.com", this.randomGenerator.RandomString(4, 25), this.randomGenerator.RandomString(4, 35))
                };
                userManager.Create(user, "123456");
            }

            var adminUser = new User
            {
                UserName = "admin",
                Email = "admin@admin.com"
            };
            userManager.Create(adminUser, "123456");
            string adminRoleName = "Admin";
            if (!this.roleManager.RoleExists("Admin"))
            {
                var adminRole = new IdentityRole();
                adminRole.Name = adminRoleName;
                this.roleManager.Create(adminRole);
            }

            userManager.AddToRole(adminUser.Id, adminRoleName);
        }
    }
}