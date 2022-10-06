using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectEntra21.Migrations
{
    public partial class modificado9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 38, DateTimeKind.Local).AddTicks(6770),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 726, DateTimeKind.Local).AddTicks(8572));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 38, DateTimeKind.Local).AddTicks(6475),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 726, DateTimeKind.Local).AddTicks(8327));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 39, DateTimeKind.Local).AddTicks(6331),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 727, DateTimeKind.Local).AddTicks(8776));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 39, DateTimeKind.Local).AddTicks(6076),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 727, DateTimeKind.Local).AddTicks(8467));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 31, DateTimeKind.Local).AddTicks(8542),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 719, DateTimeKind.Local).AddTicks(9121));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 28, DateTimeKind.Local).AddTicks(5635),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 716, DateTimeKind.Local).AddTicks(1029));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 37, DateTimeKind.Local).AddTicks(7161),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 726, DateTimeKind.Local).AddTicks(1771));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 37, DateTimeKind.Local).AddTicks(6899),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 726, DateTimeKind.Local).AddTicks(1449));

            migrationBuilder.AddColumn<int>(
                name: "Fase",
                table: "CelulaFuncionario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 36, DateTimeKind.Local).AddTicks(7647),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 725, DateTimeKind.Local).AddTicks(1696));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 36, DateTimeKind.Local).AddTicks(7349),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 725, DateTimeKind.Local).AddTicks(1418));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fase",
                table: "CelulaFuncionario");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 726, DateTimeKind.Local).AddTicks(8572),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 38, DateTimeKind.Local).AddTicks(6770));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 726, DateTimeKind.Local).AddTicks(8327),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 38, DateTimeKind.Local).AddTicks(6475));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 727, DateTimeKind.Local).AddTicks(8776),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 39, DateTimeKind.Local).AddTicks(6331));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 727, DateTimeKind.Local).AddTicks(8467),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 39, DateTimeKind.Local).AddTicks(6076));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 719, DateTimeKind.Local).AddTicks(9121),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 31, DateTimeKind.Local).AddTicks(8542));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 716, DateTimeKind.Local).AddTicks(1029),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 28, DateTimeKind.Local).AddTicks(5635));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 726, DateTimeKind.Local).AddTicks(1771),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 37, DateTimeKind.Local).AddTicks(7161));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 726, DateTimeKind.Local).AddTicks(1449),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 37, DateTimeKind.Local).AddTicks(6899));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 725, DateTimeKind.Local).AddTicks(1696),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 36, DateTimeKind.Local).AddTicks(7647));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 725, DateTimeKind.Local).AddTicks(1418),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 3, 19, 19, 2, 36, DateTimeKind.Local).AddTicks(7349));
        }
    }
}
