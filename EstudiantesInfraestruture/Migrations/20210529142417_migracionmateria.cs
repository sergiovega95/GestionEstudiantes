using Microsoft.EntityFrameworkCore.Migrations;

namespace EstudiantesInfraestruture.Migrations
{
    public partial class migracionmateria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                schema: "GE",
                table: "Materia",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "year",
                schema: "GE",
                table: "Materia",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Materia_EstadoId",
                schema: "GE",
                table: "Materia",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materia_EstadoMateria_EstadoId",
                schema: "GE",
                table: "Materia",
                column: "EstadoId",
                principalSchema: "GE",
                principalTable: "EstadoMateria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materia_EstadoMateria_EstadoId",
                schema: "GE",
                table: "Materia");

            migrationBuilder.DropIndex(
                name: "IX_Materia_EstadoId",
                schema: "GE",
                table: "Materia");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                schema: "GE",
                table: "Materia");

            migrationBuilder.DropColumn(
                name: "year",
                schema: "GE",
                table: "Materia");
        }
    }
}
