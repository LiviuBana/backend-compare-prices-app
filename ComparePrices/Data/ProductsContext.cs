using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Products.Models;

namespace Products.Data;

public partial class ProductsContext : DbContext
{
    public ProductsContext(DbContextOptions<ProductsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Itemstabletest> Itemstabletests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Itemstabletest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("itemstabletest");

            entity.Property(e => e.Id)
                .HasColumnType("mediumint")
                .HasColumnName("id");
            entity.Property(e => e.Availability)
                .HasColumnType("text")
                .HasColumnName("availability");
            entity.Property(e => e.Model)
                .HasColumnType("text")
                .HasColumnName("model");
            entity.Property(e => e.Price)
                .HasColumnType("text")
                .HasColumnName("price");
            entity.Property(e => e.Producer)
                .HasColumnType("text")
                .HasColumnName("producer");
            entity.Property(e => e.Site)
                .HasColumnType("text")
                .HasColumnName("site");
            entity.Property(e => e.Title)
                .HasColumnType("text")
                .HasColumnName("title");
            entity.Property(e => e.Url)
                .HasColumnType("text")
                .HasColumnName("url");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
