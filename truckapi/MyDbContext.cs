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

            //Status
            modelBuilder.Entity<Status>().HasData(new Models.Status(statusId: 1, value: "Chờ báo giá", color: "0xffffeb3b")
                , new Models.Status(statusId: 2, value: "Đang vận chuyển", color: "0xff2196f3")
                , new Models.Status(statusId: 3, value: "Hoàn thành", color: "0xff66bb6a")
                , new Models.Status(statusId: 4, value: "Đã hủy", color: "0xfff44336"));

            //request
            modelBuilder.Entity<Request>().HasOne(r => r.Status).WithMany(s => s.Requests).HasForeignKey(r => r.StatusId);

        }

        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Quotation> Quotation { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<truckapi.Models.Address> Address { get; set; }
        public DbSet<truckapi.Models.Place> Place { get; set; }
        public DbSet<truckapi.Models.CommodityOwner> CommodityOwner { get; set; }
        public DbSet<truckapi.Models.Reciver> Reciver { get; set; }
        public DbSet<truckapi.Models.Status> Status { get; set; }

    }
}
