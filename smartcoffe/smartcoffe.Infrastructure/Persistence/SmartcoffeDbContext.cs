using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using  smartcoffe.Domain.Entities;


namespace smartcoffe.Infrastructure.Persistence;

public partial class SmartcoffeDbContext : DbContext
{
    public SmartcoffeDbContext()
    {
    }

    public SmartcoffeDbContext(DbContextOptions<SmartcoffeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cafe> Caves { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<PurchaseHistory> PurchaseHistories { get; set; }

    public virtual DbSet<Shopping> Shoppings { get; set; }

    public virtual DbSet<ShoppingDetail> ShoppingDetails { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=cafe_shopping;Username=postgres;Password=root123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cafe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cafe_pkey");

            entity.ToTable("cafe");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Company)
                .HasMaxLength(255)
                .HasColumnName("company");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("inventory_pkey");

            entity.ToTable("inventory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCafe).HasColumnName("id_cafe");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.IdSupplier).HasColumnName("id_supplier");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");

            entity.HasOne(d => d.IdCafeNavigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.IdCafe)
                .HasConstraintName("inventory_id_cafe_fkey");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("inventory_id_product_fkey");

            entity.HasOne(d => d.IdSupplierNavigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.IdSupplier)
                .HasConstraintName("inventory_id_supplier_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_pkey");

            entity.ToTable("product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Expirationdate).HasColumnName("expirationdate");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.IdPromotion).HasColumnName("id_promotion");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.Productname)
                .HasMaxLength(255)
                .HasColumnName("productname");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("product_id_category_fkey");

            entity.HasOne(d => d.IdPromotionNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdPromotion)
                .HasConstraintName("product_id_promotion_fkey");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("promotion_pkey");

            entity.ToTable("promotion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnName("amount");
            entity.Property(e => e.Enddate).HasColumnName("enddate");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Startdate).HasColumnName("startdate");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
        });

        modelBuilder.Entity<PurchaseHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("purchase_history_pkey");

            entity.ToTable("purchase_history");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdPayment)
                .HasMaxLength(255)
                .HasColumnName("id_payment");
            entity.Property(e => e.Idshopping).HasColumnName("idshopping");
            entity.Property(e => e.Iduser).HasColumnName("iduser");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");

            entity.HasOne(d => d.IdshoppingNavigation).WithMany(p => p.PurchaseHistories)
                .HasForeignKey(d => d.Idshopping)
                .HasConstraintName("purchase_history_idshopping_fkey");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.PurchaseHistories)
                .HasForeignKey(d => d.Iduser)
                .HasConstraintName("purchase_history_iduser_fkey");
        });

        modelBuilder.Entity<Shopping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("shopping_pkey");

            entity.ToTable("shopping");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.Discount)
                .HasPrecision(10, 2)
                .HasColumnName("discount");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Promotion)
                .HasMaxLength(255)
                .HasColumnName("promotion");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");
            entity.Property(e => e.Total)
                .HasPrecision(10, 2)
                .HasColumnName("total");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Shoppings)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("shopping_id_user_fkey");
        });

        modelBuilder.Entity<ShoppingDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("shopping_detail_pkey");

            entity.ToTable("shopping_detail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnName("amount");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.IdShopping).HasColumnName("id_shopping");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ShoppingDetails)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("shopping_detail_id_product_fkey");

            entity.HasOne(d => d.IdShoppingNavigation).WithMany(p => p.ShoppingDetails)
                .HasForeignKey(d => d.IdShopping)
                .HasConstraintName("shopping_detail_id_shopping_fkey");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("supplier_pkey");

            entity.ToTable("supplier");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(20)
                .HasColumnName("phonenumber");
            entity.Property(e => e.Rrole)
                .HasMaxLength(50)
                .HasColumnName("rrole");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
