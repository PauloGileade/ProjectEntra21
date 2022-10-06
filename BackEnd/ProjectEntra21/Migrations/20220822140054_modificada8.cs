using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectEntra21.Migrations
{
    public partial class modificada8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 726, DateTimeKind.Local).AddTicks(8572),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 78, DateTimeKind.Local).AddTicks(6875));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 726, DateTimeKind.Local).AddTicks(8327),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 78, DateTimeKind.Local).AddTicks(6638));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 727, DateTimeKind.Local).AddTicks(8776),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 79, DateTimeKind.Local).AddTicks(7986));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 727, DateTimeKind.Local).AddTicks(8467),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 79, DateTimeKind.Local).AddTicks(7711));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 719, DateTimeKind.Local).AddTicks(9121),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 69, DateTimeKind.Local).AddTicks(6770));

            migrationBuilder.AlterColumn<string>(
                name: "data_nascimento",
                table: "Funcionario",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 716, DateTimeKind.Local).AddTicks(1029),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 64, DateTimeKind.Local).AddTicks(4034));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 726, DateTimeKind.Local).AddTicks(1771),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 77, DateTimeKind.Local).AddTicks(8852));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 726, DateTimeKind.Local).AddTicks(1449),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 77, DateTimeKind.Local).AddTicks(8375));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 725, DateTimeKind.Local).AddTicks(1696),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 76, DateTimeKind.Local).AddTicks(3096));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 725, DateTimeKind.Local).AddTicks(1418),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 76, DateTimeKind.Local).AddTicks(2793));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 78, DateTimeKind.Local).AddTicks(6875),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 726, DateTimeKind.Local).AddTicks(8572));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 78, DateTimeKind.Local).AddTicks(6638),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 726, DateTimeKind.Local).AddTicks(8327));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 79, DateTimeKind.Local).AddTicks(7986),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 727, DateTimeKind.Local).AddTicks(8776));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 79, DateTimeKind.Local).AddTicks(7711),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 727, DateTimeKind.Local).AddTicks(8467));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 69, DateTimeKind.Local).AddTicks(6770),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 719, DateTimeKind.Local).AddTicks(9121));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_nascimento",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 64, DateTimeKind.Local).AddTicks(4034),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 716, DateTimeKind.Local).AddTicks(1029));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 77, DateTimeKind.Local).AddTicks(8852),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 726, DateTimeKind.Local).AddTicks(1771));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 77, DateTimeKind.Local).AddTicks(8375),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 726, DateTimeKind.Local).AddTicks(1449));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 76, DateTimeKind.Local).AddTicks(3096),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 725, DateTimeKind.Local).AddTicks(1696));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 76, DateTimeKind.Local).AddTicks(2793),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 22, 11, 0, 53, 725, DateTimeKind.Local).AddTicks(1418));
        }
    }
}
