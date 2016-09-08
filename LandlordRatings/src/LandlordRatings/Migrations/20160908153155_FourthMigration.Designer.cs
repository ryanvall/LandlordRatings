﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LandlordRatings.Data;

namespace LandlordRatings.Migrations
{
    [DbContext(typeof(LandlordDbContext))]
    [Migration("20160908153155_FourthMigration")]
    partial class FourthMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LandlordRatings.Models.LandlordModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<int>("Type");

                    b.Property<string>("Zipcode")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Landlords");
                });

            modelBuilder.Entity("LandlordRatings.Models.RatingModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments")
                        .HasAnnotation("MaxLength", 300);

                    b.Property<int>("FlexibilityScore");

                    b.Property<int>("LandlordID");

                    b.Property<int?>("LandlordModelID");

                    b.Property<int>("PersonalityScore");

                    b.Property<int>("PriceScore");

                    b.Property<int>("ResponsivenessScore");

                    b.HasKey("ID");

                    b.HasIndex("LandlordModelID");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("LandlordRatings.Models.RatingModel", b =>
                {
                    b.HasOne("LandlordRatings.Models.LandlordModel")
                        .WithMany("Ratings")
                        .HasForeignKey("LandlordModelID");
                });
        }
    }
}
