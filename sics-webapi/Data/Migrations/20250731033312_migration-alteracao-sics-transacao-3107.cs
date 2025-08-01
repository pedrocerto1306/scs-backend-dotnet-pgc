using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sics_webapi.Data.Migrations
{
    /// <inheritdoc />
    public partial class migrationalteracaosicstransacao3107 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "SicsTransacoes",
                newName: "Observacoes");

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "SicsTransacoes",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "SicsTransacoes");

            migrationBuilder.RenameColumn(
                name: "Observacoes",
                table: "SicsTransacoes",
                newName: "Status");
        }
    }
}
