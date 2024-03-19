using System;
using System.Collections.Generic;
using CustomerService.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Persistance.Context;

public partial class CustomerContext : DbContext
{
    public CustomerContext()
    {
    }

    public CustomerContext(DbContextOptions<CustomerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=CustomerDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__Addresse__091C2A1BD13705DE");

            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserId");
            entity.Property(e => e.State)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Street)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Addresses__Custo__440B1D61");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__A4AE64B8865C598F");

            entity.HasIndex(e => e.Email, "UQ__User__A9D10534F6C40FCE").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79AE117C38C8");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.CustomerId).HasColumnName("UserId");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reviews__Custome__412EB0B6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
