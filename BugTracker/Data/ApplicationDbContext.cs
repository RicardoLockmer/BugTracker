using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BugTracker.Models;

namespace BugTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BugTracker.Models.Tickets> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tickets>()
                .HasData(
                new Tickets
                {
                    ID = 999,
                    TicketName = "Word Count not Working",
                    TicketCategory = "Bug",
                    TicketCreator = "John Dow",
                    TicketActivity = 1,
                    TicketOwner = "Jane Doe",
                    TicketDecription = "the word counting for the max limit of characters on each field does not count properly"
                },
                new Tickets
                {
                    ID = 998,
                    TicketName = "Drag me to another column",
                    TicketCategory = "Feature",
                    TicketCreator = "John Doe",
                    TicketActivity = 2,
                    TicketOwner = "Jane Doe",
                    TicketDecription = "Move around the columns and refresh to view that it saved changes with AJAX."
                }
                );
        }
    }
}
