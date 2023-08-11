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
    [Migration("20230729092844_SeedCouponTables")]
    partial class SeedCouponTables
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
                            Id = new Guid("e27a93f5-47e7-4578-9d96-6a8b6691e77b"),
                            CouponCode = "10OFF",
                            DiscountAmount = 10m,
                            MinAmount = 10
                        },
                        new
                        {
                            Id = new Guid("704a9dc9-fbfb-4b1a-bf73-7ed6bba0ed02"),
                            CouponCode = "20OFF",
                            DiscountAmount = 20m,
                            MinAmount = 40
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
