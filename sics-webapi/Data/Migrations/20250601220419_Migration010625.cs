using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sics_webapi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migration010625 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkImagem",
                table: "SicsServicos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkImagem",
                table: "SicsServicos");
        }
    }
}
