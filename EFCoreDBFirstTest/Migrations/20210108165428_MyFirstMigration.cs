using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreDBFirstTest.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medarbejder_Type",
                columns: table => new
                {
                    Me_Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medarbejder_Type", x => x.Me_Type);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostNr = table.Column<int>(type: "int", nullable: false),
                    Distrikt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostNr);
                });

            migrationBuilder.CreateTable(
                name: "Type_Ydelse",
                columns: table => new
                {
                    Ydelse_Type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Ydelse", x => x.Ydelse_Type);
                });

            migrationBuilder.CreateTable(
                name: "Uddannelser",
                columns: table => new
                {
                    Advokat_Uddanelse = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advokat_Udanelser", x => x.Advokat_Uddanelse);
                });

            migrationBuilder.CreateTable(
                name: "Kunde",
                columns: table => new
                {
                    Kunde_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kunde_Fornavn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Kunde_Efternavn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Kunde_PostNr = table.Column<int>(type: "int", nullable: false),
                    Kunde_Adresse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Kunde_Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Kunde_Oprets_Dato = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunde", x => x.Kunde_ID);
                    table.ForeignKey(
                        name: "FK_Kunde_Post",
                        column: x => x.Kunde_PostNr,
                        principalTable: "Post",
                        principalColumn: "PostNr",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medarbejder",
                columns: table => new
                {
                    Me_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Me_Fornavn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Me_Efternavn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Me_PostNr = table.Column<int>(type: "int", nullable: false),
                    Me_Adresse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Me_Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Me_Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Me_Oprets_Dato = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medarbejder_1", x => x.Me_ID);
                    table.ForeignKey(
                        name: "FK_Medarbejder_Medarbejder_Type",
                        column: x => x.Me_Type,
                        principalTable: "Medarbejder_Type",
                        principalColumn: "Me_Type",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medarbejder_Post",
                        column: x => x.Me_PostNr,
                        principalTable: "Post",
                        principalColumn: "PostNr",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ydelse",
                columns: table => new
                {
                    Ydelse_Nr = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ydelse_Navn = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Ydelse_Pris = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Ydelse_Type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Ydelse_Art = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ydelse_Oprets_Dato = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ydelse", x => x.Ydelse_Nr);
                    table.ForeignKey(
                        name: "FK_Ydelse_Type_Ydelse",
                        column: x => x.Ydelse_Type,
                        principalTable: "Type_Ydelse",
                        principalColumn: "Ydelse_Type",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kunde_Tlf",
                columns: table => new
                {
                    Kunde_Tlf = table.Column<int>(type: "int", nullable: false),
                    Kunde_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunde_Tlf", x => new { x.Kunde_Tlf, x.Kunde_ID });
                    table.ForeignKey(
                        name: "FK_Kunde_Tlf_Kunde1",
                        column: x => x.Kunde_ID,
                        principalTable: "Kunde",
                        principalColumn: "Kunde_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Adv_Arbejds_Ydelser",
                columns: table => new
                {
                    Ydelse_Nr = table.Column<int>(type: "int", nullable: false),
                    Adv_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adv_Arbejds_Ydelser", x => new { x.Ydelse_Nr, x.Adv_ID });
                    table.ForeignKey(
                        name: "FK_Adv_Arbejds_Ydelser_Medarbejder",
                        column: x => x.Adv_ID,
                        principalTable: "Medarbejder",
                        principalColumn: "Me_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Advokat_Uddannelser",
                columns: table => new
                {
                    Advokat_Uddanelse = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Me_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advokat_Uddannelser_1", x => new { x.Advokat_Uddanelse, x.Me_ID });
                    table.ForeignKey(
                        name: "FK_Advokat_Advokat_Udanelser",
                        column: x => x.Advokat_Uddanelse,
                        principalTable: "Uddannelser",
                        principalColumn: "Advokat_Uddanelse",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Advokat_Uddannelser_Medarbejder",
                        column: x => x.Me_ID,
                        principalTable: "Medarbejder",
                        principalColumn: "Me_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Log_In",
                columns: table => new
                {
                    Me_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Log_In_Navn = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Log_In_Pass = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Log_In_Medarbejder",
                        column: x => x.Me_ID,
                        principalTable: "Medarbejder",
                        principalColumn: "Me_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medarbejder_Tlf",
                columns: table => new
                {
                    Me_Tlf = table.Column<int>(type: "int", nullable: false),
                    Me_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medarbejder_Tlf", x => new { x.Me_Tlf, x.Me_ID });
                    table.ForeignKey(
                        name: "FK_Medarbejder_Tlf_Medarbejder1",
                        column: x => x.Me_ID,
                        principalTable: "Medarbejder",
                        principalColumn: "Me_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sag",
                columns: table => new
                {
                    Sag_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sag_Oprets_Dato = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Sag_Slut_Dato = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Sag_Type = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Sag_Afslutet = table.Column<bool>(type: "bit", nullable: false),
                    Sag_Kunde_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sag_Advokat_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sag", x => x.Sag_ID);
                    table.ForeignKey(
                        name: "FK_Sag_Kunde",
                        column: x => x.Sag_Kunde_ID,
                        principalTable: "Kunde",
                        principalColumn: "Kunde_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sag_Medarbejder",
                        column: x => x.Sag_Advokat_ID,
                        principalTable: "Medarbejder",
                        principalColumn: "Me_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kørsel",
                columns: table => new
                {
                    Kørsel_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kørsel_Tid = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Kørsel_Dato = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Kørsel_Notering = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Sag_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Advokat_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kørsel", x => x.Kørsel_ID);
                    table.ForeignKey(
                        name: "FK_Kørsel_Medarbejder",
                        column: x => x.Advokat_ID,
                        principalTable: "Medarbejder",
                        principalColumn: "Me_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kørsel_Sag1",
                        column: x => x.Sag_ID,
                        principalTable: "Sag",
                        principalColumn: "Sag_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sag_Ydelser",
                columns: table => new
                {
                    Sag_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ydelse_Nr = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sag_Ydelse_Oprets_Dato = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sag_Ydelser", x => new { x.Sag_ID, x.Ydelse_Nr });
                    table.ForeignKey(
                        name: "FK_Sag_Ydelser_Sag1",
                        column: x => x.Sag_ID,
                        principalTable: "Sag",
                        principalColumn: "Sag_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sag_Ydelser_Ydelse",
                        column: x => x.Ydelse_Nr,
                        principalTable: "Ydelse",
                        principalColumn: "Ydelse_Nr",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tid",
                columns: table => new
                {
                    Tid_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tid = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Tid_Dato = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Sag_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ydelse_Nr = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Advokat_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tid", x => x.Tid_ID);
                    table.ForeignKey(
                        name: "FK_Tid_Medarbejder",
                        column: x => x.Advokat_ID,
                        principalTable: "Medarbejder",
                        principalColumn: "Me_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tid_Sag_Ydelser",
                        columns: x => new { x.Sag_ID, x.Ydelse_Nr },
                        principalTable: "Sag_Ydelser",
                        principalColumns: new[] { "Sag_ID", "Ydelse_Nr" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tid_Sag1",
                        column: x => x.Sag_ID,
                        principalTable: "Sag",
                        principalColumn: "Sag_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adv_Arbejds_Ydelser_Adv_ID",
                table: "Adv_Arbejds_Ydelser",
                column: "Adv_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Advokat_Uddannelser_Me_ID",
                table: "Advokat_Uddannelser",
                column: "Me_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Kunde_Kunde_PostNr",
                table: "Kunde",
                column: "Kunde_PostNr");

            migrationBuilder.CreateIndex(
                name: "IX_Kunde_Tlf_Kunde_ID",
                table: "Kunde_Tlf",
                column: "Kunde_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Kørsel_Advokat_ID",
                table: "Kørsel",
                column: "Advokat_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Kørsel_Sag_ID",
                table: "Kørsel",
                column: "Sag_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Log_In",
                table: "Log_In",
                column: "Log_In_Navn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Log_In_1",
                table: "Log_In",
                column: "Me_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medarbejder",
                table: "Medarbejder",
                column: "Me_Fornavn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medarbejder_Me_PostNr",
                table: "Medarbejder",
                column: "Me_PostNr");

            migrationBuilder.CreateIndex(
                name: "IX_Medarbejder_Me_Type",
                table: "Medarbejder",
                column: "Me_Type");

            migrationBuilder.CreateIndex(
                name: "IX_Medarbejder_Tlf_Me_ID",
                table: "Medarbejder_Tlf",
                column: "Me_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Sag_Sag_Advokat_ID",
                table: "Sag",
                column: "Sag_Advokat_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Sag_Sag_Kunde_ID",
                table: "Sag",
                column: "Sag_Kunde_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Sag_Ydelser_Ydelse_Nr",
                table: "Sag_Ydelser",
                column: "Ydelse_Nr");

            migrationBuilder.CreateIndex(
                name: "IX_Tid_Advokat_ID",
                table: "Tid",
                column: "Advokat_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Tid_Sag_ID_Ydelse_Nr",
                table: "Tid",
                columns: new[] { "Sag_ID", "Ydelse_Nr" });

            migrationBuilder.CreateIndex(
                name: "IX_Ydelse",
                table: "Ydelse",
                column: "Ydelse_Navn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ydelse_Ydelse_Type",
                table: "Ydelse",
                column: "Ydelse_Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adv_Arbejds_Ydelser");

            migrationBuilder.DropTable(
                name: "Advokat_Uddannelser");

            migrationBuilder.DropTable(
                name: "Kunde_Tlf");

            migrationBuilder.DropTable(
                name: "Kørsel");

            migrationBuilder.DropTable(
                name: "Log_In");

            migrationBuilder.DropTable(
                name: "Medarbejder_Tlf");

            migrationBuilder.DropTable(
                name: "Tid");

            migrationBuilder.DropTable(
                name: "Uddannelser");

            migrationBuilder.DropTable(
                name: "Sag_Ydelser");

            migrationBuilder.DropTable(
                name: "Sag");

            migrationBuilder.DropTable(
                name: "Ydelse");

            migrationBuilder.DropTable(
                name: "Kunde");

            migrationBuilder.DropTable(
                name: "Medarbejder");

            migrationBuilder.DropTable(
                name: "Type_Ydelse");

            migrationBuilder.DropTable(
                name: "Medarbejder_Type");

            migrationBuilder.DropTable(
                name: "Post");
        }
    }
}
