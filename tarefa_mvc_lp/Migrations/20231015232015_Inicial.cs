using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tarefa_mvc_lp.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empreiteira",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cnpj = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empreiteira", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Peao",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    data_nasc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "peoesMestres",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    data_nasc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_peoesMestres", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Obra",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    peaoID = table.Column<int>(type: "int", nullable: false),
                    peaoMestreID = table.Column<int>(type: "int", nullable: false),
                    empreiteiraID = table.Column<int>(type: "int", nullable: false),
                    valorHora = table.Column<float>(type: "real", nullable: false),
                    status = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obra", x => x.id);
                    table.ForeignKey(
                        name: "FK_Obra_Empreiteira_empreiteiraID",
                        column: x => x.empreiteiraID,
                        principalTable: "Empreiteira",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Obra_Peao_peaoID",
                        column: x => x.peaoID,
                        principalTable: "Peao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Obra_peoesMestres_peaoMestreID",
                        column: x => x.peaoMestreID,
                        principalTable: "peoesMestres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Obra_empreiteiraID",
                table: "Obra",
                column: "empreiteiraID");

            migrationBuilder.CreateIndex(
                name: "IX_Obra_peaoID",
                table: "Obra",
                column: "peaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Obra_peaoMestreID",
                table: "Obra",
                column: "peaoMestreID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Obra");

            migrationBuilder.DropTable(
                name: "Empreiteira");

            migrationBuilder.DropTable(
                name: "Peao");

            migrationBuilder.DropTable(
                name: "peoesMestres");
        }
    }
}
