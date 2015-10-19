namespace KentriosiPhotoContest.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<KentriosiPhotoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;

        }

        protected override void Seed(KentriosiPhotoContext context)
        {
           
        }
    }
}
