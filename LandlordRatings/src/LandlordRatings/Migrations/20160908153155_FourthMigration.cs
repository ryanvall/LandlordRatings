using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LandlordRatings.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OverallScore",
                table: "Ratings");

            migrationBuilder.AddColumn<int>(
                name: "LandlordID",
                table: "Ratings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Zipcode",
                table: "Landlords",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Landlords",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Landlords",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Landlords",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LandlordID",
                table: "Ratings");

            migrationBuilder.AddColumn<double>(
                name: "OverallScore",
                table: "Ratings",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Zipcode",
                table: "Landlords",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Landlords",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Landlords",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Landlords",
                nullable: true);
        }
    }
}
