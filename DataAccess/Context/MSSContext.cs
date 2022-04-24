using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class MSSContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MACW10\SQLEXPRESS;database=MSSDB;trusted_connection=true;");
        }

        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Finance> Finances { get; set; }
        public DbSet<Authorization> Authorizations { get; set; }
        public DbSet<EmployeeShop> EmployeeShops { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopCampaign> ShopCampaigns { get; set; }
        public DbSet<ShowCase> ShowCases { get; set; }
        public DbSet<VisitorEvent> VisitorEvents { get; set; }
    }
}
