using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CA_EcommerceDB.Models;

public partial class ECommerceDbContext : DbContext
{
    public ECommerceDbContext()
    {
    }

    public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-I9V1GOS\\SQLEXPRESS;database=eCommerce_DB;uid=sa;pwd=Tugce8417058;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A2B7F5B6742");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryDefinition).HasMaxLength(200);
            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B8CAC8CEAD");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CustomerAddress).HasMaxLength(200);
            entity.Property(e => e.CustomerEmailAddress).HasMaxLength(100);
            entity.Property(e => e.CustomerFirstName)
                .HasMaxLength(50)
                .HasColumnName("customerFirstName");
            entity.Property(e => e.CustomerLastName).HasMaxLength(50);
            entity.Property(e => e.CustomerPhoneNumber).HasMaxLength(11);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoicesId).HasName("PK__Invoices__88AF5717CE632770");

            entity.Property(e => e.InvoicesId)
                .ValueGeneratedNever()
                .HasColumnName("InvoicesID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.InvoiceCreationDate).HasColumnType("datetime");
            entity.Property(e => e.InvoiceNumber).HasMaxLength(50);

            entity.HasOne(d => d.Customer).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invoices__Custom__47DBAE45");

            entity.HasOne(d => d.Invoices).WithOne(p => p.Invoice)
                .HasForeignKey<Invoice>(d => d.InvoicesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invoices__Invoic__46E78A0C");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAFD76EFA43");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.OrderCreationDate).HasColumnType("datetime");
            entity.Property(e => e.OrderDeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__Customer__4316F928");

            entity.HasOne(d => d.Payment).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__PaymentI__440B1D61");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A5807301F51");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.PaymentType).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6EDCAAA670D");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ProductColor).HasMaxLength(20);
            entity.Property(e => e.ProductDefinition).HasMaxLength(1000);
            entity.Property(e => e.ProductName).HasMaxLength(200);
            entity.Property(e => e.ProductSize).HasMaxLength(10);
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__Catego__3B75D760");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__Suppli__3C69FB99");

            entity.HasMany(d => d.Orders).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductOrder",
                    r => r.HasOne<Order>().WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ProductOr__Order__4BAC3F29"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ProductOr__Produ__4AB81AF0"),
                    j =>
                    {
                        j.HasKey("ProductId", "OrderId").HasName("PK__ProductO__5835C357A5073158");
                        j.ToTable("ProductOrder");
                        j.IndexerProperty<int>("ProductId").HasColumnName("ProductID");
                        j.IndexerProperty<int>("OrderId").HasColumnName("OrderID");
                    });

            entity.HasMany(d => d.Stores).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductStore",
                    r => r.HasOne<Store>().WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ProductSt__Store__5165187F"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ProductSt__Produ__5070F446"),
                    j =>
                    {
                        j.HasKey("ProductId", "StoreId").HasName("PK__ProductS__B7B4E9E35B3BF6B2");
                        j.ToTable("ProductStore");
                        j.IndexerProperty<int>("ProductId").HasColumnName("ProductID");
                        j.IndexerProperty<int>("StoreId").HasColumnName("StoreID");
                    });
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PK__Stores__3B82F0E1EC2D47FE");

            entity.Property(e => e.StoreId).HasColumnName("StoreID");
            entity.Property(e => e.StoreAddress).HasMaxLength(200);
            entity.Property(e => e.StoreName).HasMaxLength(200);
            entity.Property(e => e.StorePhoneNumber).HasMaxLength(11);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__4BE6669457CC5AFB");

            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.SupplierAddress).HasMaxLength(200);
            entity.Property(e => e.SupplierName).HasMaxLength(200);
            entity.Property(e => e.SupplierPhoneNumber).HasMaxLength(11);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
