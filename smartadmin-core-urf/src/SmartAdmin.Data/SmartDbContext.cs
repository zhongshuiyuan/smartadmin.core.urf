﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SmartAdmin.Data.Models;

namespace SmartAdmin.Data.Models
{
  public partial class SmartDbContext : DbContext
  {
    public SmartDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Category>  Categories { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseSqlServer(@"Server=(LocalDb)\\MSSQLLocalDB;Database=SmartDb;Trusted_Connection=True;");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Company>(entity =>
      {
        entity.HasIndex(e => e.Name)
                      .IsUnique()
                      .HasFilter(null);
        entity.HasIndex(e => e.Code)
                      .IsUnique()
                      .HasFilter("[Code] IS NOT NULL");
      });
      modelBuilder.Entity<Category>(entity =>
      {
        entity.HasIndex(e => e.Name)
                      .IsUnique()
                      .HasFilter(null);
        
      });
    }
  }
}
