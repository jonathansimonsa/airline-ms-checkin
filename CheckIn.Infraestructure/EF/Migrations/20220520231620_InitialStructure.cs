using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckIn.Infraestructure.EF.Migrations {
	public partial class InitialStructure : Migration {
		protected override void Up(MigrationBuilder migrationBuilder) {
			migrationBuilder.CreateTable(
				name: "Administrativo",
				columns: table => new {
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					ci = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
					nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
					apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
					cargo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
				},
				constraints: table => {
					table.PrimaryKey("PK_Administrativo", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Asiento",
				columns: table => new {
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
					fila = table.Column<int>(type: "int", nullable: false),
					letra = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
					esPrioridad = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_Asiento", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Ticket",
				columns: table => new {
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					horaReserva = table.Column<DateTime>(type: "datetime", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_Ticket", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "CheckIn",
				columns: table => new {
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					nroCheckIn = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
					horaCheckIn = table.Column<DateTime>(type: "datetime", nullable: false),
					esAltaPrioridad = table.Column<int>(type: "int", nullable: false),
					TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
					AsientoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
					AdministrativoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
				},
				constraints: table => {
					table.PrimaryKey("PK_CheckIn", x => x.Id);
					table.ForeignKey(
						name: "FK_CheckIn_Administrativo_AdministrativoId",
						column: x => x.AdministrativoId,
						principalTable: "Administrativo",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_CheckIn_Asiento_AsientoId",
						column: x => x.AsientoId,
						principalTable: "Asiento",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_CheckIn_Ticket_TicketId",
						column: x => x.TicketId,
						principalTable: "Ticket",
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
				name: "IX_CheckIn_AdministrativoId",
				table: "CheckIn",
				column: "AdministrativoId");

			migrationBuilder.CreateIndex(
				name: "IX_CheckIn_AsientoId",
				table: "CheckIn",
				column: "AsientoId");

			migrationBuilder.CreateIndex(
				name: "IX_CheckIn_TicketId",
				table: "CheckIn",
				column: "TicketId");

			migrationBuilder.CreateIndex(
				name: "IX_Equipaje_CheckInId",
				table: "Equipaje",
				column: "CheckInId");
		}

		protected override void Down(MigrationBuilder migrationBuilder) {
			migrationBuilder.DropTable(
				name: "Equipaje");

			migrationBuilder.DropTable(
				name: "CheckIn");

			migrationBuilder.DropTable(
				name: "Administrativo");

			migrationBuilder.DropTable(
				name: "Asiento");

			migrationBuilder.DropTable(
				name: "Ticket");
		}
	}
}
