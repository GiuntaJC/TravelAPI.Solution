﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelAPI.Models;

namespace TravelAPI.Migrations
{
    [DbContext(typeof(TravelAPIContext))]
    partial class TravelAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TravelAPI.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("TravelAPI.Models.LocationReview", b =>
                {
                    b.Property<int>("LocationReviewId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LocationId");

                    b.Property<int>("ReviewId");

                    b.HasKey("LocationReviewId");

                    b.HasIndex("LocationId");

                    b.HasIndex("ReviewId");

                    b.ToTable("LocationReview");
                });

            modelBuilder.Entity("TravelAPI.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Rating");

                    b.HasKey("ReviewId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("TravelAPI.Models.LocationReview", b =>
                {
                    b.HasOne("TravelAPI.Models.Location", "Location")
                        .WithMany("Reviews")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TravelAPI.Models.Review", "Review")
                        .WithMany()
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
