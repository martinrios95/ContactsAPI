using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactsAPI.Migrations
{
    public partial class Contacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactID);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateID);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityID", "CityName", "StateID" },
                values: new object[,]
                {
                    { 1, "Bahia Blanca", 1 },
                    { 2, "Punta Alta", 1 },
                    { 3, "Medanos", 1 },
                    { 4, "La Boca", 2 },
                    { 5, "Balvanera", 2 },
                    { 6, "Caballito", 2 },
                    { 7, "Villa Crespo", 2 },
                    { 8, "Monte Hermoso", 1 },
                    { 9, "La Matanza", 1 },
                    { 10, "Mar del Plata", 1 },
                    { 11, "Córdoba", 3 },
                    { 12, "Villa General Belgrano", 3 },
                    { 13, "Pigüé", 1 },
                    { 14, "Villa Iris", 1 }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactID", "CityID", "ContactAddress", "ContactName", "ContactPhone" },
                values: new object[,]
                {
                    { new Guid("27fd0b27-465b-43af-929e-e0a2c33ddcb5"), 1, "DIRECCION 5", "PRUEBA 5", "1155556666" },
                    { new Guid("4f01ed59-e0f3-4ac2-b688-79d759183ebb"), 1, "DIRECCION 2", "NOMBRE 2", "1141112222" },
                    { new Guid("bc21a495-9c03-4e9c-8558-acead3d92085"), 2, "DIRECCION 3", "PRUEBA 3", "2253334444" },
                    { new Guid("fb37d4b7-caeb-4ffd-8824-876bf0993447"), 4, "DIRECCION 4", "PRUEBA 4", "2233334444" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateName" },
                values: new object[,]
                {
                    { 1, "Buenos Aires" },
                    { 2, "Ciudad Autonoma de Buenos Aires" },
                    { 3, "Catamarca" },
                    { 4, "Chaco" },
                    { 5, "Chubut" },
                    { 6, "Cordoba" },
                    { 7, "Corrientes" },
                    { 8, "Entre Rios" },
                    { 9, "Formosa" },
                    { 10, "Jujuy" },
                    { 11, "La Pampa" },
                    { 12, "La Rioja" },
                    { 13, "Mendoza" },
                    { 14, "Misiones" },
                    { 15, "Neuquen" },
                    { 16, "Rio Negro" },
                    { 17, "Salta" },
                    { 18, "San Juan" },
                    { 19, "San Luis" },
                    { 20, "Santa Cruz" },
                    { 21, "Santa Fe" },
                    { 22, "Santiago del Estero" },
                    { 23, "Tierra del Fuego" },
                    { 24, "Tucuman" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
