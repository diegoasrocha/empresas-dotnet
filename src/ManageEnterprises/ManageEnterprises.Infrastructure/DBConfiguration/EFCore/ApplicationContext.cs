using ManageEnterprises.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ManageEnterprises.Infrastructure.DBConfiguration.EFCore
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    DatabaseConnection.ConnectionConfiguration
                                      .GetConnectionString("DefaultConnection")
                );
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Investor> Investors { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<EnterpriseType> EnterpriseTypes { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(model => {
                model.HasKey(p => p.Id);

                model.Property(p => p.Id).ValueGeneratedOnAdd();
                model.Property(p => p.Email).IsRequired().HasMaxLength(150);
                model.Property(p => p.Password).IsRequired().HasMaxLength(150);

                model.HasIndex(p => p.Email).IsUnique();
            });

            modelBuilder.Entity<Investor>(model => {
                model.HasKey(p => p.Id);

                model.Property(p => p.Id).ValueGeneratedOnAdd();
                model.Property(p => p.Name).IsRequired().HasMaxLength(150);
                model.Property(p => p.City).IsRequired().HasMaxLength(150);
                model.Property(p => p.Country).IsRequired().HasMaxLength(150);
                model.Property(p => p.Balance).IsRequired().HasColumnType("decimal(18, 2)").HasDefaultValue(0);
                model.Property(p => p.PortfolioValue).IsRequired().HasDefaultValue(0);
                model.Property(p => p.FirstAccess).IsRequired().HasDefaultValue(true);
                model.Property(p => p.SuperAngel).IsRequired().HasDefaultValue(false);

                model.HasOne(p => p.User).WithOne(p => p.Investor).OnDelete(DeleteBehavior.Restrict); ;
            });

            modelBuilder.Entity<EnterpriseType>(model => {
                model.HasKey(p => p.Id);

                model.Property(p => p.Id).ValueGeneratedNever();
                model.Property(p => p.Name).IsRequired().HasMaxLength(150);

                model.HasIndex(p => p.Name).IsUnique();
            });

            modelBuilder.Entity<Enterprise>(model => {
                model.HasKey(p => p.Id);

                model.Property(p => p.Id).ValueGeneratedOnAdd();
                model.Property(p => p.Name).IsRequired().HasMaxLength(150);
                model.Property(p => p.Description).IsRequired();
                model.Property(p => p.OwnEnterprise).IsRequired().HasDefaultValue(false);
                model.Property(p => p.Value).IsRequired().HasDefaultValue(0);
                model.Property(p => p.Shares).IsRequired().HasDefaultValue(0);
                model.Property(p => p.SharePrice).IsRequired().HasDefaultValue(0);
                model.Property(p => p.OwnShares).IsRequired().HasDefaultValue(0);
                model.Property(p => p.City).IsRequired().HasMaxLength(150);
                model.Property(p => p.Country).IsRequired().HasMaxLength(150);
                model.Property(p => p.EnterpriseTypeId).IsRequired();

                model.HasOne(p => p.EnterpriseType).WithMany(p => p.Enterprises).OnDelete(DeleteBehavior.Restrict); ;
                model.HasOne(p => p.User).WithOne(p => p.Enterprise).OnDelete(DeleteBehavior.Restrict); ;
            });

            modelBuilder.Entity<Portfolio>(model => {
                model.HasKey(p => new { p.InvestorId, p.EnterpriseId });

                model.Property(p => p.InvestorId).ValueGeneratedNever();
                model.Property(p => p.EnterpriseId).ValueGeneratedNever();

                model.HasOne(p => p.Investor).WithMany(p => p.Portfolio).OnDelete(DeleteBehavior.Restrict); ;
                model.HasOne(p => p.Enterprise).WithMany(p => p.Portfolio).OnDelete(DeleteBehavior.Restrict); ;
            });
        }
    }
}
