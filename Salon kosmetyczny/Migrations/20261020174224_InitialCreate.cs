using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Salonkosmetyczny.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorie_produktow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorie_produktow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Klientci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imię = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nr_telefonu = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klientci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zabiegi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CzasTrwania = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zabiegi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produkt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriaId = table.Column<int>(type: "int", nullable: true),
                    Nazwa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Marka = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AktualnyStan = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    MinimalnyStan = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    JednostkaMiary = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produkt_Kategorie_produktow_KategoriaId",
                        column: x => x.KategoriaId,
                        principalTable: "Kategorie_produktow",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Wizyty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlientId = table.Column<int>(type: "int", nullable: false),
                    ZabiegId = table.Column<int>(type: "int", nullable: false),
                    DataCzasWizyty = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CenaOstateczna = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wizyty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wizyty_Klientci_KlientId",
                        column: x => x.KlientId,
                        principalTable: "Klientci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wizyty_Zabiegi_ZabiegId",
                        column: x => x.ZabiegId,
                        principalTable: "Zabiegi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sklad_zabiegu",
                columns: table => new
                {
                    ZabiegId = table.Column<int>(type: "int", nullable: false),
                    ProduktId = table.Column<int>(type: "int", nullable: false),
                    WymaganaIlosc = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sklad_zabiegu", x => new { x.ZabiegId, x.ProduktId });
                    table.ForeignKey(
                        name: "FK_Sklad_zabiegu_Produkt_ProduktId",
                        column: x => x.ProduktId,
                        principalTable: "Produkt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sklad_zabiegu_Zabiegi_ZabiegId",
                        column: x => x.ZabiegId,
                        principalTable: "Zabiegi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produkt_KategoriaId",
                table: "Produkt",
                column: "KategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sklad_zabiegu_ProduktId",
                table: "Sklad_zabiegu",
                column: "ProduktId");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyty_KlientId",
                table: "Wizyty",
                column: "KlientId");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyty_ZabiegId",
                table: "Wizyty",
                column: "ZabiegId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sklad_zabiegu");

            migrationBuilder.DropTable(
                name: "Wizyty");

            migrationBuilder.DropTable(
                name: "Produkt");

            migrationBuilder.DropTable(
                name: "Klientci");

            migrationBuilder.DropTable(
                name: "Zabiegi");

            migrationBuilder.DropTable(
                name: "Kategorie_produktow");
        }
    }
}
