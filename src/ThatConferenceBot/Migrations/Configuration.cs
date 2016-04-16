namespace MyFirstBotApplication.Migrations
{
    using Domain;
    using Domain.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyFirstBotApplication.Domain.ThatConferenceBotDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
            this.ContextKey = "ThatConferenceBotDbContext";
            this.MigrationsDirectory = @"ThatConferenceBotDbMigrations";
          
        }

        protected override void Seed(MyFirstBotApplication.Domain.ThatConferenceBotDbContext context)
        {
            if (!IsCampsiteInDb(context, "IsStoreEnabled"))
            {
                var campsite1 = new Campsite()
                {
                    Id = Guid.NewGuid(),
                    Name = "A1"
                };
                context.Campsites.Add(campsite1);
            }
            if (!IsCampsiteInDb(context, "IsStoreEnabled"))
            {
                var campsite1 = new Campsite()
                {
                    Id = Guid.NewGuid(),
                    Name = "A2"
                };
                context.Campsites.Add(campsite1);
            }
            if (!IsCampsiteInDb(context, "IsStoreEnabled"))
            {
                var campsite1 = new Campsite()
                {
                    Id = Guid.NewGuid(),
                    Name = "A3"
                };
                context.Campsites.Add(campsite1);
            }
            if (!IsCampsiteInDb(context, "IsStoreEnabled"))
            {
                var campsite1 = new Campsite()
                {
                    Id = Guid.NewGuid(),
                    Name = "B1"
                };
                context.Campsites.Add(campsite1);
            }
            if (!IsCampsiteInDb(context, "IsStoreEnabled"))
            {
                var campsite1 = new Campsite()
                {
                    Id = Guid.NewGuid(),
                    Name = "B2"
                };
                context.Campsites.Add(campsite1);
            }
            if (!IsCampsiteInDb(context, "IsStoreEnabled"))
            {
                var campsite1 = new Campsite()
                {
                    Id = Guid.NewGuid(),
                    Name = "B2"
                };
                context.Campsites.Add(campsite1);
            }
            if (!IsCampsiteInDb(context, "IsStoreEnabled"))
            {
                var campsite1 = new Campsite()
                {
                    Id = Guid.NewGuid(),
                    Name = "B3"
                };
                context.Campsites.Add(campsite1);
            }

            context.SaveChanges();
        }

        private bool IsCampsiteInDb(ThatConferenceBotDbContext context, string value)
        {
            Campsite campsite = context.Campsites.Where(s => s.Name == value).FirstOrDefault();
            if (campsite == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
