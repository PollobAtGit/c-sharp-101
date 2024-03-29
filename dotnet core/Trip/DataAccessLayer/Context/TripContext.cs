﻿using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context
{
    public class TripContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }

        public TripContext(DbContextOptions<TripContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityTypeBuilder = modelBuilder.Entity<Trip>();

            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.ToTable("trip_dotnet_core");
            entityTypeBuilder.Property(x => x.PickupPoint).HasColumnName("pickup_point");
        }
    }
}
