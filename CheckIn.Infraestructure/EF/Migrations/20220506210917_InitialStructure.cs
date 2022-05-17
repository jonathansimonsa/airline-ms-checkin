using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckIn.Infraestructure.EF.Migrations
{
    public partial class InitialStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckIn",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nroCheckIn = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    horaCheckIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    esAltaPrioridad = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckIn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipaje",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    peso = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    esFragil = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    CheckInId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipaje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipaje_CheckIn_CheckInId",
                        column: x => x.CheckInId,
                        principalTable: "CheckIn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipaje_CheckInId",
                table: "Equipaje",
                column: "CheckInId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipaje");

            migrationBuilder.DropTable(
                name: "CheckIn");
        }
    }
}
