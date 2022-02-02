using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb3._0._1.Migrations
{
    public partial class EditTablesNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblElev",
                columns: table => new
                {
                    ElevID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Personnummer = table.Column<string>(maxLength: 10, nullable: false),
                    Förnamn = table.Column<string>(maxLength: 50, nullable: false),
                    Efternamn = table.Column<string>(maxLength: 50, nullable: false),
                    Klass = table.Column<string>(maxLength: 10, nullable: false),
                    FK_GenderID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblElev", x => x.ElevID);
                });

            migrationBuilder.CreateTable(
                name: "TblKurs",
                columns: table => new
                {
                    KursID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KursNamn = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblKurs", x => x.KursID);
                });

            migrationBuilder.CreateTable(
                name: "TblPersonal",
                columns: table => new
                {
                    PersonalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(maxLength: 50, nullable: false),
                    Befattning = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPersonal", x => x.PersonalID);
                });

            migrationBuilder.CreateTable(
                name: "TblKursLista",
                columns: table => new
                {
                    KursListaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_ElevID = table.Column<int>(nullable: false),
                    FK_KursID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblKursLista", x => x.KursListaID);
                    table.ForeignKey(
                        name: "FK_tblKursLista_tblElev",
                        column: x => x.FK_ElevID,
                        principalTable: "TblElev",
                        principalColumn: "ElevID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblKursLista_tblKurs",
                        column: x => x.FK_KursID,
                        principalTable: "TblKurs",
                        principalColumn: "KursID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblBetyg",
                columns: table => new
                {
                    BetygID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_ElevID = table.Column<int>(nullable: false),
                    FK_PersonalID = table.Column<int>(nullable: false),
                    FK_KursID = table.Column<int>(nullable: false),
                    Betyg = table.Column<int>(nullable: false),
                    Datum = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblBetyg", x => x.BetygID);
                    table.ForeignKey(
                        name: "FK_tblBetyg_tblElev",
                        column: x => x.FK_ElevID,
                        principalTable: "TblElev",
                        principalColumn: "ElevID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblBetyg_tblKurs",
                        column: x => x.FK_KursID,
                        principalTable: "TblKurs",
                        principalColumn: "KursID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblBetyg_tblPersonal",
                        column: x => x.FK_PersonalID,
                        principalTable: "TblPersonal",
                        principalColumn: "PersonalID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblBetyg_FK_ElevID",
                table: "TblBetyg",
                column: "FK_ElevID");

            migrationBuilder.CreateIndex(
                name: "IX_TblBetyg_FK_KursID",
                table: "TblBetyg",
                column: "FK_KursID");

            migrationBuilder.CreateIndex(
                name: "IX_TblBetyg_FK_PersonalID",
                table: "TblBetyg",
                column: "FK_PersonalID");

            migrationBuilder.CreateIndex(
                name: "IX_TblKursLista_FK_ElevID",
                table: "TblKursLista",
                column: "FK_ElevID");

            migrationBuilder.CreateIndex(
                name: "IX_TblKursLista_FK_KursID",
                table: "TblKursLista",
                column: "FK_KursID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblBetyg");

            migrationBuilder.DropTable(
                name: "TblKursLista");

            migrationBuilder.DropTable(
                name: "TblPersonal");

            migrationBuilder.DropTable(
                name: "TblElev");

            migrationBuilder.DropTable(
                name: "TblKurs");
        }
    }
}
