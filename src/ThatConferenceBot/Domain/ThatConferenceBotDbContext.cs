using MyFirstBotApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyFirstBotApplication.Domain
{
    public class ThatConferenceBotDbContext : DbContext
    {

        public ThatConferenceBotDbContext() : base("ThatConferenceBot_db")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ThatConferenceBotDbContext>( ));
        }

        public DbSet<Campsite> Campsites { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
