using dooyar.models.Entities;
using dooyar.models.Enums;
using Microsoft.EntityFrameworkCore;

namespace dooyar.ef.Data
{
    public class AppDbContent:DbContext
    {
        private readonly string _connStr;
        private readonly DBTypes _dbTypes;
        public AppDbContent(string connStr,DBTypes dbTypes = DBTypes.MySql)
        {
            _connStr = connStr;
            _dbTypes = dbTypes;
        }

        public AppDbContent(DbContextOptions<AppDbContent> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                switch (_dbTypes)
                {
                    case DBTypes.SqlServer:
                        optionsBuilder.UseSqlServer(_connStr);
                        break;
                    case DBTypes.MySql:
                        optionsBuilder.UseMySql(_connStr);
                        break;
                    case DBTypes.Sqlite:
                        break;
                    case DBTypes.Oracle:
                        break;
                    default:
                        break;
                }
               
            }            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.Property(t => t.UserName).HasColumnName("user_name");
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
