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
            if (!IsCampsiteInDb(context, "A1"))
            {
                var campsite = new Campsite()
                {
                    Id = Guid.NewGuid(),
                    Name = "A1"
                };
                context.Campsites.Add(campsite);
            }
            if (!IsCampsiteInDb(context, "A2"))
            {
                var campsite = new Campsite()
                {
                    Id = Guid.NewGuid(),
                    Name = "A2"
                };
                context.Campsites.Add(campsite);
            }
            if (!IsCampsiteInDb(context, "A3"))
            {
                var campsite = new Campsite()
                {
                    Id = Guid.NewGuid(),
                    Name = "A3"
                };
                context.Campsites.Add(campsite);
            }
            if (!IsCampsiteInDb(context, "B1"))
            {
                var campsite = new Campsite()
                {
                    Id = Guid.NewGuid(),
                    Name = "B1"
                };
                context.Campsites.Add(campsite);
            }
            if (!IsCampsiteInDb(context, "B2"))
            {
                var campsite = new Campsite()
                {
                    Id = Guid.NewGuid(),
                    Name = "B2"
                };
                context.Campsites.Add(campsite);
            }
            if (!IsCampsiteInDb(context, "B3"))
            {
                var campsite = new Campsite()
                {
                    Id = Guid.NewGuid(),
                    Name = "B3"
                };
                context.Campsites.Add(campsite);
            }
            if (!IsCampsiteInDb(context, "C1"))
            {
                var campsite = new Campsite()
                {
                    Id = Guid.NewGuid(),
                    Name = "C1"
                };
                context.Campsites.Add(campsite);
            }
            if (!IsCampsiteInDb(context, "C2"))
            {
                var campsite = new Campsite()
                {
                    Id = Guid.NewGuid(),
                    Name = "C2"
                };
                context.Campsites.Add(campsite);
            }
            if (!IsCampsiteInDb(context, "C3"))
            {
                var campsite = new Campsite()
                {
                    Id = Guid.NewGuid(),
                    Name = "C3"
                };
                context.Campsites.Add(campsite);
            }


            var reservation = new Reservation()
            {
                Id = Guid.NewGuid(),
                Campsite = context.Campsites.Where(s => s.Name == "ebc8b029 - d596 - 413d - 8510 - 452511ae1756").FirstOrDefault(),
                ArrivalDate = DateTime.Parse("12/05/2016"),
                DepartueDate = DateTime.Parse("12/07/2016")

            };
        
            context.Reservations.Add(reservation);

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
