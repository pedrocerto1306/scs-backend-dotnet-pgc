using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sics_webapi.Data.Migrations
{
    /// <inheritdoc />
    public partial class alteracaomodeloavaliacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SicsAvaliacoes_SicsClientes_ClienteID",
                table: "SicsAvaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_SicsAvaliacoes_SicsPrestadores_PrestadorID",
                table: "SicsAvaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_SicsAvaliacoes_SicsServicos_ServicoID",
                table: "SicsAvaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_SicsAvaliacoes_ClienteID",
                table: "SicsAvaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_SicsAvaliacoes_PrestadorID",
                table: "SicsAvaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_SicsAvaliacoes_ServicoID",
                table: "SicsAvaliacoes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SicsAvaliacoes_ClienteID",
                table: "SicsAvaliacoes",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_SicsAvaliacoes_PrestadorID",
                table: "SicsAvaliacoes",
                column: "PrestadorID");

            migrationBuilder.CreateIndex(
                name: "IX_SicsAvaliacoes_ServicoID",
                table: "SicsAvaliacoes",
                column: "ServicoID");

            migrationBuilder.AddForeignKey(
                name: "FK_SicsAvaliacoes_SicsClientes_ClienteID",
                table: "SicsAvaliacoes",
                column: "ClienteID",
                principalTable: "SicsClientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SicsAvaliacoes_SicsPrestadores_PrestadorID",
                table: "SicsAvaliacoes",
                column: "PrestadorID",
                principalTable: "SicsPrestadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SicsAvaliacoes_SicsServicos_ServicoID",
                table: "SicsAvaliacoes",
                column: "ServicoID",
                principalTable: "SicsServicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
