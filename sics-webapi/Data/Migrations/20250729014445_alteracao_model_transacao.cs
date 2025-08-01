using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sics_webapi.Data.Migrations
{
    /// <inheritdoc />
    public partial class alteracao_model_transacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SicsTransacoes_SicsClientes_ClienteId",
                table: "SicsTransacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_SicsTransacoes_SicsPrestadores_PrestadorId",
                table: "SicsTransacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_SicsTransacoes_SicsServicos_ServicoId",
                table: "SicsTransacoes");

            migrationBuilder.DropIndex(
                name: "IX_SicsTransacoes_ClienteId",
                table: "SicsTransacoes");

            migrationBuilder.DropIndex(
                name: "IX_SicsTransacoes_PrestadorId",
                table: "SicsTransacoes");

            migrationBuilder.DropIndex(
                name: "IX_SicsTransacoes_ServicoId",
                table: "SicsTransacoes");

            migrationBuilder.DropColumn(
                name: "Cancelado",
                table: "SicsTransacoes");

            migrationBuilder.DropColumn(
                name: "Efetivado",
                table: "SicsTransacoes");

            migrationBuilder.RenameColumn(
                name: "MotivoCancelamento",
                table: "SicsTransacoes",
                newName: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "SicsTransacoes",
                newName: "MotivoCancelamento");

            migrationBuilder.AddColumn<bool>(
                name: "Cancelado",
                table: "SicsTransacoes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Efetivado",
                table: "SicsTransacoes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.AddForeignKey(
                name: "FK_SicsTransacoes_SicsClientes_ClienteId",
                table: "SicsTransacoes",
                column: "ClienteId",
                principalTable: "SicsClientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SicsTransacoes_SicsPrestadores_PrestadorId",
                table: "SicsTransacoes",
                column: "PrestadorId",
                principalTable: "SicsPrestadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SicsTransacoes_SicsServicos_ServicoId",
                table: "SicsTransacoes",
                column: "ServicoId",
                principalTable: "SicsServicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
