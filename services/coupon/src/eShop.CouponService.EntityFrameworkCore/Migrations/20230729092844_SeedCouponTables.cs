using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eShop.CouponService.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class SeedCouponTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "CouponCode", "DiscountAmount", "MinAmount" },
                values: new object[,]
                {
                    { new Guid("704a9dc9-fbfb-4b1a-bf73-7ed6bba0ed02"), "20OFF", 20m, 40 },
                    { new Guid("e27a93f5-47e7-4578-9d96-6a8b6691e77b"), "10OFF", 10m, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: new Guid("704a9dc9-fbfb-4b1a-bf73-7ed6bba0ed02"));

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: new Guid("e27a93f5-47e7-4578-9d96-6a8b6691e77b"));
        }
    }
}
