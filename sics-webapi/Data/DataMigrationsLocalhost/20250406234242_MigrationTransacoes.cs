using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sics_webapi.DataMigrationsLocalhost
{
    /// <inheritdoc />
    public partial class MigrationTransacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SicsServicosContratados");

            migrationBuilder.DropTable(
                name: "SicsServicosOferecidos");

            migrationBuilder.CreateTable(
                name: "SicsTransacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PrestadorId = table.Column<int>(type: "int", nullable: false),
                    ServicoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    efetivado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    data = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SicsTransacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SicsTransacoes_SicsClientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "SicsClientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SicsTransacoes_SicsPrestadores_PrestadorId",
                        column: x => x.PrestadorId,
                        principalTable: "SicsPrestadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SicsTransacoes_SicsServicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "SicsServicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SicsTransacoes_ClienteId",
                table: "SicsTransacoes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_SicsTransacoes_PrestadorId",
                table: "SicsTransacoes",
                column: "PrestadorId");

            migrationBuilder.CreateIndex(
                name: "IX_SicsTransacoes_ServicoId",
                table: "SicsTransacoes",
                column: "ServicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SicsTransacoes");

            migrationBuilder.CreateTable(
                name: "SicsServicosContratados",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ServicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SicsServicosContratados", x => x.ClienteId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SicsServicosOferecidos",
                columns: table => new
                {
                    PrestadorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ServicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SicsServicosOferecidos", x => x.PrestadorId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
