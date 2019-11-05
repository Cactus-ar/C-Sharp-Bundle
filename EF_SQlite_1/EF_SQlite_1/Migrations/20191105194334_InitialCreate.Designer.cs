﻿// <auto-generated />
using System;
using EF_SQlite_1.Servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EF_SQlite_1.Migrations
{
    [DbContext(typeof(conectorDB))]
    [Migration("20191105194334_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("EF_SQlite_1.Modelos.Jornada", b =>
                {
                    b.Property<int>("JornadaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Observaciones")
                        .HasColumnType("TEXT");

                    b.HasKey("JornadaId");

                    b.ToTable("Jornadas");
                });

            modelBuilder.Entity("EF_SQlite_1.Modelos.Tarea", b =>
                {
                    b.Property<int>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<bool>("Finalizada")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("TareaId");

                    b.ToTable("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}
