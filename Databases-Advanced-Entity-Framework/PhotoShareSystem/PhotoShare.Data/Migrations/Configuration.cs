namespace PhotoShare.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using PhotoShare.Data;

    internal class Configuration : DbMigrationsConfiguration<PhotoShareContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PhotoShareContext context)
        {
        }
    }
}
