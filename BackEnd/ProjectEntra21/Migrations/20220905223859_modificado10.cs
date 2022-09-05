using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectEntra21.Migrations
{
    public partial class modificado10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 5, 19, 38, 58, 871, DateTimeKind.Local).AddTicks(380),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 38, DateTimeKind.Local).AddTicks(6770));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 5, 19, 38, 58, 871, DateTimeKind.Local).AddTicks(83),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 38, DateTimeKind.Local).AddTicks(6475));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 5, 19, 38, 58, 872, DateTimeKind.Local).AddTicks(985),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 39, DateTimeKind.Local).AddTicks(6331));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 5, 19, 38, 58, 872, DateTimeKind.Local).AddTicks(659),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 39, DateTimeKind.Local).AddTicks(6076));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 5, 19, 38, 58, 863, DateTimeKind.Local).AddTicks(2826),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 31, DateTimeKind.Local).AddTicks(8542));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 5, 19, 38, 58, 859, DateTimeKind.Local).AddTicks(3499),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 28, DateTimeKind.Local).AddTicks(5635));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 5, 19, 38, 58, 869, DateTimeKind.Local).AddTicks(9371),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 37, DateTimeKind.Local).AddTicks(7161));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 5, 19, 38, 58, 869, DateTimeKind.Local).AddTicks(9091),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 37, DateTimeKind.Local).AddTicks(6899));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 5, 19, 38, 58, 868, DateTimeKind.Local).AddTicks(9147),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 36, DateTimeKind.Local).AddTicks(7647));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 5, 19, 38, 58, 868, DateTimeKind.Local).AddTicks(8864),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 36, DateTimeKind.Local).AddTicks(7349));

            migrationBuilder.CreateTable(
                name: "TotalParcial",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    total_saida = table.Column<int>(type: "int", nullable: false),
                    fase = table.Column<int>(type: "int", nullable: false),
                    CellId = table.Column<long>(type: "bigint", nullable: true),
                    criado_em = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 9, 5, 19, 38, 58, 873, DateTimeKind.Local).AddTicks(3155)),
                    ultima_modificao_em = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 9, 5, 19, 38, 58, 873, DateTimeKind.Local).AddTicks(3450))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalParcial", x => x.id);
                    table.ForeignKey(
                        name: "FK_TotalParcial_Celula_CellId",
                        column: x => x.CellId,
                        principalTable: "Celula",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TotalParcial_CellId",
                table: "TotalParcial",
                column: "CellId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TotalParcial");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 38, DateTimeKind.Local).AddTicks(6770),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 5, 19, 38, 58, 871, DateTimeKind.Local).AddTicks(380));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 38, DateTimeKind.Local).AddTicks(6475),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 5, 19, 38, 58, 871, DateTimeKind.Local).AddTicks(83));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 39, DateTimeKind.Local).AddTicks(6331),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 5, 19, 38, 58, 872, DateTimeKind.Local).AddTicks(985));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 39, DateTimeKind.Local).AddTicks(6076),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 5, 19, 38, 58, 872, DateTimeKind.Local).AddTicks(659));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 31, DateTimeKind.Local).AddTicks(8542),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 5, 19, 38, 58, 863, DateTimeKind.Local).AddTicks(2826));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 28, DateTimeKind.Local).AddTicks(5635),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 5, 19, 38, 58, 859, DateTimeKind.Local).AddTicks(3499));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 37, DateTimeKind.Local).AddTicks(7161),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 5, 19, 38, 58, 869, DateTimeKind.Local).AddTicks(9371));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 37, DateTimeKind.Local).AddTicks(6899),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 5, 19, 38, 58, 869, DateTimeKind.Local).AddTicks(9091));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 36, DateTimeKind.Local).AddTicks(7647),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 5, 19, 38, 58, 868, DateTimeKind.Local).AddTicks(9147));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 36, DateTimeKind.Local).AddTicks(7349),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 5, 19, 38, 58, 868, DateTimeKind.Local).AddTicks(8864));
        }
    }
}
