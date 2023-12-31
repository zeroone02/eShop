﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using eShop.CouponService.EntityFrameworkCore;

#nullable disable

namespace eShop.CouponService.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(CouponServiceDbContext))]
    [Migration("20230729093654_autoMigrationTest")]
    partial class autoMigrationTest
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("eShop.CouponService.Domain.Coupon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CouponCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("numeric");

                    b.Property<int>("MinAmount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Coupons");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a0f09697-1711-4bf5-b4d2-af154e68f2b2"),
                            CouponCode = "10OFF",
                            DiscountAmount = 10m,
                            MinAmount = 10
                        },
                        new
                        {
                            Id = new Guid("4729a394-e5f7-4e0b-adc7-0b65f9f7f48f"),
                            CouponCode = "20OFF",
                            DiscountAmount = 20m,
                            MinAmount = 40
                        },
                        new
                        {
                            Id = new Guid("6543bb3f-d5eb-4077-8ffa-8b3ce5de8080"),
                            CouponCode = "30OFF",
                            DiscountAmount = 30m,
                            MinAmount = 600
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
