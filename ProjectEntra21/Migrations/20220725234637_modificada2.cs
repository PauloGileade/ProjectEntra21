using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectEntra21.Migrations
{
    public partial class modificada2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "codigo_celula",
                table: "Funcionario",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "codigo_celula",
                table: "Funcionario");
        }
    }
}
