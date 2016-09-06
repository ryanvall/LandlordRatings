using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LandlordRatings.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Landlords_Ratings_ratingID",
                table: "Landlords");

            migrationBuilder.DropIndex(
                name: "IX_Landlords_ratingID",
                table: "Landlords");

            migrationBuilder.DropColumn(
                name: "ratingID",
                table: "Landlords");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Ratings",
                maxLength: 300,
                nullable: true);

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

            migrationBuilder.RenameColumn(
                name: "responsivenessScore",
                table: "Ratings",
                newName: "ResponsivenessScore");

            migrationBuilder.RenameColumn(
                name: "priceScore",
                table: "Ratings",
                newName: "PriceScore");

            migrationBuilder.RenameColumn(
                name: "personalityScore",
                table: "Ratings",
                newName: "PersonalityScore");

            migrationBuilder.RenameColumn(
                name: "overallScore",
                table: "Ratings",
                newName: "OverallScore");

            migrationBuilder.RenameColumn(
                name: "flexibilityScore",
                table: "Ratings",
                newName: "FlexibilityScore");

            migrationBuilder.RenameColumn(
                name: "zipcode",
                table: "Landlords",
                newName: "Zipcode");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Landlords",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "Landlords",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Landlords",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Landlords",
                newName: "City");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Landlords_LandlordModelID",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_LandlordModelID",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "LandlordModelID",
                table: "Ratings");

            migrationBuilder.AddColumn<int>(
                name: "ratingID",
                table: "Landlords",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Landlords_ratingID",
                table: "Landlords",
                column: "ratingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Landlords_Ratings_ratingID",
                table: "Landlords",
                column: "ratingID",
                principalTable: "Ratings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameColumn(
                name: "ResponsivenessScore",
                table: "Ratings",
                newName: "responsivenessScore");

            migrationBuilder.RenameColumn(
                name: "PriceScore",
                table: "Ratings",
                newName: "priceScore");

            migrationBuilder.RenameColumn(
                name: "PersonalityScore",
                table: "Ratings",
                newName: "personalityScore");

            migrationBuilder.RenameColumn(
                name: "OverallScore",
                table: "Ratings",
                newName: "overallScore");

            migrationBuilder.RenameColumn(
                name: "FlexibilityScore",
                table: "Ratings",
                newName: "flexibilityScore");

            migrationBuilder.RenameColumn(
                name: "Zipcode",
                table: "Landlords",
                newName: "zipcode");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Landlords",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Landlords",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Landlords",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Landlords",
                newName: "city");
        }
    }
}
