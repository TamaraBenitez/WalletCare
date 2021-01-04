using Microsoft.EntityFrameworkCore.Migrations;

namespace walletCare.Migrations
{
    public partial class Empezando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID",
                table: "Usuarios");

            migrationBuilder.AddColumn<string>(
                name: "PropietarioMail",
                table: "Ingresos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Ingresos_PropietarioMail",
                table: "Ingresos",
                column: "PropietarioMail");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresos_Usuarios_PropietarioMail",
                table: "Ingresos",
                column: "PropietarioMail",
                principalTable: "Usuarios",
                principalColumn: "Mail",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingresos_Usuarios_PropietarioMail",
                table: "Ingresos");

            migrationBuilder.DropIndex(
                name: "IX_Ingresos_PropietarioMail",
                table: "Ingresos");

            migrationBuilder.DropColumn(
                name: "PropietarioMail",
                table: "Ingresos");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Usuarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
