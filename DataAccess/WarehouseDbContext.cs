using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;

namespace BTUProject.DataAccess
{
    public class WarehouseDbContext : DbContext
    {
        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : base(options)
        { }

        public WarehouseDbContext()
        {
        }

        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<ProductCategories> ProductCategories { get; set; }
        public virtual DbSet<Units> Units { get; set; }
        public virtual DbSet<PhoneTypes> PhoneTypes { get; set; }
        public virtual DbSet<CustomersPhoneNumbers> CustomersPhoneNumbers { get; set; }
        public virtual DbSet<CustomersRelationships> CustomersRelationships { get; set; }
        public virtual DbSet<RelationshipTypes> RelationshipTypes { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Toy> Toy { get; set; }
        public virtual DbSet<SportInventory> SportInventory { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region OrderItems
            builder.Entity<OrderItems>()
      .Property(o => o.DiscountPrice)
      .HasColumnType("decimal(18, 2)"); // Specify the appropriate precision and scale.

            builder.Entity<OrderItems>()
                .Property(o => o.UnitPrice)
                .HasColumnType("decimal(18, 2)"); // Specify the appropriate precision and scale.

            builder.Entity<Orders>()
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18, 2)"); // Specify the appropriate precision and scale.


            #endregion

            #region Units
            builder.Entity<Units>().ToTable("Units");
            builder.Entity<Units>().HasKey(e => e.Id);

            #endregion

            #region Cities
            builder.Entity<Cities>().ToTable("Cities");
            builder.Entity<Cities>().HasKey(e => e.Id);
            #endregion

            #region Countries
            builder.Entity<Countries>().ToTable("Countries");
            builder.Entity<Countries>().HasKey(e => e.Id);
            #endregion

            #region Customer
            builder.Entity<Customer>().ToTable("Customer");
            builder.Entity<Customer>().HasKey(e => e.Id);
            builder.Entity<Customer>().Property(c => c.Id)
            .IsRequired()
            .HasAnnotation("MinValue", 1)
            // Specify that the CustomerId property is the primary key
            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            builder.Entity<Customer>()
                .Property(c => c.FirstName)
                .HasMaxLength(50) // Maximum length
                .IsRequired() // Required (not null)
                .HasAnnotation("MinLength", 2); // Custom annotation for minimum length            

            builder.Entity<Customer>()
                .Property(c => c.LastName)
                .HasMaxLength(50) // Maximum length
                .IsRequired() // Required (not null)
                .HasAnnotation("MinLength", 2); // Custom annotation for minimum length            

            builder.Entity<Customer>()
                .Property(c => c.PersonalNumber)
                .HasColumnType("nvarchar(11)")  // Set data type to nvarchar(11) for 11-character text
                .IsRequired();

            builder.Entity<Customer>()
                .Property(c => c.BirthDate)
                .HasColumnType("date") // Set data type to 'date' for date values
                .IsRequired();

            // Add custom validation for at least 18 years old
            builder.Entity<Customer>()
                .HasCheckConstraint("CHK_BirthDate_Age", "DATEDIFF(YEAR, BirthDate, GETDATE()) >= 18");

            builder.Entity<Customer>()
                .HasMany(c => c.EndCustomersRelationships)
                .WithOne(r => r.EndCustomer)
                .HasForeignKey(r => r.EndCustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Customer>().HasOne(d => d.Cities)
              .WithMany(d => d.Customer)
              .HasForeignKey(d => d.CityId)
              .HasConstraintName("FK_Customer_Cities_CityId");

            builder.Entity<Customer>().HasOne(d => d.Countries)
              .WithMany(d => d.Customer)
              .HasForeignKey(d => d.CountryId)
              .HasConstraintName("FK_Customer_Countries_CountryId");

            builder.Entity<Customer>().HasOne(d => d.Gender)
                .WithMany(d => d.Customer)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK_Customer_Gender_GenderId");

            #endregion

            #region Product
            builder.Entity<Product>().ToTable("Product");
            builder.Entity<Product>().HasKey(e => e.Id);
            builder.Entity<Product>()
               .Property(c => c.Code) // Set data type to nvarchar(11) for 11-character text
               .IsRequired();
            builder.Entity<Product>()
                 .Property(c => c.Id) // Set data type to nvarchar(11) for 11-character text
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            builder.Entity<Product>()
                .Property(c => c.Name) // Set data type to nvarchar(11) for 11-character text
                .IsRequired();
            builder.Entity<Product>().HasOne(d => d.ProductCategories)
                .WithMany(d => d.Product)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Product_ProductCategories_CategoryId");
            #endregion

            #region ProductCategories
            builder.Entity<ProductCategories>().ToTable("ProductCategories");
            builder.Entity<ProductCategories>().HasKey(e => e.Id);
            #endregion

            #region WareHouse
            builder.Entity<WareHouse>().ToTable("WareHouse");
            builder.Entity<WareHouse>().HasKey(e => e.Id);
            builder.Entity<WareHouse>().Property(c => c.Id) // Set data type to nvarchar(11) for 11-character text
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            builder.Entity<WareHouse>().Property(w => w.RealizationPrice)
                .HasColumnType("decimal(18, 2)");
            builder.Entity<WareHouse>()
                .Property(o => o.UnitPrice)
                .HasColumnType("decimal(18, 2)");

            builder.Entity<WareHouse>().HasOne(w => w.Suppliers)
                .WithMany(d => d.WareHouse)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_WareHouse_Suppliers_SupplierId");

            builder.Entity<WareHouse>().HasOne(w => w.Product)
                .WithMany(d => d.WareHouse)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_WareHouse_Product_ProductId");

            builder.Entity<WareHouse>().HasOne(w => w.Units)
                .WithMany(d => d.WareHouse)
                .HasForeignKey(d => d.UnitId)
                .HasConstraintName("FK_WareHouse_Units_UnitId");
            #endregion

            #region Suppliers
            builder.Entity<Suppliers>().ToTable("Suppliers");
            builder.Entity<Suppliers>().HasKey(e => e.Id);
            #endregion

            #region PhoneTypes
            builder.Entity<PhoneTypes>().ToTable("PhoneTypes");
            builder.Entity<PhoneTypes>().HasKey(e => e.Id);
            #endregion

            #region CustomersPhoneNumbers
            builder.Entity<CustomersPhoneNumbers>().ToTable("CustomersPhoneNumbers");
            builder.Entity<CustomersPhoneNumbers>().HasKey(e => e.Id);
            #endregion

            #region CustomersRelationships
            builder.Entity<CustomersRelationships>().ToTable("CustomersRelationships");
            builder.Entity<CustomersRelationships>().HasKey(e => e.Id);
            builder.Entity<CustomersRelationships>()
           .HasOne(r => r.StartCustomer)
           .WithMany(c => c.StartCustomersRelationships)
           .HasForeignKey(r => r.StartCustomerId)
           .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region RelationshipTypes
            builder.Entity<RelationshipTypes>().ToTable("RelationshipTypes");
            builder.Entity<RelationshipTypes>().HasKey(e => e.Id);
            #endregion

            #region Toy
            builder.Entity<Toy>().ToTable("Toy")
                .HasBaseType<Product>();
            builder.Entity<Toy>()
                .Property(t => t.Price)
                .HasColumnType("decimal(18, 2)");
            #endregion

            #region Book
            builder.Entity<Book>().ToTable("Book")
                .HasBaseType<Product>();
            builder.Entity<Book>().Property(b => b.Price)
                .HasColumnType("decimal(18, 2)"); // Specify SQL Server column type

            #endregion

            #region SportInventory
            builder.Entity<SportInventory>().ToTable("SportInventory")
                .HasBaseType<Product>();
            builder.Entity<SportInventory>()
                .Property(s => s.Price)
                .HasColumnType("decimal(18, 2)");
            #endregion

        }

        public static void ImportDataFromCsvFiles()
        {
            using (var context = new WarehouseDbContext())
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string csvFilePath = Path.Combine(baseDirectory, "csvs", "Gender.csv");

                using (var reader = new StreamReader(csvFilePath))
                    File.ReadAllLines(csvFilePath)
         .Skip(1) // Skip header row
         .Select(line => line.Split(','))
         .Select(fields => new Gender
         {
             Name = fields[1],
         });

            }

        }

    }

}
