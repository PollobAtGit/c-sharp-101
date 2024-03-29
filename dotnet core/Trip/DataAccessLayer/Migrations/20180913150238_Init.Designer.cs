﻿// <auto-generated />
using DataAccessLayer.Context;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(TripContext))]
    [Migration("20180913150238_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065");

            modelBuilder.Entity("Trip.Web.Controllers.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Destination");

                    b.Property<string>("PickupPoint")
                        .IsRequired()
                        .HasColumnName("pickup_point");

                    b.HasKey("Id");

                    b.ToTable("trip_dotnet_core");
                });
#pragma warning restore 612, 618
        }
    }
}
