﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace walletCare.Migrations
{
    public partial class Creacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Mail = table.Column<string>(type: "TEXT", nullable: false),
                    NombreDeUsuario = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Mail);
                });

            migrationBuilder.CreateTable(
                name: "Ingresos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Aporte = table.Column<double>(type: "REAL", nullable: false),
                    fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    mailUsuario = table.Column<string>(type: "TEXT", nullable: false),
                    UsuarioMail = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingresos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ingresos_Usuarios_UsuarioMail",
                        column: x => x.UsuarioMail,
                        principalTable: "Usuarios",
                        principalColumn: "Mail",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingresos_UsuarioMail",
                table: "Ingresos",
                column: "UsuarioMail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingresos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}