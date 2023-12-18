using System;
using System.Collections.Generic;
using InternetStore.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetStore.Context;

public partial class InternetStoreContext : DbContext
{
    public InternetStoreContext()
    {
    }

    public InternetStoreContext(DbContextOptions<InternetStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adress> Adresses { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<DeliveryStatus> DeliveryStatuses { get; set; }

    public virtual DbSet<DeliveryStatusHistory> DeliveryStatusHistories { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Option> Options { get; set; }

    public virtual DbSet<OptionPack> OptionPacks { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<PaymentStatus> PaymentStatuses { get; set; }

    public virtual DbSet<PaymentStatusHistory> PaymentStatusHistories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductInfo> ProductInfos { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:InternetStore");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adress>(entity =>
        {
            entity.HasKey(e => e.AdressId)
                .HasName("PK_ADRESS")
                .IsClustered(false);

            entity.ToTable("Adress");

            entity.HasIndex(e => e.CityId, "City has people_FK");

            entity.HasIndex(e => e.UserId, "User has adresses_FK");

            entity.Property(e => e.AdressId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Adress_id");
            entity.Property(e => e.AdressField1)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Adress_field1");
            entity.Property(e => e.AdressField2)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Adress_field2");
            entity.Property(e => e.AdressName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Adress_name");
            entity.Property(e => e.AdressPhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Adress_phone");
            entity.Property(e => e.AdressPostalCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Adress_postalCode");
            entity.Property(e => e.AdressSurname)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Adress_surname");
            entity.Property(e => e.CityId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("City_id");
            entity.Property(e => e.UserId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("User_id");

            entity.HasOne(d => d.City).WithMany(p => p.Adresses)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_ADRESS_CITY HAS _CITY");

            entity.HasOne(d => d.User).WithMany(p => p.Adresses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ADRESS_USER HAS _USER");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId)
                .HasName("PK_CART")
                .IsClustered(false);

            entity.ToTable("Cart");

            entity.HasIndex(e => e.UserId, "Buying_FK");

            entity.Property(e => e.CartId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Cart_id");
            entity.Property(e => e.UserId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("User_id");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CART_BUYING_USER");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId)
                .HasName("PK_CATEGORY")
                .IsClustered(false);

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Category_name");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId)
                .HasName("PK_CITY")
                .IsClustered(false);

            entity.ToTable("City");

            entity.HasIndex(e => e.StateId, "State has cities_FK");

            entity.Property(e => e.CityId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("City_id");
            entity.Property(e => e.CityName)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("City_name");
            entity.Property(e => e.StateId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("State_id");

            entity.HasOne(d => d.State).WithMany(p => p.Cities)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK_CITY_STATE HAS_STATE");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId)
                .HasName("PK_COUNTRY")
                .IsClustered(false);

            entity.ToTable("Country");

            entity.Property(e => e.CountryId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Country_id");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("Country_code");
            entity.Property(e => e.CountryName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Country_name");
        });

        modelBuilder.Entity<DeliveryStatus>(entity =>
        {
            entity.HasKey(e => e.DeliveryStatusId)
                .HasName("PK_DELIVERYSTATUS")
                .IsClustered(false);

            entity.ToTable("DeliveryStatus");

            entity.Property(e => e.DeliveryStatusId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("DeliveryStatus_id");
            entity.Property(e => e.DeliveryStatusName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DeliveryStatus_name");
        });

        modelBuilder.Entity<DeliveryStatusHistory>(entity =>
        {
            entity.HasKey(e => e.DeliveryStatusHistoryId)
                .HasName("PK_DELIVERYSTATUSHISTORY")
                .IsClustered(false);

            entity.ToTable("DeliveryStatusHistory");

            entity.HasIndex(e => e.DeliveryStatusId, "Delivery history has status_FK");

            entity.HasIndex(e => e.OrderId, "Order has delivery history_FK");

            entity.Property(e => e.DeliveryStatusHistoryId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("DeliveryStatusHistory_id");
            entity.Property(e => e.DeliveryStatusHistoryDate)
                .HasColumnType("datetime")
                .HasColumnName("DeliveryStatusHistory_date");
            entity.Property(e => e.DeliveryStatusId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("DeliveryStatus_id");
            entity.Property(e => e.OrderId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Order_id");

            entity.HasOne(d => d.DeliveryStatus).WithMany(p => p.DeliveryStatusHistories)
                .HasForeignKey(d => d.DeliveryStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DELIVERY_DELIVERY _DELIVERY");

            entity.HasOne(d => d.Order).WithMany(p => p.DeliveryStatusHistories)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DELIVERY_ORDER HAS_ORDER");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId)
                .HasName("PK_ITEM")
                .IsClustered(false);

            entity.ToTable("Item");

            entity.HasIndex(e => e.CartId, "Inventory picking_FK");

            entity.HasIndex(e => e.OptionId, "Option choosing_FK");

            entity.HasIndex(e => e.OrderId, "Ordering_FK");

            entity.HasIndex(e => e.ProductId, "Personalizing_FK");

            entity.Property(e => e.ItemId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Item_id");
            entity.Property(e => e.CartId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Cart_id");
            entity.Property(e => e.ItemPrice)
                .HasColumnType("money")
                .HasColumnName("Item_price");
            entity.Property(e => e.ItemQuantity).HasColumnName("Item_quantity");
            entity.Property(e => e.ItemVisible).HasColumnName("Item_visible");
            entity.Property(e => e.OptionId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Option_id");
            entity.Property(e => e.OrderId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Order_id");
            entity.Property(e => e.ProductId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Product_id");

            entity.HasOne(d => d.Cart).WithMany(p => p.Items)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("FK_ITEM_INVENTORY_CART");

            entity.HasOne(d => d.Option).WithMany(p => p.Items)
                .HasForeignKey(d => d.OptionId)
                .HasConstraintName("FK_ITEM_OPTION CH_OPTION");

            entity.HasOne(d => d.Order).WithMany(p => p.Items)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_ITEM_ORDERING_ORDER");

            entity.HasOne(d => d.Product).WithMany(p => p.Items)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ITEM_PERSONALI_PRODUCT");
        });

        modelBuilder.Entity<Option>(entity =>
        {
            entity.HasKey(e => e.OptionId)
                .HasName("PK_OPTION")
                .IsClustered(false);

            entity.ToTable("Option");

            entity.HasIndex(e => e.OptionPackId, "Option adding_FK");

            entity.Property(e => e.OptionId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Option_id");
            entity.Property(e => e.OptionName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Option_name");
            entity.Property(e => e.OptionPackId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("OptionPack_id");
            entity.Property(e => e.OptionPrice)
                .HasColumnType("money")
                .HasColumnName("Option_price");

            entity.HasOne(d => d.OptionPack).WithMany(p => p.Options)
                .HasForeignKey(d => d.OptionPackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OPTION_OPTION AD_OPTIONPA");
        });

        modelBuilder.Entity<OptionPack>(entity =>
        {
            entity.HasKey(e => e.OptionPackId)
                .HasName("PK_OPTIONPACK")
                .IsClustered(false);

            entity.ToTable("OptionPack");

            entity.HasIndex(e => e.ProductId, "Option linking2_FK");

            entity.Property(e => e.OptionPackId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("OptionPack_id");
            entity.Property(e => e.ProductId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Product_id");

            entity.HasOne(d => d.Product).WithMany(p => p.OptionPacks)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OPTIONPA_OPTION LI_PRODUCT");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId)
                .HasName("PK_ORDER")
                .IsClustered(false);

            entity.ToTable("Order");

            entity.HasIndex(e => e.AdressId, "Stating adress_FK");

            entity.HasIndex(e => e.UserId, "User has order_FK");

            entity.Property(e => e.OrderId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Order_id");
            entity.Property(e => e.AdressId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Adress_id");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("Order_date");
            entity.Property(e => e.OrderPrice)
                .HasColumnType("money")
                .HasColumnName("Order_price");
            entity.Property(e => e.UserId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("User_id");

            entity.HasOne(d => d.Adress).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AdressId)
                .HasConstraintName("FK_ORDER_STATING A_ADRESS");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDER_USER HAS _USER");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId)
                .HasName("PK_PAYMENT")
                .IsClustered(false);

            entity.ToTable("Payment");

            entity.HasIndex(e => e.OrderId, "Paying_FK");

            entity.Property(e => e.PaymentId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Payment_id");
            entity.Property(e => e.OrderId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Order_id");
            entity.Property(e => e.PaymentAmount)
                .HasColumnType("money")
                .HasColumnName("Payment_amount");
            entity.Property(e => e.PaymentDate)
                .HasColumnType("datetime")
                .HasColumnName("Payment_date");
            entity.Property(e => e.PaymentMethodId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("PaymentMethod_id");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PAYMENT_PAYING_ORDER");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Payments)
                .HasForeignKey(d => d.PaymentMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PAYMENT_PAYMENT H_PAYMENTM");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.PaymentMethodId)
                .HasName("PK_PAYMENTMETHOD")
                .IsClustered(false);

            entity.ToTable("PaymentMethod");

            entity.Property(e => e.PaymentMethodId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("PaymentMethod_id");
            entity.Property(e => e.PaymentMethodName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PaymentMethod_name");
        });

        modelBuilder.Entity<PaymentStatus>(entity =>
        {
            entity.HasKey(e => e.PaymentStatusId)
                .HasName("PK_PAYMENTSTATUS")
                .IsClustered(false);

            entity.ToTable("PaymentStatus");

            entity.Property(e => e.PaymentStatusId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("PaymentStatus_id");
            entity.Property(e => e.PaymentStatusName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PaymentStatus_name");
        });

        modelBuilder.Entity<PaymentStatusHistory>(entity =>
        {
            entity.HasKey(e => e.PaymentStatusHistoryId)
                .HasName("PK_PAYMENTSTATUSHISTORY")
                .IsClustered(false);

            entity.ToTable("PaymentStatusHistory");

            entity.HasIndex(e => e.PaymentId, "Payment has status history_FK");

            entity.HasIndex(e => e.PaymentStatusId, "Payment status has history_FK");

            entity.Property(e => e.PaymentStatusHistoryId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("PaymentStatusHistory_id");
            entity.Property(e => e.PaymentId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Payment_id");
            entity.Property(e => e.PaymentStatusHistoryDate)
                .HasColumnType("datetime")
                .HasColumnName("PaymentStatusHistory_date");
            entity.Property(e => e.PaymentStatusId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("PaymentStatus_id");

            entity.HasOne(d => d.Payment).WithMany(p => p.PaymentStatusHistories)
                .HasForeignKey(d => d.PaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PAYMENTS_PAYMENT H_PAYMENT");

            entity.HasOne(d => d.PaymentStatus).WithMany(p => p.PaymentStatusHistories)
                .HasForeignKey(d => d.PaymentStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PAYMENTS_PAYMENT S_PAYMENTS");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId)
                .HasName("PK_PRODUCT")
                .IsClustered(false);

            entity.ToTable("Product");

            entity.HasIndex(e => e.CategoryId, "Categorizing_FK");

            entity.HasIndex(e => e.OptionPackId, "Option linking_FK");

            entity.HasIndex(e => e.UserId, "Selling_FK");

            entity.Property(e => e.ProductId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Product_id");
            entity.Property(e => e.CategoryId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Category_id");
            entity.Property(e => e.OptionPackId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("OptionPack_id");
            entity.Property(e => e.ProductDescription)
                .HasColumnType("text")
                .HasColumnName("Product_description");
            entity.Property(e => e.ProductName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Product_name");
            entity.Property(e => e.ProductPrice)
                .HasColumnType("money")
                .HasColumnName("Product_price");
            entity.Property(e => e.ProductQuantity).HasColumnName("Product_quantity");
            entity.Property(e => e.ProductVisibility).HasColumnName("Product_visibility");
            entity.Property(e => e.UserId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("User_id");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_PRODUCT_CATEGORIZ_CATEGORY");

            entity.HasOne(d => d.OptionPack).WithMany(p => p.Products)
                .HasForeignKey(d => d.OptionPackId)
                .HasConstraintName("FK_PRODUCT_OPTION LI_OPTIONPA");

            entity.HasOne(d => d.User).WithMany(p => p.Products)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCT_SELLING_USER");
        });

        modelBuilder.Entity<ProductInfo>(entity =>
        {
            entity.HasKey(e => e.ProductInfoId)
                .HasName("PK_PRODUCTINFO")
                .IsClustered(false);

            entity.ToTable("ProductInfo");

            entity.HasIndex(e => e.ProductId, "Sending/Receiving product_FK");

            entity.Property(e => e.ProductInfoId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("ProductInfo_id");
            entity.Property(e => e.ProductId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Product_id");
            entity.Property(e => e.ProductInfoDate)
                .HasColumnType("datetime")
                .HasColumnName("ProductInfo_date");
            entity.Property(e => e.ProductInfoQuantity).HasColumnName("ProductInfo_quantity");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductInfos)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCTI_SENDING/R_PRODUCT");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.StateId)
                .HasName("PK_STATE")
                .IsClustered(false);

            entity.ToTable("State");

            entity.HasIndex(e => e.CountryId, "Country has states_FK");

            entity.Property(e => e.StateId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("State_id");
            entity.Property(e => e.CountryId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Country_id");
            entity.Property(e => e.StateName)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("State_name");

            entity.HasOne(d => d.Country).WithMany(p => p.States)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_STATE_COUNTRY H_COUNTRY");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId)
                .HasName("PK_USER")
                .IsClustered(false);

            entity.ToTable("User");

            entity.HasIndex(e => e.UserNickname, "AK_IDENTIFIER_2_USER").IsUnique();

            entity.HasIndex(e => e.UserEmail, "AK_IDENTIFIER_3_USER").IsUnique();

            entity.Property(e => e.UserId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("User_id");
            entity.Property(e => e.UserCreationDate)
                .HasColumnType("datetime")
                .HasColumnName("User_creationDate");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("User_email");
            entity.Property(e => e.UserName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("User_name");
            entity.Property(e => e.UserNickname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("User_nickname");
            entity.Property(e => e.UserNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("User_number");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("User_password");
            entity.Property(e => e.UserSurname)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("User_surname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
