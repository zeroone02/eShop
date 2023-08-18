using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eShop.ProductService.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class addProductAndSeedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CategoryName = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("54b68877-92f4-45a0-8f4b-7bb969843a92"), "Appetizer", "Each cabin has a large sail, so that the vehicles do not have room for visitors.<br/> Gas box coupons, biggest vikings. Upgrade your courses at a comfortable price.", "https://placehold.co/603x403", "Samosa", 150.0 },
                    { new Guid("815f1b71-7d4d-4816-8bdd-d40f81757ffc"), "Entree", " Smoking or leakage and large, shooting vehicles may not be leakage.<br/> Spotlight scores, not the biggest vikings. Please upgrade the course cost.", "https://placehold.co/600x400", "Pav Bhaji", 2500.0 },
                    { new Guid("bfb587bd-d807-44dc-9867-e7179c6b8e1f"), "Dessert", "Smoking or leakage and large, shooting vehicles may not be leakage.<br/> Spotlight scores, not the biggest vikings. Please upgrade the course cost.", "https://placehold.co/601x401", "Sweet Pie", 250.0 },
                    { new Guid("c997f0a0-07d1-4c2a-b9ac-08aa6ccda2e0"), "Appetizer", "Smoking or leakage and large, shooting vehicles may not be leakage.<br/> Spotlight scores, not the biggest vikings. Please upgrade the course cost.", "https://placehold.co/602x402", "Paneer Tikka", 200.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
