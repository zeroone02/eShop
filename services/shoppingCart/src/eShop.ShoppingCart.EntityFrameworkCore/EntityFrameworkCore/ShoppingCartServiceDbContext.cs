﻿using eShop.DDD.Entity;
using eShop.ShoppingCartService.Domain;
using Microsoft.EntityFrameworkCore;
namespace eShop.ShoppingCartService.EntityFrameworkCore;
public class ShoppingCartServiceDbContext : DbContext, IEfCoreDbContext
{
   public ShoppingCartServiceDbContext(DbContextOptions<ShoppingCartServiceDbContext> options )
        : base(options)
    {

    }
    public DbSet<CartHeader> CartHeaders { get; set; }
    public DbSet<CartDetails> CartDetails { get; set; }
   
}
