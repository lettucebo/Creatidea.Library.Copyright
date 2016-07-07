using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Creatidea.Library.Copyright.Web.Migrations
{
    public partial class Mig002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Sites_SiteId",
                table: "Machines");

            migrationBuilder.DropForeignKey(
                name: "FK_SiteIps_Sites_SiteId",
                table: "SiteIps");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "SiteIps",
                nullable: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "SiteIps",
                type: "datetime",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "SiteIps",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "SiteIps",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "Action",
                table: "SiteIps",
                nullable: false,
                defaultValueSql: "2");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "SiteIps",
                nullable: false,
                defaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Sites",
                type: "datetime",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DefaultAction",
                table: "Sites",
                nullable: false,
                defaultValueSql: "2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Sites",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sites",
                nullable: false,
                defaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Machines",
                nullable: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Machines",
                type: "datetime",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MachineKey",
                table: "Machines",
                nullable: false,
                defaultValueSql: "newid()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Machines",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<int>(
                name: "Action",
                table: "Machines",
                nullable: false,
                defaultValueSql: "2");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Machines",
                nullable: false,
                defaultValueSql: "newsequentialid()");

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Sites",
                table: "Machines",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SiteIps_Sites",
                table: "SiteIps",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Sites",
                table: "Machines");

            migrationBuilder.DropForeignKey(
                name: "FK_SiteIps_Sites",
                table: "SiteIps");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "SiteIps",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "SiteIps",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "SiteIps",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "SiteIps",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Action",
                table: "SiteIps",
                nullable: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "SiteIps",
                nullable: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Sites",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DefaultAction",
                table: "Sites",
                nullable: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Sites",
                nullable: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sites",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Machines",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Machines",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MachineKey",
                table: "Machines",
                nullable: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Machines",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "Action",
                table: "Machines",
                nullable: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Machines",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Sites_SiteId",
                table: "Machines",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SiteIps_Sites_SiteId",
                table: "SiteIps",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
