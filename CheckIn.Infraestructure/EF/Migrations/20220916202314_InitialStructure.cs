using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckIn.Infraestructure.EF.Migrations {
	[ExcludeFromCodeCoverage]
	public partial class InitialStructure : Migration {
		protected override void Up(MigrationBuilder migrationBuilder) {
			migrationBuilder.CreateTable(
				name: "Vuelo",
				columns: table => new {
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					nroVuelo = table.Column<int>(type: "int", nullable: false),
					origen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
					destino = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
				},
				constraints: table => {
					table.PrimaryKey("PK_Vuelo", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Reserva",
				columns: table => new {
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					nroReserva = table.Column<int>(type: "int", nullable: false),
					hora = table.Column<DateTime>(type: "datetime", nullable: false),
					VueloId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
				},
				constraints: table => {
					table.PrimaryKey("PK_Reserva", x => x.Id);
					table.ForeignKey(
						name: "FK_Reserva_Vuelo_VueloId",
						column: x => x.VueloId,
						principalTable: "Vuelo",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "CheckIn",
				columns: table => new {
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					nroCheckIn = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
					hora = table.Column<DateTime>(type: "datetime", nullable: false),
					esAltaPrioridad = table.Column<int>(type: "int", nullable: false),
					letraAsiento = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
					nroAsiento = table.Column<int>(type: "int", nullable: false),
					ReservaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
					VueloId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
				},
				constraints: table => {
					table.PrimaryKey("PK_CheckIn", x => x.Id);
					table.ForeignKey(
						name: "FK_CheckIn_Reserva_ReservaId",
						column: x => x.ReservaId,
						principalTable: "Reserva",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_CheckIn_Vuelo_VueloId",
						column: x => x.VueloId,
						principalTable: "Vuelo",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Equipaje",
				columns: table => new {
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
					peso = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
					esFragil = table.Column<int>(type: "int", nullable: false),
					CheckInId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
				},
				constraints: table => {
					table.PrimaryKey("PK_Equipaje", x => x.Id);
					table.ForeignKey(
						name: "FK_Equipaje_CheckIn_CheckInId",
						column: x => x.CheckInId,
						principalTable: "CheckIn",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateIndex(
				name: "IX_CheckIn_ReservaId",
				table: "CheckIn",
				column: "ReservaId");

			migrationBuilder.CreateIndex(
				name: "IX_CheckIn_VueloId",
				table: "CheckIn",
				column: "VueloId");

			migrationBuilder.CreateIndex(
				name: "IX_Equipaje_CheckInId",
				table: "Equipaje",
				column: "CheckInId");

			migrationBuilder.CreateIndex(
				name: "IX_Reserva_VueloId",
				table: "Reserva",
				column: "VueloId");
		}

		protected override void Down(MigrationBuilder migrationBuilder) {
			migrationBuilder.DropTable(
				name: "Equipaje");

			migrationBuilder.DropTable(
				name: "CheckIn");

			migrationBuilder.DropTable(
				name: "Reserva");

			migrationBuilder.DropTable(
				name: "Vuelo");
		}
	}
}
