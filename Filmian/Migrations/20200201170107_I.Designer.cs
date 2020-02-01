﻿// <auto-generated />
using System;
using Filmian.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Filmian.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20200201170107_I")]
    partial class I
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Filmian.Models.Director", b =>
                {
                    b.Property<short>("DirectorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaNacimiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Local));

                    b.Property<int>("NacionalidadPaisId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DirectorID");

                    b.HasIndex("NacionalidadPaisId");

                    b.ToTable("Directores");
                });

            modelBuilder.Entity("Filmian.Models.Pais", b =>
                {
                    b.Property<int>("PaisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PaisId");

                    b.HasIndex("Nombre");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("Filmian.Models.Pelicula", b =>
                {
                    b.Property<short>("PeliculaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("DirectorId")
                        .HasColumnType("smallint");

                    b.Property<short>("Duracion")
                        .HasColumnType("smallint");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PeliculaId");

                    b.HasIndex("DirectorId");

                    b.ToTable("Peliculas");
                });

            modelBuilder.Entity("Filmian.Models.Director", b =>
                {
                    b.HasOne("Filmian.Models.Pais", "Nacionalidad")
                        .WithMany()
                        .HasForeignKey("NacionalidadPaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Filmian.Models.Pelicula", b =>
                {
                    b.HasOne("Filmian.Models.Director", "Director")
                        .WithMany("Peliculas")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
