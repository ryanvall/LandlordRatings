using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LandlordRatings.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    flexibilityScore = table.Column<int>(nullable: false),
                    overallScore = table.Column<double>(nullable: false),
                    personalityScore = table.Column<int>(nullable: false),
                    priceScore = table.Column<int>(nullable: false),
                    responsivenessScore = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Landlords",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    city = table.Column<string>(nullable: true),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    ratingID = table.Column<int>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    type = table.Column<int>(nullable: false),
                    zipcode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landlords", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Landlords_Ratings_ratingID",
                        column: x => x.ratingID,
                        principalTable: "Ratings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Landlords_ratingID",
                table: "Landlords",
                column: "ratingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Landlords");

            migrationBuilder.DropTable(
                name: "Ratings");
        }
    }
}
