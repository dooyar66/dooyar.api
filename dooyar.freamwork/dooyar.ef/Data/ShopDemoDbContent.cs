using dooyar.models.Entities;
using Microsoft.EntityFrameworkCore;

namespace dooyar.ef.Data
{
    public class ShopDemoDbContent:DbContext
    {
        public ShopDemoDbContent()
        {

        }

        public ShopDemoDbContent(DbContextOptions<ShopDemoDbContent> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;User Id=root;Password=123456;Database=shop_demo");
            }            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
            });

            //modelBuilder.Entity<StatPageVisitRecord>(entity =>
            //{
            //    entity.HasKey(e => e.Recid);

            //    entity.ToTable("stat_page_visit_record");

            //    entity.HasIndex(e => e.AppVisitGuid)
            //        .HasName("AppVisitGuid")
            //        .IsUnique();

            //    entity.HasIndex(e => e.Inlet)
            //        .HasName("REFERER");

            //    entity.HasIndex(e => e.StartTime)
            //        .HasName("START_TIME");

            //    entity.Property(e => e.Recid).HasColumnType("bigint(20)");

            //    entity.Property(e => e.AppId).HasColumnType("varchar(255)");

            //    entity.Property(e => e.AppToken).HasColumnType("varchar(1024)");

            //    entity.Property(e => e.AppVisitGuid).HasColumnType("varchar(255)");

            //    entity.Property(e => e.EndTime).HasColumnType("datetime");

            //    entity.Property(e => e.Inlet).HasColumnType("varchar(2048)");

            //    entity.Property(e => e.Ip).HasColumnType("varchar(64)");

            //    entity.Property(e => e.PageSize).HasColumnType("varchar(255)");

            //    entity.Property(e => e.PostType).HasColumnType("varchar(255)");

            //    entity.Property(e => e.StartTime).HasColumnType("datetime");

            //    entity.Property(e => e.Token).HasColumnType("varchar(64)");

            //    entity.Property(e => e.Ua).HasColumnType("text");
            //});
        }
    }
}
