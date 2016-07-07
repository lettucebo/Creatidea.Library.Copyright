using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Creatidea.Library.Copyright.Web.Models
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;

    public partial class CopyrightsContext : DbContext
    {
        public CopyrightsContext(DbContextOptions<CopyrightsContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Machine>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.Action).HasDefaultValueSql("2");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.MachineKey).HasDefaultValueSql("newid()");

                entity.Property(e => e.ModifyTime).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.Machines)
                    .HasForeignKey(d => d.SiteId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Machines_Sites");
            });

            modelBuilder.Entity<SiteIp>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.Action).HasDefaultValueSql("2");

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.ModifyTime).HasColumnType("datetime");

                entity.Property(e => e.Url).IsRequired();

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.SiteIps)
                    .HasForeignKey(d => d.SiteId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SiteIps_Sites");
            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.DefaultAction).HasDefaultValueSql("2");

                entity.Property(e => e.ModifyTime).HasColumnType("datetime");
            });
        }

        public DbSet<Site> Sites { get; set; }
        public DbSet<SiteIp> SiteIps { get; set; }
        public DbSet<Machine> Machines { get; set; }
    }
}
