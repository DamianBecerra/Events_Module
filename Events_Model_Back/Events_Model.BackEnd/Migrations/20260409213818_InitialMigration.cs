using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Events_Model.BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    IdEvent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.IdEvent);
                });

            migrationBuilder.CreateTable(
                name: "EventLocation",
                columns: table => new
                {
                    IdLocation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Lng = table.Column<double>(type: "float", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEvent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLocation", x => x.IdLocation);
                    table.ForeignKey(
                        name: "FK_EventLocation_Events_IdEvent",
                        column: x => x.IdEvent,
                        principalTable: "Events",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "IdEvent", "Date", "Description", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 1, 10, 0, 0, 0, DateTimeKind.Utc), "Descripción del evento 1.", "Evento Musical #1" },
                    { 2, new DateTime(2026, 5, 2, 10, 0, 0, 0, DateTimeKind.Utc), "Descripción del evento 2.", "Evento Musical #2" },
                    { 3, new DateTime(2026, 5, 3, 10, 0, 0, 0, DateTimeKind.Utc), "Descripción del evento 3.", "Evento Musical #3" },
                    { 4, new DateTime(2026, 5, 4, 10, 0, 0, 0, DateTimeKind.Utc), "Descripción del evento 4.", "Evento Musical #4" },
                    { 5, new DateTime(2026, 5, 5, 10, 0, 0, 0, DateTimeKind.Utc), "Descripción del evento 5.", "Evento Musical #5" },
                    { 6, new DateTime(2026, 5, 6, 10, 0, 0, 0, DateTimeKind.Utc), "Descripción del evento 6.", "Evento Musical #6" },
                    { 7, new DateTime(2026, 5, 7, 10, 0, 0, 0, DateTimeKind.Utc), "Descripción del evento 7.", "Evento Musical #7" },
                    { 8, new DateTime(2026, 5, 8, 10, 0, 0, 0, DateTimeKind.Utc), "Descripción del evento 8.", "Evento Musical #8" },
                    { 9, new DateTime(2026, 5, 9, 10, 0, 0, 0, DateTimeKind.Utc), "Descripción del evento 9.", "Evento Musical #9" },
                    { 10, new DateTime(2026, 5, 10, 10, 0, 0, 0, DateTimeKind.Utc), "Descripción del evento 10.", "Evento Musical #10" },
                    { 11, new DateTime(2026, 5, 11, 10, 0, 0, 0, DateTimeKind.Utc), "Descripción del evento 11.", "Evento Musical #11" },
                    { 12, new DateTime(2026, 5, 12, 10, 0, 0, 0, DateTimeKind.Utc), "Descripción del evento 12.", "Evento Musical #12" },
                    { 13, new DateTime(2026, 5, 13, 10, 0, 0, 0, DateTimeKind.Utc), "Descripción del evento 13.", "Evento Musical #13" },
                    { 14, new DateTime(2026, 5, 14, 10, 0, 0, 0, DateTimeKind.Utc), "Descripción del evento 14.", "Evento Musical #14" },
                    { 15, new DateTime(2026, 5, 15, 10, 0, 0, 0, DateTimeKind.Utc), "Descripción del evento 15.", "Evento Musical #15" },
                    { 16, new DateTime(2026, 5, 16, 10, 0, 0, 0, DateTimeKind.Utc), "Descripción del evento 16.", "Evento Musical #16" },
                    { 17, new DateTime(2026, 5, 17, 10, 0, 0, 0, DateTimeKind.Utc), "Descripción del evento 17.", "Evento Musical #17" },
                    { 18, new DateTime(2026, 5, 18, 10, 0, 0, 0, DateTimeKind.Utc), "Descripción del evento 18.", "Evento Musical #18" },
                    { 19, new DateTime(2026, 5, 19, 10, 0, 0, 0, DateTimeKind.Utc), "Descripción del evento 19.", "Evento Musical #19" },
                    { 20, new DateTime(2026, 5, 20, 10, 0, 0, 0, DateTimeKind.Utc), "Descripción del evento 20.", "Evento Musical #20" }
                });

            migrationBuilder.InsertData(
                table: "EventLocation",
                columns: new[] { "IdLocation", "Address", "IdEvent", "Lat", "Lng" },
                values: new object[,]
                {
                    { 1, "Sede Principal - Auditorio 1", 1, 4.7120000000000006, -74.073000000000008 },
                    { 2, "Sede Principal - Auditorio 2", 2, 4.7130000000000001, -74.073999999999998 },
                    { 3, "Sede Principal - Auditorio 3", 3, 4.7140000000000004, -74.075000000000003 },
                    { 4, "Sede Principal - Auditorio 4", 4, 4.7149999999999999, -74.076000000000008 },
                    { 5, "Sede Principal - Auditorio 5", 5, 4.7160000000000002, -74.076999999999998 },
                    { 6, "Sede Principal - Auditorio 6", 6, 4.7170000000000005, -74.078000000000003 },
                    { 7, "Sede Principal - Auditorio 7", 7, 4.718, -74.079000000000008 },
                    { 8, "Sede Principal - Auditorio 8", 8, 4.7190000000000003, -74.079999999999998 },
                    { 9, "Sede Principal - Auditorio 9", 9, 4.7200000000000006, -74.081000000000003 },
                    { 10, "Sede Principal - Auditorio 10", 10, 4.7210000000000001, -74.082000000000008 },
                    { 11, "Sede Principal - Auditorio 11", 11, 4.7220000000000004, -74.082999999999998 },
                    { 12, "Sede Principal - Auditorio 12", 12, 4.7229999999999999, -74.084000000000003 },
                    { 13, "Sede Principal - Auditorio 13", 13, 4.7240000000000002, -74.085000000000008 },
                    { 14, "Sede Principal - Auditorio 14", 14, 4.7250000000000005, -74.085999999999999 },
                    { 15, "Sede Principal - Auditorio 15", 15, 4.726, -74.087000000000003 },
                    { 16, "Sede Principal - Auditorio 16", 16, 4.7270000000000003, -74.088000000000008 },
                    { 17, "Sede Principal - Auditorio 17", 17, 4.7280000000000006, -74.088999999999999 },
                    { 18, "Sede Principal - Auditorio 18", 18, 4.7290000000000001, -74.090000000000003 },
                    { 19, "Sede Principal - Auditorio 19", 19, 4.7300000000000004, -74.091000000000008 },
                    { 20, "Sede Principal - Auditorio 20", 20, 4.7309999999999999, -74.091999999999999 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventLocation_IdEvent",
                table: "EventLocation",
                column: "IdEvent",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_Date",
                table: "Events",
                column: "Date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventLocation");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
