using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Creatidea.Library.Copyright.Web.Models;

namespace Creatidea.Library.Copyright.Web.Migrations
{
    [DbContext(typeof(CopyrightsContext))]
    [Migration("20160707083731_Mig001")]
    partial class Mig001
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Creatidea.Library.Copyright.Web.Models.Machine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Action");

                    b.Property<DateTime>("CreateTime");

                    b.Property<Guid>("MachineKey");

                    b.Property<Guid?>("Modifier");

                    b.Property<DateTime?>("ModifyTime");

                    b.Property<string>("Name");

                    b.Property<Guid>("SiteId");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("Creatidea.Library.Copyright.Web.Models.Site", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<int>("DefaultAction");

                    b.Property<bool>("IsDelete");

                    b.Property<Guid?>("Modifier");

                    b.Property<DateTime?>("ModifyTime");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("Creatidea.Library.Copyright.Web.Models.SiteIp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Action");

                    b.Property<string>("Address");

                    b.Property<DateTime>("CreateTime");

                    b.Property<Guid?>("Modifier");

                    b.Property<DateTime?>("ModifyTime");

                    b.Property<Guid>("SiteId");

                    b.Property<int>("Type");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.ToTable("SiteIps");
                });

            modelBuilder.Entity("Creatidea.Library.Copyright.Web.Models.Machine", b =>
                {
                    b.HasOne("Creatidea.Library.Copyright.Web.Models.Site", "Site")
                        .WithMany("Machines")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Creatidea.Library.Copyright.Web.Models.SiteIp", b =>
                {
                    b.HasOne("Creatidea.Library.Copyright.Web.Models.Site", "Site")
                        .WithMany("SiteIps")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
