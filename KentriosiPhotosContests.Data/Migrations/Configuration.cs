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

    public sealed class Configuration : DbMigrationsConfiguration<KentriosiPhotoContext>
    {
        private IRandomGenerator randomGenerator;
        private UserManager<User> userManager;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(KentriosiPhotoContext context)
        {
            this.userManager = new UserManager<User>(new UserStore<User>(context));

            this.SeedPrizes(context);
            this.SeedContestStrategies(context);
            this.SeedUsers(context);
            this.SeedContests(context);
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
                    Description = this.randomGenerator.RandomString(2, 500),
                    Title = this.randomGenerator.RandomString(2, 500),
                    StatusDescription = status == ContestStatus.Closed ? this.randomGenerator.RandomString(0, 250) : string.Empty,
                    IsDeleted = this.randomGenerator.RandomNumber(0, 100) % 6 == 0,
                    Owner = users[this.randomGenerator.RandomNumber(0, users.Count - 1)],
                    //Images
                };
                context.Contests.Add(contest);
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
                context.Prizes.Add(prize);
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
                context.ContestStrategies.Add(strategy);
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

            context.SaveChanges();
        }
    }
}
