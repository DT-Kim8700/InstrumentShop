using App.Models;
using App.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Data
{
    public class ApplicationDbContext : IdentityDbContext<AccountUser>
    {
        public DbSet<AccountUser> AccountUsers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Ect> Ects { get; set; }


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // 시퀀스 설정
            // Order
            builder.HasSequence<int>("OrderNumberSequence", schema: "shared")
                    .StartsAt(1000)
                    .IncrementsBy(1);

            builder.Entity<Order>()
                    .Property(o => o.OrderNumber)
                    .HasDefaultValueSql("NEXT VALUE FOR shared.OrderNumberSequence");

            // OrderItem
            builder.HasSequence<int>("ItemNumberSequence", schema: "shared")
                    .StartsAt(1000)
                    .IncrementsBy(1);

            builder.Entity<OrderItem>()
                    .Property(o => o.ItemNumber)
                    .HasDefaultValueSql("NEXT VALUE FOR shared.ItemNumberSequence");

            // Goods
            builder.HasSequence<int>("GoodsNumberSequence", schema: "shared")
                    .StartsAt(1000)
                    .IncrementsBy(1);

            builder.Entity<Goods>()
                    .Property(g => g.GoodsNumber)
                    .HasDefaultValueSql("NEXT VALUE FOR shared.GoodsNumberSequence");

            // Instrument
            builder.HasSequence<int>("InsNumberSequence", schema: "shared")
                    .StartsAt(1000)
                    .IncrementsBy(1);

            builder.Entity<Instrument>()
                    .Property(i => i.InsNumber)
                    .HasDefaultValueSql("NEXT VALUE FOR shared.InsNumberSequence");

            // Part
            builder.HasSequence<int>("PartNumberSequence", schema: "shared")
                    .StartsAt(1000)
                    .IncrementsBy(1);

            builder.Entity<Part>()
                    .Property(p => p.PartNumber)
                    .HasDefaultValueSql("NEXT VALUE FOR shared.PartNumberSequence");

            // Ect
            builder.HasSequence<int>("EctNumberSequence", schema: "shared")
                    .StartsAt(1000)
                    .IncrementsBy(1);

            builder.Entity<Ect>()
                    .Property(e => e.EctNumber)
                    .HasDefaultValueSql("NEXT VALUE FOR shared.EctNumberSequence");

        }



    }
}
