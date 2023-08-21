using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eShop.CouponService.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class couponUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: new Guid("0413f510-2336-4f22-b2fb-059eafc7f559"));

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: new Guid("78dc2c06-15c5-4e15-bbd8-5f352d397ea9"));

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: new Guid("792bedc4-6eb8-4366-a4c7-b7589ad3980e"));

            migrationBuilder.AlterColumn<double>(
                name: "DiscountAmount",
                table: "Coupons",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "CouponCode", "DiscountAmount", "MinAmount" },
                values: new object[,]
                {
                    { new Guid("96de9400-b69d-4773-b63f-b579595bae74"), "20OFF", 20.0, 40 },
                    { new Guid("bf5747d3-288a-46f4-839d-30d1154f4aa3"), "30OFF", 30.0, 600 },
                    { new Guid("d3543bf6-1e5a-44ca-b5bc-13f8b4b494d4"), "10OFF", 10.0, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: new Guid("96de9400-b69d-4773-b63f-b579595bae74"));

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: new Guid("bf5747d3-288a-46f4-839d-30d1154f4aa3"));

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: new Guid("d3543bf6-1e5a-44ca-b5bc-13f8b4b494d4"));

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountAmount",
                table: "Coupons",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "CouponCode", "DiscountAmount", "MinAmount" },
                values: new object[,]
                {
                    { new Guid("0413f510-2336-4f22-b2fb-059eafc7f559"), "30OFF", 30m, 600 },
                    { new Guid("78dc2c06-15c5-4e15-bbd8-5f352d397ea9"), "10OFF", 10m, 10 },
                    { new Guid("792bedc4-6eb8-4366-a4c7-b7589ad3980e"), "20OFF", 20m, 40 }
                });
        }
    }
}
