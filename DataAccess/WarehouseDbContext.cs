using Microsoft.EntityFrameworkCore;

namespace BTUProject.DataAccess
{
    public class WarehouseDbContext : DbContext
    {
        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : base(options)
        { }

        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategories> ProductCategories { get; set; }
        public virtual DbSet<Units> Units { get; set; }
        public virtual DbSet<PhoneTypes> PhoneTypes { get; set; }
        public virtual DbSet<CustomersPhoneNumbers> CustomersPhoneNumbers { get; set; }
        public virtual DbSet<CustomersRelationships> CustomersRelationships { get; set; }
        public virtual DbSet<RelationshipTypes> RelationshipTypes { get; set; }

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

            builder.Entity<Customer>()
                .HasMany(c => c.EndCustomersRelationships)
                .WithOne(r => r.EndCustomer)
                .HasForeignKey(r => r.EndCustomerId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region ProductCategories
            builder.Entity<ProductCategories>().ToTable("ProductCategories");
            builder.Entity<ProductCategories>().HasKey(e => e.Id);
            #endregion

            #region WareHouse
            builder.Entity<WareHouse>().ToTable("WareHouse");
            builder.Entity<WareHouse>().HasKey(e => e.Id);
            builder.Entity<WareHouse>().Property(w => w.RealizationPrice)
  .HasColumnType("decimal(18, 2)");
            builder.Entity<WareHouse>()
                .Property(o => o.UnitPrice)
                .HasColumnType("decimal(18, 2)");
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

        }
    }
}
