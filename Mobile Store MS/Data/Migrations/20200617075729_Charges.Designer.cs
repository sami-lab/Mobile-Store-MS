﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mobile_Store_MS.Data;

namespace Mobile_Store_MS.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200617075729_Charges")]
    partial class Charges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int>("City");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int?>("CusRef");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName")
                        .IsRequired();

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Photopath");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("StreetAdress");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("addedBy");

                    b.Property<bool>("isactive");

                    b.Property<int?>("store_id");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("store_id");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.Model.BrandModel", b =>
                {
                    b.Property<int>("modelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Android");

                    b.Property<string>("Battery")
                        .IsRequired();

                    b.Property<string>("Display")
                        .IsRequired();

                    b.Property<bool>("FingerPrint");

                    b.Property<string>("Front_Cam");

                    b.Property<DateTime>("LaunchDate")
                        .HasColumnType("Date");

                    b.Property<string>("Networktype");

                    b.Property<int>("PhoneId");

                    b.Property<int>("Price");

                    b.Property<string>("ProcessorName")
                        .IsRequired();

                    b.Property<string>("RAM")
                        .IsRequired();

                    b.Property<string>("SimType")
                        .IsRequired();

                    b.Property<string>("back_cam");

                    b.Property<bool>("front_flash");

                    b.Property<string>("internal_storage")
                        .IsRequired();

                    b.Property<int>("mob_type");

                    b.Property<string>("model_name")
                        .IsRequired();

                    b.HasKey("modelId");

                    b.HasIndex("PhoneId");

                    b.ToTable("BrandModel");
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.Model.Company.ModelImages", b =>
                {
                    b.Property<int>("imageId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image_Path");

                    b.Property<int>("modelId");

                    b.HasKey("imageId");

                    b.HasIndex("modelId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.Model.CompanyModel", b =>
                {
                    b.Property<int>("Phoneid")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Com_name")
                        .IsRequired();

                    b.Property<string>("com_Logo");

                    b.Property<string>("com_country")
                        .IsRequired();

                    b.Property<bool>("isActive");

                    b.HasKey("Phoneid");

                    b.HasIndex("Com_name")
                        .IsUnique();

                    b.ToTable("CompanyModel");
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.Model.Customer.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("State");

                    b.Property<string>("StreetAddress");

                    b.HasKey("AddressId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.Model.Customer.Customer", b =>
                {
                    b.Property<int>("cus_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<int>("CustRef");

                    b.Property<string>("cus_name")
                        .IsRequired();

                    b.Property<string>("cus_phone");

                    b.HasKey("cus_id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CustRef")
                        .IsUnique();

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.Model.Messages.Notifications", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<string>("Url");

                    b.Property<string>("UserId");

                    b.Property<DateTime>("When");

                    b.Property<string>("heading")
                        .IsRequired();

                    b.Property<bool>("read");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.Model.Messages.message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.Property<DateTime>("When");

                    b.Property<bool>("read");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.Model.Order.Order", b =>
                {
                    b.Property<int>("order_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("Date");

                    b.Property<int>("PaymentMethod");

                    b.Property<string>("TakenBy");

                    b.Property<int>("cus_id");

                    b.Property<int>("status");

                    b.Property<int>("store_id");

                    b.HasKey("order_id");

                    b.HasIndex("TakenBy");

                    b.HasIndex("cus_id");

                    b.HasIndex("store_id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.Model.Order.OrderCharges", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChargeId");

                    b.Property<int>("order_id");

                    b.Property<int>("priority");

                    b.HasKey("id");

                    b.HasIndex("order_id");

                    b.HasIndex("priority")
                        .IsUnique();

                    b.ToTable("OrderCharges");
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.Model.Order.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Quantity");

                    b.Property<int>("modelId");

                    b.Property<int>("order_id");

                    b.Property<double>("price");

                    b.HasKey("id");

                    b.HasIndex("modelId");

                    b.HasIndex("order_id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.Model.Purchasing", b =>
                {
                    b.Property<int>("purchase_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<DateTime>("Date")
                        .HasColumnType("Date");

                    b.Property<int>("Quantity");

                    b.Property<int>("modelId");

                    b.Property<int>("store_id");

                    b.Property<string>("takenBy")
                        .IsRequired();

                    b.Property<int>("vendor_id");

                    b.HasKey("purchase_id");

                    b.HasIndex("modelId");

                    b.HasIndex("store_id");

                    b.HasIndex("takenBy");

                    b.HasIndex("vendor_id");

                    b.ToTable("Purchasings");
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.Model.Stock.Stock", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Quantity");

                    b.Property<int>("modelId");

                    b.Property<int>("store_id");

                    b.HasKey("id");

                    b.HasIndex("modelId");

                    b.HasIndex("store_id");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.Model.Store.Store", b =>
                {
                    b.Property<int>("store_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<int>("City");

                    b.Property<DateTime>("Date")
                        .HasColumnType("Date");

                    b.Property<double>("Lat");

                    b.Property<double>("Lng");

                    b.Property<int>("Ref_No");

                    b.Property<string>("StoreName")
                        .IsRequired();

                    b.Property<string>("SupportNo")
                        .IsRequired();

                    b.HasKey("store_id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.Model.Vendor.Vendor", b =>
                {
                    b.Property<int>("ven_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PhoneId");

                    b.Property<string>("ven_name")
                        .IsRequired();

                    b.Property<long>("ven_phone");

                    b.HasKey("ven_id");

                    b.HasIndex("PhoneId");

                    b.ToTable("Vendor");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Mobile_Store_MS.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Mobile_Store_MS.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mobile_Store_MS.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Mobile_Store_MS.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.ApplicationUser", b =>
                {
                    b.HasOne("Mobile_Store_MS.Data.Model.Store.Store", "Store")
                        .WithMany("Employees")
                        .HasForeignKey("store_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.Model.BrandModel", b =>
                {
                    b.HasOne("Mobile_Store_MS.Data.Model.CompanyModel", "model")
                        .WithMany("Brand")
                        .HasForeignKey("PhoneId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.Model.Company.ModelImages", b =>
                {
                    b.HasOne("Mobile_Store_MS.Data.Model.BrandModel", "model")
                        .WithMany("Images")
                        .HasForeignKey("modelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.Model.Customer.Customer", b =>
                {
                    b.HasOne("Mobile_Store_MS.Data.Model.Customer.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.Model.Messages.Notifications", b =>
                {
                    b.HasOne("Mobile_Store_MS.Data.ApplicationUser", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.Model.Messages.message", b =>
                {
                    b.HasOne("Mobile_Store_MS.Data.ApplicationUser", "Sender")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.Model.Order.Order", b =>
                {
                    b.HasOne("Mobile_Store_MS.Data.ApplicationUser", "user_Model")
                        .WithMany("Order_Model")
                        .HasForeignKey("TakenBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Mobile_Store_MS.Data.Model.Customer.Customer", "Cus_model")
                        .WithMany("Order")
                        .HasForeignKey("cus_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mobile_Store_MS.Data.Model.Store.Store", "Store_Model")
                        .WithMany("Order")
                        .HasForeignKey("store_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.Model.Order.OrderCharges", b =>
                {
                    b.HasOne("Mobile_Store_MS.Data.Model.Order.Order", "Order")
                        .WithMany("Charges")
                        .HasForeignKey("order_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.Model.Order.Product", b =>
                {
                    b.HasOne("Mobile_Store_MS.Data.Model.BrandModel", "BrandModel")
                        .WithMany("Orders")
                        .HasForeignKey("modelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mobile_Store_MS.Data.Model.Order.Order", "Order")
                        .WithMany("Products")
                        .HasForeignKey("order_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.Model.Purchasing", b =>
                {
                    b.HasOne("Mobile_Store_MS.Data.Model.BrandModel", "Brand_model")
                        .WithMany("Purchasing")
                        .HasForeignKey("modelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mobile_Store_MS.Data.Model.Store.Store", "Store_Model")
                        .WithMany("Purchasing")
                        .HasForeignKey("store_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mobile_Store_MS.Data.ApplicationUser", "user")
                        .WithMany("Purchasing_Model")
                        .HasForeignKey("takenBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Mobile_Store_MS.Data.Model.Vendor.Vendor", "Vendor_Model")
                        .WithMany("Purchasing")
                        .HasForeignKey("vendor_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.Model.Stock.Stock", b =>
                {
                    b.HasOne("Mobile_Store_MS.Data.Model.BrandModel", "Model")
                        .WithMany("Stock")
                        .HasForeignKey("modelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mobile_Store_MS.Data.Model.Store.Store", "Store")
                        .WithMany("Stock")
                        .HasForeignKey("store_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mobile_Store_MS.Data.Model.Vendor.Vendor", b =>
                {
                    b.HasOne("Mobile_Store_MS.Data.Model.CompanyModel", "model")
                        .WithMany("Vendor")
                        .HasForeignKey("PhoneId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
