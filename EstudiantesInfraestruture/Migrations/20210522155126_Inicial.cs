using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstudiantesInfraestruture.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "GE");

            migrationBuilder.CreateTable(
                name: "EstadoEstudiante",
                schema: "GE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoEstudiante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoMateria",
                schema: "GE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoMateria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoProfesor",
                schema: "GE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoProfesor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materia",
                schema: "GE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumento",
                schema: "GE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estudiante",
                schema: "GE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 200, nullable: false),
                    Apellido = table.Column<string>(maxLength: 200, nullable: false),
                    Documento = table.Column<string>(maxLength: 20, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Sexo = table.Column<string>(maxLength: 1, nullable: false),
                    Direccion = table.Column<string>(maxLength: 500, nullable: false),
                    Telefono = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    FechaIngreso = table.Column<DateTime>(nullable: false),
                    FechaEgreso = table.Column<DateTime>(nullable: false),
                    FechaRetiro = table.Column<DateTime>(nullable: false),
                    TipoDocumentoId = table.Column<int>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estudiante_EstadoEstudiante_EstadoId",
                        column: x => x.EstadoId,
                        principalSchema: "GE",
                        principalTable: "EstadoEstudiante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estudiante_TipoDocumento_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalSchema: "GE",
                        principalTable: "TipoDocumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profesor",
                schema: "GE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Documento = table.Column<string>(nullable: true),
                    TipoDocumentoId = table.Column<int>(nullable: true),
                    EstadoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profesor_EstadoProfesor_EstadoId",
                        column: x => x.EstadoId,
                        principalSchema: "GE",
                        principalTable: "EstadoProfesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profesor_TipoDocumento_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalSchema: "GE",
                        principalTable: "TipoDocumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EstudiantesXMateria",
                schema: "GE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstudianteId = table.Column<int>(nullable: true),
                    MateriaId = table.Column<int>(nullable: true),
                    EstadoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudiantesXMateria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstudiantesXMateria_EstadoMateria_EstadoId",
                        column: x => x.EstadoId,
                        principalSchema: "GE",
                        principalTable: "EstadoMateria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EstudiantesXMateria_Estudiante_EstudianteId",
                        column: x => x.EstudianteId,
                        principalSchema: "GE",
                        principalTable: "Estudiante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EstudiantesXMateria_Materia_MateriaId",
                        column: x => x.MateriaId,
                        principalSchema: "GE",
                        principalTable: "Materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfesorXMaterias",
                schema: "GE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProfesorId = table.Column<int>(nullable: true),
                    MateriaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfesorXMaterias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfesorXMaterias_Materia_MateriaId",
                        column: x => x.MateriaId,
                        principalSchema: "GE",
                        principalTable: "Materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfesorXMaterias_Profesor_ProfesorId",
                        column: x => x.ProfesorId,
                        principalSchema: "GE",
                        principalTable: "Profesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_Documento",
                schema: "GE",
                table: "Estudiante",
                column: "Documento",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_EstudiantesXMateria_EstadoId",
                schema: "GE",
                table: "EstudiantesXMateria",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_EstudiantesXMateria_EstudianteId",
                schema: "GE",
                table: "EstudiantesXMateria",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_EstudiantesXMateria_MateriaId",
                schema: "GE",
                table: "EstudiantesXMateria",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Materia_Code",
                schema: "GE",
                table: "Materia",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_Documento",
                schema: "GE",
                table: "Profesor",
                column: "Documento",
                unique: true,
                filter: "[Documento] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_EstadoId",
                schema: "GE",
                table: "Profesor",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_TipoDocumentoId",
                schema: "GE",
                table: "Profesor",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesorXMaterias_MateriaId",
                schema: "GE",
                table: "ProfesorXMaterias",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesorXMaterias_ProfesorId",
                schema: "GE",
                table: "ProfesorXMaterias",
                column: "ProfesorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstudiantesXMateria",
                schema: "GE");

            migrationBuilder.DropTable(
                name: "ProfesorXMaterias",
                schema: "GE");

            migrationBuilder.DropTable(
                name: "EstadoMateria",
                schema: "GE");

            migrationBuilder.DropTable(
                name: "Estudiante",
                schema: "GE");

            migrationBuilder.DropTable(
                name: "Materia",
                schema: "GE");

            migrationBuilder.DropTable(
                name: "Profesor",
                schema: "GE");

            migrationBuilder.DropTable(
                name: "EstadoEstudiante",
                schema: "GE");

            migrationBuilder.DropTable(
                name: "EstadoProfesor",
                schema: "GE");

            migrationBuilder.DropTable(
                name: "TipoDocumento",
                schema: "GE");
        }
    }
}
