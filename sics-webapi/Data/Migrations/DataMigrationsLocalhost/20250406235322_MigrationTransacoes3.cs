using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sics_webapi.Data.DataMigrationsLocalhost
{
    /// <inheritdoc />
    public partial class MigrationTransacoes3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "efetivado",
                table: "SicsTransacoes",
                newName: "Efetivado");

            migrationBuilder.RenameColumn(
                name: "data",
                table: "SicsTransacoes",
                newName: "Data");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Efetivado",
                table: "SicsTransacoes",
                newName: "efetivado");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "SicsTransacoes",
                newName: "data");
        }
    }
}
