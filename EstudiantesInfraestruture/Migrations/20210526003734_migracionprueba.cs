using Microsoft.EntityFrameworkCore.Migrations;

namespace EstudiantesInfraestruture.Migrations
{
    public partial class migracionprueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudiante_EstadoEstudiante_EstadoId",
                schema: "GE",
                table: "Estudiante");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudiante_TipoDocumento_TipoDocumentoId",
                schema: "GE",
                table: "Estudiante");

            migrationBuilder.DropIndex(
                name: "IX_Estudiante_EstadoId",
                schema: "GE",
                table: "Estudiante");

            migrationBuilder.DropIndex(
                name: "IX_Estudiante_TipoDocumentoId",
                schema: "GE",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                schema: "GE",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "TipoDocumentoId",
                schema: "GE",
                table: "Estudiante");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                schema: "GE",
                table: "Estudiante",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoDocumentoId",
                schema: "GE",
                table: "Estudiante",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_EstadoId",
                schema: "GE",
                table: "Estudiante",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_TipoDocumentoId",
                schema: "GE",
                table: "Estudiante",
                column: "TipoDocumentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiante_EstadoEstudiante_EstadoId",
                schema: "GE",
                table: "Estudiante",
                column: "EstadoId",
                principalSchema: "GE",
                principalTable: "EstadoEstudiante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiante_TipoDocumento_TipoDocumentoId",
                schema: "GE",
                table: "Estudiante",
                column: "TipoDocumentoId",
                principalSchema: "GE",
                principalTable: "TipoDocumento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
