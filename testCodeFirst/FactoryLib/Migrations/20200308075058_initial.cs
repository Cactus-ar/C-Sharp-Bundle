using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dbTest.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MAIL_Evento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Prioridad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAIL_Evento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mail_Criterio_Actualizacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: true),
                    CriterioActualizacion = table.Column<string>(nullable: false),
                    FactoryEventoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mail_Criterio_Actualizacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mail_Criterio_Actualizacion_MAIL_Evento_FactoryEventoId",
                        column: x => x.FactoryEventoId,
                        principalTable: "MAIL_Evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MAIL_Criterio_Busqueda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: true),
                    CriterioBusqueda = table.Column<string>(nullable: false),
                    Reemplazos = table.Column<string>(maxLength: 400, nullable: false),
                    Sucursales = table.Column<int>(nullable: false),
                    EventoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAIL_Criterio_Busqueda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MAIL_Criterio_Busqueda_MAIL_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "MAIL_Evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MAIL_Plantilla",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: true),
                    Plantilla = table.Column<string>(nullable: false),
                    Reemplazos = table.Column<string>(maxLength: 400, nullable: false),
                    Mail_De = table.Column<string>(maxLength: 200, nullable: false),
                    Asunto = table.Column<string>(maxLength: 250, nullable: false),
                    Mail_cco = table.Column<string>(maxLength: 200, nullable: true),
                    EventoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAIL_Plantilla", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MAIL_Plantilla_MAIL_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "MAIL_Evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mail_Criterio_Actualizacion_FactoryEventoId",
                table: "Mail_Criterio_Actualizacion",
                column: "FactoryEventoId");

            migrationBuilder.CreateIndex(
                name: "IX_MAIL_Criterio_Busqueda_EventoId",
                table: "MAIL_Criterio_Busqueda",
                column: "EventoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MAIL_Plantilla_EventoId",
                table: "MAIL_Plantilla",
                column: "EventoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mail_Criterio_Actualizacion");

            migrationBuilder.DropTable(
                name: "MAIL_Criterio_Busqueda");

            migrationBuilder.DropTable(
                name: "MAIL_Plantilla");

            migrationBuilder.DropTable(
                name: "MAIL_Evento");
        }
    }
}
