using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectEntra21.Migrations
{
    public partial class modificado4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 21, 55, 55, 315, DateTimeKind.Local).AddTicks(2862),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 17, 11, 51, 841, DateTimeKind.Local).AddTicks(2054));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 21, 55, 55, 315, DateTimeKind.Local).AddTicks(2578),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 17, 11, 51, 841, DateTimeKind.Local).AddTicks(1509));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 21, 55, 55, 317, DateTimeKind.Local).AddTicks(6018),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 17, 11, 51, 842, DateTimeKind.Local).AddTicks(8696));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_ordem",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 17, 11, 51, 843, DateTimeKind.Local).AddTicks(8381));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 21, 55, 55, 317, DateTimeKind.Local).AddTicks(4941),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 17, 11, 51, 842, DateTimeKind.Local).AddTicks(8303));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 21, 55, 55, 304, DateTimeKind.Local).AddTicks(4755),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 17, 11, 51, 829, DateTimeKind.Local).AddTicks(7146));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 21, 55, 55, 298, DateTimeKind.Local).AddTicks(8060),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 17, 11, 51, 824, DateTimeKind.Local).AddTicks(8904));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 21, 55, 55, 314, DateTimeKind.Local).AddTicks(435),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 17, 11, 51, 839, DateTimeKind.Local).AddTicks(6676));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 21, 55, 55, 314, DateTimeKind.Local).AddTicks(40),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 17, 11, 51, 839, DateTimeKind.Local).AddTicks(6336));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 21, 55, 55, 312, DateTimeKind.Local).AddTicks(4893),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 17, 11, 51, 838, DateTimeKind.Local).AddTicks(2418));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 21, 55, 55, 312, DateTimeKind.Local).AddTicks(4120),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 17, 11, 51, 838, DateTimeKind.Local).AddTicks(1953));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 17, 11, 51, 841, DateTimeKind.Local).AddTicks(2054),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 21, 55, 55, 315, DateTimeKind.Local).AddTicks(2862));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 17, 11, 51, 841, DateTimeKind.Local).AddTicks(1509),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 21, 55, 55, 315, DateTimeKind.Local).AddTicks(2578));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 17, 11, 51, 842, DateTimeKind.Local).AddTicks(8696),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 21, 55, 55, 317, DateTimeKind.Local).AddTicks(6018));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_ordem",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 17, 11, 51, 843, DateTimeKind.Local).AddTicks(8381),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 17, 11, 51, 842, DateTimeKind.Local).AddTicks(8303),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 21, 55, 55, 317, DateTimeKind.Local).AddTicks(4941));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 17, 11, 51, 829, DateTimeKind.Local).AddTicks(7146),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 21, 55, 55, 304, DateTimeKind.Local).AddTicks(4755));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 17, 11, 51, 824, DateTimeKind.Local).AddTicks(8904),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 21, 55, 55, 298, DateTimeKind.Local).AddTicks(8060));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 17, 11, 51, 839, DateTimeKind.Local).AddTicks(6676),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 21, 55, 55, 314, DateTimeKind.Local).AddTicks(435));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 17, 11, 51, 839, DateTimeKind.Local).AddTicks(6336),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 21, 55, 55, 314, DateTimeKind.Local).AddTicks(40));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 17, 11, 51, 838, DateTimeKind.Local).AddTicks(2418),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 21, 55, 55, 312, DateTimeKind.Local).AddTicks(4893));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 17, 11, 51, 838, DateTimeKind.Local).AddTicks(1953),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 21, 55, 55, 312, DateTimeKind.Local).AddTicks(4120));
        }
    }
}
