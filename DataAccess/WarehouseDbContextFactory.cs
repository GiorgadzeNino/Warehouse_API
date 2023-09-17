using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BTUProject.DataAccess
{
    public class WarehouseDbContextFactory : IDesignTimeDbContextFactory<WarehouseDbContext>
    {
        public WarehouseDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseDbContext>();
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=warehouseDb;Integrated Security=True");

            return new WarehouseDbContext(optionsBuilder.Options);
        }
    }
}