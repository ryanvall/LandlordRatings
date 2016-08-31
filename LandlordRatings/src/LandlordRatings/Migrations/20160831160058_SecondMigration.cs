using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LandlordRatings.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "firstName",
                table: "Landlords");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "Landlords");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Landlords",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "Landlords");

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "Landlords",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "Landlords",
                nullable: true);
        }
    }
}
