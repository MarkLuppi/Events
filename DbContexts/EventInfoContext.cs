using Events.Entities;
using Microsoft.EntityFrameworkCore;

namespace Events.DbContexts
{
    public class EventInfoContext: DbContext
    {
        public DbSet<Events.Entities.Event> Events { get; set; } = null!;
        public DbSet<EventType> EventTypes { get; set; } = null!;

        public EventInfoContext(DbContextOptions<EventInfoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventType>()
           .HasData(
             new EventType("External")
             {
                 Id = 1,
                 Description = "External for community"
             },
             new EventType("Internal")
             {
                 Id = 2,
                 Description = "Internal for company"
             }
             );

            modelBuilder.Entity<Events.Entities.Event>()
                .HasData(
               new Events.Entities.Event("Event1")
               {
                   Id = 1,
                   Description = "Description for Event1.",
                   Notes = "Notes for Event1",
                   Date = DateTime.Parse("January 28, 2019"),
                   EventTypeId = 1
               },
               new Events.Entities.Event("Event2")
               {
                   Id = 2,
                   Description = "Description for Event2.",
                   Notes = "Notes for Event2",
                   Date = DateTime.Parse("February 3, 2019"),
                   EventTypeId = 2
               },
               new Events.Entities.Event("Event3")
               {
                   Id = 3,
                   Description = "Description for Event3.",
                   Notes = "Notes for Event3",
                   Date = DateTime.Parse("March 4, 2019"),
                   EventTypeId = 2
               }); ; ; ; ; ; ; ;

          
            base.OnModelCreating(modelBuilder);
        }







    }
}
