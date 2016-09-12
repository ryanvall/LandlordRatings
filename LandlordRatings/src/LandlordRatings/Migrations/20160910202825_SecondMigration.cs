using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LandlordRatings.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Landlords_LandlordModelID",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_LandlordModelID",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "LandlordModelID",
                table: "Ratings");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_LandlordID",
                table: "Ratings",
                column: "LandlordID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Landlords_LandlordID",
                table: "Ratings",
                column: "LandlordID",
                principalTable: "Landlords",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Landlords_LandlordID",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_LandlordID",
                table: "Ratings");

            migrationBuilder.AddColumn<int>(
                name: "LandlordModelID",
                table: "Ratings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_LandlordModelID",
                table: "Ratings",
                column: "LandlordModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Landlords_LandlordModelID",
                table: "Ratings",
                column: "LandlordModelID",
                principalTable: "Landlords",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
