using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sics_webapi.Data.DataMigrationsLocalhost
{
    /// <inheritdoc />
    public partial class MigrationPessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Cancelado",
                table: "SicsTransacoes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MotivoCancelamento",
                table: "SicsTransacoes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Contato",
                table: "SicsPrestadores",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Documento",
                table: "SicsPrestadores",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "SicsPrestadores",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Genero",
                table: "SicsPrestadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IdentidadeConfirmada",
                table: "SicsPrestadores",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LinkImagem",
                table: "SicsPrestadores",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Nota",
                table: "SicsPrestadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Documento",
                table: "SicsClientes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LinkImagem",
                table: "SicsClientes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Nota",
                table: "SicsClientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SicsAvaliacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PrestadorID = table.Column<int>(type: "int", nullable: false),
                    ServicoID = table.Column<int>(type: "int", nullable: false),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: false),
                    Avaliacao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LinksImagens = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SicsAvaliacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SicsAvaliacoes_SicsClientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "SicsClientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SicsAvaliacoes_SicsPrestadores_PrestadorID",
                        column: x => x.PrestadorID,
                        principalTable: "SicsPrestadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SicsAvaliacoes_SicsServicos_ServicoID",
                        column: x => x.ServicoID,
                        principalTable: "SicsServicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SicsAvaliacoes");

            migrationBuilder.DropColumn(
                name: "Cancelado",
                table: "SicsTransacoes");

            migrationBuilder.DropColumn(
                name: "MotivoCancelamento",
                table: "SicsTransacoes");

            migrationBuilder.DropColumn(
                name: "Documento",
                table: "SicsPrestadores");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "SicsPrestadores");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "SicsPrestadores");

            migrationBuilder.DropColumn(
                name: "IdentidadeConfirmada",
                table: "SicsPrestadores");

            migrationBuilder.DropColumn(
                name: "LinkImagem",
                table: "SicsPrestadores");

            migrationBuilder.DropColumn(
                name: "Nota",
                table: "SicsPrestadores");

            migrationBuilder.DropColumn(
                name: "Documento",
                table: "SicsClientes");

            migrationBuilder.DropColumn(
                name: "LinkImagem",
                table: "SicsClientes");

            migrationBuilder.DropColumn(
                name: "Nota",
                table: "SicsClientes");

            migrationBuilder.UpdateData(
                table: "SicsPrestadores",
                keyColumn: "Contato",
                keyValue: null,
                column: "Contato",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Contato",
                table: "SicsPrestadores",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
