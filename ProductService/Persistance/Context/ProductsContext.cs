using System;
using System.Collections.Generic;
using ProductService.Model;
using Microsoft.EntityFrameworkCore;

namespace ProductService.Persistance.Context;

public partial class ProductsContext : DbContext
{
    public ProductsContext()
    {
    }

    public ProductsContext(DbContextOptions<ProductsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Colour> Colours { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Productt> Productts { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionString:ProductDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A2BCDE2276F");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Colour>(entity =>
        {
            entity.HasKey(e => e.ColorId).HasName("PK__Colours__8DA7676DE4B00AD5");

            entity.Property(e => e.ColorId).HasColumnName("ColorID");
            entity.Property(e => e.ColorName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Productt>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Productt__B40CC6ED67256A18");

            entity.ToTable("Productt");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ColorId).HasColumnName("ColorID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl)
                .IsUnicode(false)
                .HasColumnName("ImageURL");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SizeId).HasColumnName("SizeID");

            entity.HasOne(d => d.Category).WithMany(p => p.Productts)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productt__Catego__0C85DE4D");

            entity.HasOne(d => d.Color).WithMany(p => p.Productts)
                .HasForeignKey(d => d.ColorId)
                .HasConstraintName("FK__Productt__ColorI__0D7A0286");

            entity.HasOne(d => d.Size).WithMany(p => p.Productts)
                .HasForeignKey(d => d.SizeId)
                .HasConstraintName("FK__Productt__SizeID__0B91BA14");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.SizeId).HasName("PK__Size__83BD095A2FFAF157");

            entity.ToTable("Size");

            entity.Property(e => e.SizeId).HasColumnName("SizeID");
            entity.Property(e => e.SizeName)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
