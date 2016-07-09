using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Creatidea.Library.Copyright.Web.Migrations
{
    using Creatidea.Library.Copyright.Library.Models;

    [DbContext(typeof(CopyrightsContext))]
    [Migration("20160709102021_Mig004")]
    partial class Mig004
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Creatidea.Library.Copyright.Web.Models.Host", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<int>("Action")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("2");

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("MachineKey")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newid()");

                    b.Property<Guid?>("Modifier");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid>("SiteId");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.ToTable("Hosts");
                });

            modelBuilder.Entity("Creatidea.Library.Copyright.Web.Models.Site", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("DefaultAction")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("2");

                    b.Property<bool>("IsDelete");

                    b.Property<Guid?>("Modifier");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("Creatidea.Library.Copyright.Web.Models.SiteIp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<int>("Action")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("2");

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid?>("Modifier");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnType("datetime");

                    b.Property<Guid>("SiteId");

                    b.Property<int>("Type");

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.ToTable("SiteIps");
                });

            modelBuilder.Entity("Creatidea.Library.Copyright.Web.Models.Host", b =>
                {
                    b.HasOne("Creatidea.Library.Copyright.Web.Models.Site", "Site")
                        .WithMany("Machines")
                        .HasForeignKey("SiteId")
                        .HasConstraintName("FK_Machines_Sites");
                });

            modelBuilder.Entity("Creatidea.Library.Copyright.Web.Models.SiteIp", b =>
                {
                    b.HasOne("Creatidea.Library.Copyright.Web.Models.Site", "Site")
                        .WithMany("SiteIps")
                        .HasForeignKey("SiteId")
                        .HasConstraintName("FK_SiteIps_Sites");
                });
        }
    }
}
