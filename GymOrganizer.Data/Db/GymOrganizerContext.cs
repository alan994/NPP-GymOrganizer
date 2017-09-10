using GymOrganizer.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymOrganizer.Data.Db
{
    public class GymOrganizerContext : DbContext
    {
        public GymOrganizerContext(DbContextOptions<GymOrganizerContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }


            modelBuilder.Entity<User>().Property(x => x.Id).HasDefaultValueSql("newsequentialid()");
            modelBuilder.Entity<Schedule>().Property(x => x.Id).HasDefaultValueSql("newsequentialid()");
        }
    }
}
