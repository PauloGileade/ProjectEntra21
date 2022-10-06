using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectEntra21.Migrations
{
    public partial class modificado2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_CelulaFuncionario_codigo_matricula_funcionario_data",
                table: "CelulaFuncionario");

            migrationBuilder.DropColumn(
                name: "data",
                table: "CelulaFuncionario");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 59, 2, 823, DateTimeKind.Local).AddTicks(4127),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 230, DateTimeKind.Local).AddTicks(4918));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 59, 2, 823, DateTimeKind.Local).AddTicks(3681),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 230, DateTimeKind.Local).AddTicks(4432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 59, 2, 824, DateTimeKind.Local).AddTicks(8162),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 232, DateTimeKind.Local).AddTicks(3377));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_ordem",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 59, 2, 825, DateTimeKind.Local).AddTicks(8851),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 233, DateTimeKind.Local).AddTicks(4405));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 59, 2, 824, DateTimeKind.Local).AddTicks(7801),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 232, DateTimeKind.Local).AddTicks(2796));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 59, 2, 811, DateTimeKind.Local).AddTicks(4463),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 217, DateTimeKind.Local).AddTicks(763));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 59, 2, 804, DateTimeKind.Local).AddTicks(1969),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 211, DateTimeKind.Local).AddTicks(5473));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 59, 2, 821, DateTimeKind.Local).AddTicks(8246),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 228, DateTimeKind.Local).AddTicks(3498));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 59, 2, 821, DateTimeKind.Local).AddTicks(7898),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 228, DateTimeKind.Local).AddTicks(2675));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 59, 2, 820, DateTimeKind.Local).AddTicks(4554),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 226, DateTimeKind.Local).AddTicks(2722));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 59, 2, 820, DateTimeKind.Local).AddTicks(4207),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 226, DateTimeKind.Local).AddTicks(2286));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CelulaFuncionario_codigo_matricula_funcionario_criado_em",
                table: "CelulaFuncionario",
                columns: new[] { "codigo", "matricula_funcionario", "criado_em" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_CelulaFuncionario_codigo_matricula_funcionario_criado_em",
                table: "CelulaFuncionario");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 230, DateTimeKind.Local).AddTicks(4918),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 59, 2, 823, DateTimeKind.Local).AddTicks(4127));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 230, DateTimeKind.Local).AddTicks(4432),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 59, 2, 823, DateTimeKind.Local).AddTicks(3681));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 232, DateTimeKind.Local).AddTicks(3377),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 59, 2, 824, DateTimeKind.Local).AddTicks(8162));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_ordem",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 233, DateTimeKind.Local).AddTicks(4405),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 59, 2, 825, DateTimeKind.Local).AddTicks(8851));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 232, DateTimeKind.Local).AddTicks(2796),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 59, 2, 824, DateTimeKind.Local).AddTicks(7801));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 217, DateTimeKind.Local).AddTicks(763),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 59, 2, 811, DateTimeKind.Local).AddTicks(4463));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 211, DateTimeKind.Local).AddTicks(5473),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 59, 2, 804, DateTimeKind.Local).AddTicks(1969));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 228, DateTimeKind.Local).AddTicks(3498),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 59, 2, 821, DateTimeKind.Local).AddTicks(8246));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 228, DateTimeKind.Local).AddTicks(2675),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 59, 2, 821, DateTimeKind.Local).AddTicks(7898));

            migrationBuilder.AddColumn<DateTime>(
                name: "data",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 229, DateTimeKind.Local).AddTicks(7016));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 226, DateTimeKind.Local).AddTicks(2722),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 59, 2, 820, DateTimeKind.Local).AddTicks(4554));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 226, DateTimeKind.Local).AddTicks(2286),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 59, 2, 820, DateTimeKind.Local).AddTicks(4207));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CelulaFuncionario_codigo_matricula_funcionario_data",
                table: "CelulaFuncionario",
                columns: new[] { "codigo", "matricula_funcionario", "data" });
        }
    }
}
