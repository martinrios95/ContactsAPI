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
                    CityID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CityName = table.Column<string>(type: "TEXT", nullable: false),
                    StateID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactID = table.Column<Guid>(type: "TEXT", nullable: false),
                    ContactName = table.Column<string>(type: "TEXT", nullable: false),
                    ContactAddress = table.Column<string>(type: "TEXT", nullable: false),
                    ContactPhone = table.Column<string>(type: "TEXT", nullable: false),
                    CityID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactID);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StateName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateID);
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateName" },
                values: new object[] { 1, "Buenos Aires" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateName" },
                values: new object[] { 2, "Ciudad Autonoma de Buenos Aires" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateName" },
                values: new object[] { 3, "Catamarca" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateName" },
                values: new object[] { 4, "Chaco" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateName" },
                values: new object[] { 5, "Chubut" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateName" },
                values: new object[] { 6, "Cordoba" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateName" },
                values: new object[] { 7, "Corrientes" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateName" },
                values: new object[] { 8, "Entre Rios" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateName" },
                values: new object[] { 9, "Formosa" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateName" },
                values: new object[] { 10, "Jujuy" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateName" },
                values: new object[] { 11, "La Pampa" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateName" },
                values: new object[] { 12, "La Rioja" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateName" },
                values: new object[] { 13, "Mendoza" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateName" },
                values: new object[] { 14, "Misiones" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateName" },
                values: new object[] { 15, "Neuquen" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateName" },
                values: new object[] { 16, "Rio Negro" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateName" },
                values: new object[] { 17, "Salta" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateName" },
                values: new object[] { 18, "San Juan" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateName" },
                values: new object[] { 19, "San Luis" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateName" },
                values: new object[] { 20, "Santa Cruz" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateName" },
                values: new object[] { 21, "Santa Fe" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateName" },
                values: new object[] { 22, "Santiago del Estero" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateName" },
                values: new object[] { 23, "Tierra del Fuego" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateName" },
                values: new object[] { 24, "Tucuman" });
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
