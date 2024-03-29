﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LanceFlow.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanniePoFurmam",
                columns: table => new
                {
                    VariantId = table.Column<int>(nullable: false),
                    NFurm = table.Column<int>(nullable: false),
                    isActual = table.Column<bool>(nullable: false),
                    RashGazNaF = table.Column<double>(nullable: false),
                    RashVodiNaF = table.Column<double>(nullable: false),
                    Tperepad = table.Column<double>(nullable: false),
                    TrebZnTeor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanniePoFurmam", x => new { x.VariantId, x.NFurm });
                });

            migrationBuilder.CreateTable(
                name: "DanniePoFurmamDate",
                columns: table => new
                {
                    DateId = table.Column<DateTime>(nullable: false),
                    PechId = table.Column<int>(nullable: false),
                    NFurm = table.Column<int>(nullable: false),
                    isActual = table.Column<bool>(nullable: false),
                    RashGazNaF = table.Column<double>(nullable: false),
                    RashVodiNaF = table.Column<double>(nullable: false),
                    Tperepad = table.Column<double>(nullable: false),
                    TrebZnTeor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanniePoFurmamDate", x => new { x.DateId, x.NFurm, x.PechId });
                });

            migrationBuilder.CreateTable(
                name: "Pechi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Vpolez = table.Column<double>(nullable: false),
                    NFurm = table.Column<int>(nullable: false),
                    DiamFurm = table.Column<double>(nullable: false),
                    VisFurm = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pechi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessOfTechnology",
                columns: table => new
                {
                    VariantId = table.Column<int>(nullable: false),
                    PechId = table.Column<int>(nullable: false),
                    UdRashKoks = table.Column<double>(nullable: false),
                    RashDut = table.Column<double>(nullable: false),
                    DavlDut = table.Column<double>(nullable: false),
                    TDut = table.Column<double>(nullable: false),
                    VlazDut = table.Column<double>(nullable: false),
                    SodKislorod = table.Column<double>(nullable: false),
                    Proizv = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessOfTechnology", x => new { x.PechId, x.VariantId });
                });

            migrationBuilder.CreateTable(
                name: "ProcessOfTechnologyDate",
                columns: table => new
                {
                    DateId = table.Column<DateTime>(nullable: false),
                    PechId = table.Column<int>(nullable: false),
                    UdRashKoks = table.Column<double>(nullable: false),
                    RashDut = table.Column<double>(nullable: false),
                    DavlDut = table.Column<double>(nullable: false),
                    TDut = table.Column<double>(nullable: false),
                    VlazDut = table.Column<double>(nullable: false),
                    SodKislorod = table.Column<double>(nullable: false),
                    Proizv = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessOfTechnologyDate", x => new { x.PechId, x.DateId });
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    VariantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.VariantId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "user" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "RoleId" },
                values: new object[] { 1, "dufaz@yandex.ru", "QwE12345", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DanniePoFurmam");

            migrationBuilder.DropTable(
                name: "DanniePoFurmamDate");

            migrationBuilder.DropTable(
                name: "Pechi");

            migrationBuilder.DropTable(
                name: "ProcessOfTechnology");

            migrationBuilder.DropTable(
                name: "ProcessOfTechnologyDate");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Variants");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
