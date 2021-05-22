using Microsoft.EntityFrameworkCore.Migrations;

namespace EstudiantesInfraestruture.Migrations
{
    public partial class migracion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Materia_Code",
                schema: "GE",
                table: "Materia");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "GE",
                table: "Materia",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                schema: "GE",
                table: "Estudiante",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.CreateIndex(
                name: "IX_Materia_Code",
                schema: "GE",
                table: "Materia",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Materia_Code",
                schema: "GE",
                table: "Materia");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "GE",
                table: "Materia",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                schema: "GE",
                table: "Estudiante",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300);

            migrationBuilder.CreateIndex(
                name: "IX_Materia_Code",
                schema: "GE",
                table: "Materia",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }
    }
}
