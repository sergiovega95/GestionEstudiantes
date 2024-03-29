﻿// <auto-generated />
using System;
using EstudiantesInfraestruture.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EstudiantesInfraestruture.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EstudiantesCore.Entidades.EstadoEstudiante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("EstadoEstudiante","GE");
                });

            modelBuilder.Entity("EstudiantesCore.Entidades.EstadoMateria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("EstadoMateria","GE");
                });

            modelBuilder.Entity("EstudiantesCore.Entidades.EstadoProfesor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("EstadoProfesor","GE");
                });

            modelBuilder.Entity("EstudiantesCore.Entidades.Estudiantes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<int>("EstadoId");

                    b.Property<DateTime>("FechaEgreso");

                    b.Property<DateTime>("FechaIngreso");

                    b.Property<DateTime>("FechaNacimiento");

                    b.Property<DateTime>("FechaRetiro");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("TipoDocumentoId");

                    b.HasKey("Id");

                    b.HasIndex("Documento")
                        .IsUnique();

                    b.HasIndex("EstadoId");

                    b.HasIndex("TipoDocumentoId");

                    b.ToTable("Estudiante","GE");
                });

            modelBuilder.Entity("EstudiantesCore.Entidades.EstudiantesXMateria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EstadoId");

                    b.Property<int?>("EstudianteId");

                    b.Property<int?>("MateriaId");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.HasIndex("EstudianteId");

                    b.HasIndex("MateriaId");

                    b.ToTable("EstudiantesXMateria","GE");
                });

            modelBuilder.Entity("EstudiantesCore.Entidades.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<int>("EstadoId");

                    b.Property<bool>("MatriculaPorDefecto");

                    b.Property<string>("Nombre");

                    b.Property<int>("year");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("EstadoId");

                    b.ToTable("Materia","GE");
                });

            modelBuilder.Entity("EstudiantesCore.Entidades.Notas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MateriaId");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<decimal>("Nota");

                    b.Property<int>("Porcentaje");

                    b.HasKey("Id");

                    b.HasIndex("MateriaId");

                    b.ToTable("Notas","GE");
                });

            modelBuilder.Entity("EstudiantesCore.Entidades.Profesor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido");

                    b.Property<string>("Documento");

                    b.Property<int?>("EstadoId");

                    b.Property<string>("Nombre");

                    b.Property<int?>("TipoDocumentoId");

                    b.HasKey("Id");

                    b.HasIndex("Documento")
                        .IsUnique()
                        .HasFilter("[Documento] IS NOT NULL");

                    b.HasIndex("EstadoId");

                    b.HasIndex("TipoDocumentoId");

                    b.ToTable("Profesor","GE");
                });

            modelBuilder.Entity("EstudiantesCore.Entidades.ProfesorXMaterias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MateriaId");

                    b.Property<int?>("ProfesorId");

                    b.HasKey("Id");

                    b.HasIndex("MateriaId");

                    b.HasIndex("ProfesorId");

                    b.ToTable("ProfesorXMaterias","GE");
                });

            modelBuilder.Entity("EstudiantesCore.Entidades.TipoDocumento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("TipoDocumento","GE");
                });

            modelBuilder.Entity("EstudiantesCore.Entidades.Estudiantes", b =>
                {
                    b.HasOne("EstudiantesCore.Entidades.EstadoEstudiante", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EstudiantesCore.Entidades.TipoDocumento", "TipoDocumento")
                        .WithMany()
                        .HasForeignKey("TipoDocumentoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EstudiantesCore.Entidades.EstudiantesXMateria", b =>
                {
                    b.HasOne("EstudiantesCore.Entidades.EstadoMateria", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId");

                    b.HasOne("EstudiantesCore.Entidades.Estudiantes", "Estudiante")
                        .WithMany()
                        .HasForeignKey("EstudianteId");

                    b.HasOne("EstudiantesCore.Entidades.Materia", "Materia")
                        .WithMany()
                        .HasForeignKey("MateriaId");
                });

            modelBuilder.Entity("EstudiantesCore.Entidades.Materia", b =>
                {
                    b.HasOne("EstudiantesCore.Entidades.EstadoMateria", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EstudiantesCore.Entidades.Notas", b =>
                {
                    b.HasOne("EstudiantesCore.Entidades.EstudiantesXMateria", "Materia")
                        .WithMany()
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EstudiantesCore.Entidades.Profesor", b =>
                {
                    b.HasOne("EstudiantesCore.Entidades.EstadoProfesor", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId");

                    b.HasOne("EstudiantesCore.Entidades.TipoDocumento", "TipoDocumento")
                        .WithMany()
                        .HasForeignKey("TipoDocumentoId");
                });

            modelBuilder.Entity("EstudiantesCore.Entidades.ProfesorXMaterias", b =>
                {
                    b.HasOne("EstudiantesCore.Entidades.Materia", "Materia")
                        .WithMany()
                        .HasForeignKey("MateriaId");

                    b.HasOne("EstudiantesCore.Entidades.Profesor", "Profesor")
                        .WithMany()
                        .HasForeignKey("ProfesorId");
                });
#pragma warning restore 612, 618
        }
    }
}
