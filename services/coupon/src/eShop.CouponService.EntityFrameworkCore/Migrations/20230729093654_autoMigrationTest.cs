using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eShop.CouponService.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class autoMigrationTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: new Guid("704a9dc9-fbfb-4b1a-bf73-7ed6bba0ed02"));

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: new Guid("e27a93f5-47e7-4578-9d96-6a8b6691e77b"));

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "CouponCode", "DiscountAmount", "MinAmount" },
                values: new object[,]
                {
                    { new Guid("4729a394-e5f7-4e0b-adc7-0b65f9f7f48f"), "20OFF", 20m, 40 },
                    { new Guid("6543bb3f-d5eb-4077-8ffa-8b3ce5de8080"), "30OFF", 30m, 600 },
                    { new Guid("a0f09697-1711-4bf5-b4d2-af154e68f2b2"), "10OFF", 10m, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: new Guid("4729a394-e5f7-4e0b-adc7-0b65f9f7f48f"));

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: new Guid("6543bb3f-d5eb-4077-8ffa-8b3ce5de8080"));

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: new Guid("a0f09697-1711-4bf5-b4d2-af154e68f2b2"));

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "CouponCode", "DiscountAmount", "MinAmount" },
                values: new object[,]
                {
                    { new Guid("704a9dc9-fbfb-4b1a-bf73-7ed6bba0ed02"), "20OFF", 20m, 40 },
                    { new Guid("e27a93f5-47e7-4578-9d96-6a8b6691e77b"), "10OFF", 10m, 10 }
                });
        }
    }
}
