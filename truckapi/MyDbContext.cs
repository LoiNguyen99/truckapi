using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using truckapi.Models;

namespace truckapi
{
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:hcidb.database.windows.net,1433;Initial Catalog=truck;Persist Security Info=False;User ID=sql;Password=123@Admin;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User
            modelBuilder.Entity<Quotation>().HasOne(q => q.Driver).WithMany(d => d.Quotations).HasForeignKey(q => q.DriverId);

        }

        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Quotation> Quotation { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<truckapi.Models.Address> Address { get; set; }
        public DbSet<truckapi.Models.Place> Place { get; set; }
        public DbSet<truckapi.Models.CommodityOwner> CommodityOwner { get; set; }
        public DbSet<truckapi.Models.Reciver> Reciver { get; set; }
    }
}
