using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LandlordRatings.Data;

namespace LandlordRatings.Migrations
{
    [DbContext(typeof(LandlordDbContext))]
    partial class LandlordDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LandlordRatings.Models.LandlordModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("city");

                    b.Property<string>("firstName");

                    b.Property<string>("lastName");

                    b.Property<int?>("ratingID");

                    b.Property<string>("state");

                    b.Property<int>("type");

                    b.Property<string>("zipcode");

                    b.HasKey("ID");

                    b.HasIndex("ratingID");

                    b.ToTable("Landlords");
                });

            modelBuilder.Entity("LandlordRatings.Models.RatingModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("flexibilityScore");

                    b.Property<double>("overallScore");

                    b.Property<int>("personalityScore");

                    b.Property<int>("priceScore");

                    b.Property<int>("responsivenessScore");

                    b.HasKey("ID");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("LandlordRatings.Models.LandlordModel", b =>
                {
                    b.HasOne("LandlordRatings.Models.RatingModel", "rating")
                        .WithMany()
                        .HasForeignKey("ratingID");
                });
        }
    }
}
