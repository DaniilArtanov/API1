using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API1.Models;

public partial class TwoFunnyShoesContext : DbContext
{
    public TwoFunnyShoesContext()
    {
    }

    public TwoFunnyShoesContext(DbContextOptions<TwoFunnyShoesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BankCard> BankCards { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductsFromTheReceipt> ProductsFromTheReceipts { get; set; }

    public virtual DbSet<Receipt> Receipts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;uid=root;Database=two_funny_shoes");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BankCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("bank_cards");

            entity.HasIndex(e => e.IdUser, "id_users_user_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CardNumber)
                .HasMaxLength(25)
                .HasColumnName("card_number");
            entity.Property(e => e.Cvc).HasColumnName("cvc");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.ValidityPeriod).HasColumnName("validity_period");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.BankCards)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_users_user");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("brands");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameBrand)
                .HasMaxLength(30)
                .HasColumnName("name_brand");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.IdBrand, "id brand_idx");

            entity.HasIndex(e => e.IdCategory, "id_categories_category_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.IdBrand).HasColumnName("id_brand");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Size).HasColumnName("size");

            entity.HasOne(d => d.IdBrandNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdBrand)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_brands_brand");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_categories_category");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("product_categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameCategory)
                .HasMaxLength(45)
                .HasColumnName("name_category");
        });

        modelBuilder.Entity<ProductsFromTheReceipt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("products_from_the_receipts");

            entity.HasIndex(e => e.IdProduct, "id product_idx");

            entity.HasIndex(e => e.IdReceipt, "id_receipts_receipt_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.IdReceipt).HasColumnName("id_receipt");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Qualiniti).HasColumnName("qualiniti");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ProductsFromTheReceipts)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_products_product");

            entity.HasOne(d => d.IdReceiptNavigation).WithMany(p => p.ProductsFromTheReceipts)
                .HasForeignKey(d => d.IdReceipt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_receipts_receipt");
        });

        modelBuilder.Entity<Receipt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("receipts");

            entity.HasIndex(e => e.IdUser, "id_users_user_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.QualinitiEPoint).HasColumnName("qualiniti_e_point");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(101)
                .HasColumnName("address");
            entity.Property(e => e.Login)
                .HasMaxLength(45)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasColumnName("phone_number");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
