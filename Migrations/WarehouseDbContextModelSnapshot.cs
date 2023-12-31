﻿// <auto-generated />
using System;
using BTUProject.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BTUProject.Migrations
{
    [DbContext(typeof(WarehouseDbContext))]
    partial class WarehouseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BTUProject.DataAccess.Cities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SuppliersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SuppliersId");

                    b.ToTable("Cities", (string)null);
                });

            modelBuilder.Entity("BTUProject.DataAccess.Countries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SuppliersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SuppliersId");

                    b.ToTable("Countries", (string)null);
                });

            modelBuilder.Entity("BTUProject.DataAccess.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MinValue", 1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasAnnotation("MinLength", 2);

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasAnnotation("MinLength", 2);

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("GenderId");

                    b.ToTable("Customer", (string)null);

                    b.HasCheckConstraint("CHK_BirthDate_Age", "DATEDIFF(YEAR, BirthDate, GETDATE()) >= 18");
                });

            modelBuilder.Entity("BTUProject.DataAccess.CustomersPhoneNumbers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneTypeId")
                        .HasColumnType("int");

                    b.Property<int>("PhoneTypesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PhoneTypesId");

                    b.ToTable("CustomersPhoneNumbers", (string)null);
                });

            modelBuilder.Entity("BTUProject.DataAccess.CustomersRelationships", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EndCustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("RelationshipTypeId")
                        .HasColumnType("int");

                    b.Property<int>("StartCustomerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EndCustomerId");

                    b.HasIndex("RelationshipTypeId");

                    b.HasIndex("StartCustomerId");

                    b.ToTable("CustomersRelationships", (string)null);
                });

            modelBuilder.Entity("BTUProject.DataAccess.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gender", (string)null);
                });

            modelBuilder.Entity("BTUProject.DataAccess.OrderItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DiscountPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDiscounted")
                        .HasColumnType("bit");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems", (string)null);
                });

            modelBuilder.Entity("BTUProject.DataAccess.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("BTUProject.DataAccess.PhoneTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PhoneTypes", (string)null);
                });

            modelBuilder.Entity("BTUProject.DataAccess.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("BTUProject.DataAccess.ProductCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories", (string)null);
                });

            modelBuilder.Entity("BTUProject.DataAccess.RelationshipTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RelationshipTypes", (string)null);
                });

            modelBuilder.Entity("BTUProject.DataAccess.Suppliers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers", (string)null);
                });

            modelBuilder.Entity("BTUProject.DataAccess.Units", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Units", (string)null);
                });

            modelBuilder.Entity("BTUProject.DataAccess.WareHouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OperationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("RealizationPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierId");

                    b.HasIndex("UnitId");

                    b.ToTable("WareHouse", (string)null);
                });

            modelBuilder.Entity("BTUProject.DataAccess.Book", b =>
                {
                    b.HasBaseType("BTUProject.DataAccess.Product");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("PublishingHouse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PublishingYear")
                        .HasColumnType("int");

                    b.Property<int>("RecommendedAge")
                        .HasColumnType("int");

                    b.ToTable("Book", (string)null);
                });

            modelBuilder.Entity("BTUProject.DataAccess.SportInventory", b =>
                {
                    b.HasBaseType("BTUProject.DataAccess.Product");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("RecommentddedAge")
                        .HasColumnType("int");

                    b.ToTable("SportInventory", (string)null);
                });

            modelBuilder.Entity("BTUProject.DataAccess.Toy", b =>
                {
                    b.HasBaseType("BTUProject.DataAccess.Product");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("RecommendedAge")
                        .HasColumnType("int");

                    b.ToTable("Toy", (string)null);
                });

            modelBuilder.Entity("BTUProject.DataAccess.Cities", b =>
                {
                    b.HasOne("BTUProject.DataAccess.Suppliers", null)
                        .WithMany("Cities")
                        .HasForeignKey("SuppliersId");
                });

            modelBuilder.Entity("BTUProject.DataAccess.Countries", b =>
                {
                    b.HasOne("BTUProject.DataAccess.Suppliers", null)
                        .WithMany("Countries")
                        .HasForeignKey("SuppliersId");
                });

            modelBuilder.Entity("BTUProject.DataAccess.Customer", b =>
                {
                    b.HasOne("BTUProject.DataAccess.Cities", "Cities")
                        .WithMany("Customer")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Customer_Cities_CityId");

                    b.HasOne("BTUProject.DataAccess.Countries", "Countries")
                        .WithMany("Customer")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Customer_Countries_CountryId");

                    b.HasOne("BTUProject.DataAccess.Gender", "Gender")
                        .WithMany("Customer")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Customer_Gender_GenderId");

                    b.Navigation("Cities");

                    b.Navigation("Countries");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("BTUProject.DataAccess.CustomersPhoneNumbers", b =>
                {
                    b.HasOne("BTUProject.DataAccess.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTUProject.DataAccess.PhoneTypes", "PhoneTypes")
                        .WithMany()
                        .HasForeignKey("PhoneTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("PhoneTypes");
                });

            modelBuilder.Entity("BTUProject.DataAccess.CustomersRelationships", b =>
                {
                    b.HasOne("BTUProject.DataAccess.Customer", "EndCustomer")
                        .WithMany("EndCustomersRelationships")
                        .HasForeignKey("EndCustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_CustomersRelationships_Customer_EndCustomerId");

                    b.HasOne("BTUProject.DataAccess.RelationshipTypes", "RelationshipTypes")
                        .WithMany("CustomersRelationships")
                        .HasForeignKey("RelationshipTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CustomersRelationships_RelationshipTypes_RelationshipTypeId");

                    b.HasOne("BTUProject.DataAccess.Customer", "StartCustomer")
                        .WithMany("StartCustomersRelationships")
                        .HasForeignKey("StartCustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_CustomersRelationships_Customer_StartCustomerId");

                    b.Navigation("EndCustomer");

                    b.Navigation("RelationshipTypes");

                    b.Navigation("StartCustomer");
                });

            modelBuilder.Entity("BTUProject.DataAccess.OrderItems", b =>
                {
                    b.HasOne("BTUProject.DataAccess.Orders", "Orders")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_OrderItems_Orders_OrderId");

                    b.HasOne("BTUProject.DataAccess.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BTUProject.DataAccess.Orders", b =>
                {
                    b.HasOne("BTUProject.DataAccess.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BTUProject.DataAccess.Product", b =>
                {
                    b.HasOne("BTUProject.DataAccess.ProductCategories", "ProductCategories")
                        .WithMany("Product")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Product_ProductCategories_CategoryId");

                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("BTUProject.DataAccess.WareHouse", b =>
                {
                    b.HasOne("BTUProject.DataAccess.Product", "Product")
                        .WithMany("WareHouse")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_WareHouse_Product_ProductId");

                    b.HasOne("BTUProject.DataAccess.Suppliers", "Suppliers")
                        .WithMany("WareHouse")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_WareHouse_Suppliers_SupplierId");

                    b.HasOne("BTUProject.DataAccess.Units", "Units")
                        .WithMany("WareHouse")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_WareHouse_Units_UnitId");

                    b.Navigation("Product");

                    b.Navigation("Suppliers");

                    b.Navigation("Units");
                });

            modelBuilder.Entity("BTUProject.DataAccess.Book", b =>
                {
                    b.HasOne("BTUProject.DataAccess.Product", null)
                        .WithOne()
                        .HasForeignKey("BTUProject.DataAccess.Book", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BTUProject.DataAccess.SportInventory", b =>
                {
                    b.HasOne("BTUProject.DataAccess.Product", null)
                        .WithOne()
                        .HasForeignKey("BTUProject.DataAccess.SportInventory", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BTUProject.DataAccess.Toy", b =>
                {
                    b.HasOne("BTUProject.DataAccess.Product", null)
                        .WithOne()
                        .HasForeignKey("BTUProject.DataAccess.Toy", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BTUProject.DataAccess.Cities", b =>
                {
                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BTUProject.DataAccess.Countries", b =>
                {
                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BTUProject.DataAccess.Customer", b =>
                {
                    b.Navigation("EndCustomersRelationships");

                    b.Navigation("StartCustomersRelationships");
                });

            modelBuilder.Entity("BTUProject.DataAccess.Gender", b =>
                {
                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BTUProject.DataAccess.Orders", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("BTUProject.DataAccess.Product", b =>
                {
                    b.Navigation("WareHouse");
                });

            modelBuilder.Entity("BTUProject.DataAccess.ProductCategories", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("BTUProject.DataAccess.RelationshipTypes", b =>
                {
                    b.Navigation("CustomersRelationships");
                });

            modelBuilder.Entity("BTUProject.DataAccess.Suppliers", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("Countries");

                    b.Navigation("WareHouse");
                });

            modelBuilder.Entity("BTUProject.DataAccess.Units", b =>
                {
                    b.Navigation("WareHouse");
                });
#pragma warning restore 612, 618
        }
    }
}
