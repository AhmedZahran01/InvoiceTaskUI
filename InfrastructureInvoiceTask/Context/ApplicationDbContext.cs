using DomainInvoiceTask.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureInvoiceTask.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Item> Items => Set<Item>();
        public DbSet<Unit> Units => Set<Unit>();
        public DbSet<Invoice> Invoices => Set<Invoice>();
        public DbSet<InvoiceItem> InvoiceItems => Set<InvoiceItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Name = "Apple" },
                new Item { Id = 2, Name = "Orange" }
            );

            modelBuilder.Entity<Unit>().HasData(
                new Unit { Id = 1, Name = "Kg" },
                new Unit { Id = 2, Name = "Piece" }
            );

            modelBuilder.Entity<InvoiceItem>()
                .Property(i => i.Total)
                .HasComputedColumnSql("[Price] * [Quantity]", stored: false);
        }

       
    }
}

//using DomainInvoiceTask.Entities;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection.Emit;
//using System.Text;
//using System.Threading.Tasks;

//namespace InfrastructureInvoiceTask.Context
//{
//    public class ApplicationDbContext : DbContext
//    {
//        public ApplicationDbContext()
//        {

//        }
//        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//            : base(options) { }

//        public DbSet<Item> Items => Set<Item>();
//        public DbSet<Unit> Units => Set<Unit>();
//        public DbSet<Invoice> Invoices => Set<Invoice>();
//        public DbSet<InvoiceItem> InvoiceItems => Set<InvoiceItem>();

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);

//            modelBuilder.Entity<Item>().HasData(
//                new Item { Id = 1, Name = "Apple" },
//                new Item { Id = 2, Name = "Orange" }
//            );

//            modelBuilder.Entity<Unit>().HasData(
//                new Unit { Id = 1, Name = "Kg" },
//                new Unit { Id = 2, Name = "Piece" }
//            );

//            modelBuilder.Entity<InvoiceItem>()
//                .Property(i => i.Total)
//                .HasComputedColumnSql("[Price] * [Quantity]", stored: false);
//        }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseSqlServer(
//                "Server=DESKTOP-NRGEJ6B\\SQLEXPRESS;Database=InviceTask-DB;Integrated Security=True;TrustServerCertificate=true;Trusted_Connection=True;MultipleActiveResultSets=true"
//            );
//        }
//    }
//}
