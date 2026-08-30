using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorOS.Migrations
{
    /// <inheritdoc />
    public partial class correção : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tellefone",
                table: "Clientes",
                newName: "Telefone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Clientes",
                newName: "Tellefone");
        }
    }
}
