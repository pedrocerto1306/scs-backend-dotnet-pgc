using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sics_webapi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migration010625_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Genero",
                table: "SicsClientes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genero",
                table: "SicsClientes");
        }
    }
}
