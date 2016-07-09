using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Creatidea.Library.Copyright.Web.Migrations
{
    public partial class Mig004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    DefaultAction = table.Column<int>(nullable: false, defaultValueSql: "2"),
                    IsDelete = table.Column<bool>(nullable: false),
                    Modifier = table.Column<Guid>(nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Action = table.Column<int>(nullable: false, defaultValueSql: "2"),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    MachineKey = table.Column<Guid>(nullable: false, defaultValueSql: "newid()"),
                    Modifier = table.Column<Guid>(nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(nullable: false),
                    SiteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Machines_Sites",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SiteIps",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Action = table.Column<int>(nullable: false, defaultValueSql: "2"),
                    Address = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Modifier = table.Column<Guid>(nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    SiteId = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteIps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiteIps_Sites",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hosts_SiteId",
                table: "Hosts",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteIps_SiteId",
                table: "SiteIps",
                column: "SiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hosts");

            migrationBuilder.DropTable(
                name: "SiteIps");

            migrationBuilder.DropTable(
                name: "Sites");
        }
    }
}
