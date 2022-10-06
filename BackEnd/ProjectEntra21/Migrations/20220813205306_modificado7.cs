using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectEntra21.Migrations
{
    public partial class modificado7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_CelulaFuncionario_codigo_matricula_funcionario_criado_em",
                table: "CelulaFuncionario");

            migrationBuilder.DropColumn(
                name: "codigo_celula",
                table: "CelulaFuncionario");

            migrationBuilder.DropColumn(
                name: "matricula_funcionario",
                table: "CelulaFuncionario");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 78, DateTimeKind.Local).AddTicks(6875),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 15, 43, 3, 461, DateTimeKind.Local).AddTicks(5150));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 78, DateTimeKind.Local).AddTicks(6638),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 15, 43, 3, 461, DateTimeKind.Local).AddTicks(4827));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 79, DateTimeKind.Local).AddTicks(7986),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 15, 43, 3, 462, DateTimeKind.Local).AddTicks(8692));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 79, DateTimeKind.Local).AddTicks(7711),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 15, 43, 3, 462, DateTimeKind.Local).AddTicks(8352));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 69, DateTimeKind.Local).AddTicks(6770),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 15, 43, 3, 451, DateTimeKind.Local).AddTicks(7985));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 64, DateTimeKind.Local).AddTicks(4034),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 15, 43, 3, 446, DateTimeKind.Local).AddTicks(7713));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 77, DateTimeKind.Local).AddTicks(8852),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 15, 43, 3, 460, DateTimeKind.Local).AddTicks(1388));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 77, DateTimeKind.Local).AddTicks(8375),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 15, 43, 3, 460, DateTimeKind.Local).AddTicks(1034));

            migrationBuilder.AddColumn<long>(
                name: "CellId",
                table: "CelulaFuncionario",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EmployeerId",
                table: "CelulaFuncionario",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 76, DateTimeKind.Local).AddTicks(3096),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 15, 43, 3, 458, DateTimeKind.Local).AddTicks(8572));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 76, DateTimeKind.Local).AddTicks(2793),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 15, 43, 3, 458, DateTimeKind.Local).AddTicks(8126));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CelulaFuncionario_codigo",
                table: "CelulaFuncionario",
                column: "codigo");

            migrationBuilder.CreateIndex(
                name: "IX_CelulaFuncionario_CellId",
                table: "CelulaFuncionario",
                column: "CellId");

            migrationBuilder.CreateIndex(
                name: "IX_CelulaFuncionario_EmployeerId",
                table: "CelulaFuncionario",
                column: "EmployeerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CelulaFuncionario_Celula_CellId",
                table: "CelulaFuncionario",
                column: "CellId",
                principalTable: "Celula",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CelulaFuncionario_Funcionario_EmployeerId",
                table: "CelulaFuncionario",
                column: "EmployeerId",
                principalTable: "Funcionario",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CelulaFuncionario_Celula_CellId",
                table: "CelulaFuncionario");

            migrationBuilder.DropForeignKey(
                name: "FK_CelulaFuncionario_Funcionario_EmployeerId",
                table: "CelulaFuncionario");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_CelulaFuncionario_codigo",
                table: "CelulaFuncionario");

            migrationBuilder.DropIndex(
                name: "IX_CelulaFuncionario_CellId",
                table: "CelulaFuncionario");

            migrationBuilder.DropIndex(
                name: "IX_CelulaFuncionario_EmployeerId",
                table: "CelulaFuncionario");

            migrationBuilder.DropColumn(
                name: "CellId",
                table: "CelulaFuncionario");

            migrationBuilder.DropColumn(
                name: "EmployeerId",
                table: "CelulaFuncionario");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 15, 43, 3, 461, DateTimeKind.Local).AddTicks(5150),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 78, DateTimeKind.Local).AddTicks(6875));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 15, 43, 3, 461, DateTimeKind.Local).AddTicks(4827),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 78, DateTimeKind.Local).AddTicks(6638));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 15, 43, 3, 462, DateTimeKind.Local).AddTicks(8692),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 79, DateTimeKind.Local).AddTicks(7986));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 15, 43, 3, 462, DateTimeKind.Local).AddTicks(8352),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 79, DateTimeKind.Local).AddTicks(7711));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 15, 43, 3, 451, DateTimeKind.Local).AddTicks(7985),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 69, DateTimeKind.Local).AddTicks(6770));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 15, 43, 3, 446, DateTimeKind.Local).AddTicks(7713),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 64, DateTimeKind.Local).AddTicks(4034));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 15, 43, 3, 460, DateTimeKind.Local).AddTicks(1388),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 77, DateTimeKind.Local).AddTicks(8852));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 15, 43, 3, 460, DateTimeKind.Local).AddTicks(1034),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 77, DateTimeKind.Local).AddTicks(8375));

            migrationBuilder.AddColumn<int>(
                name: "codigo_celula",
                table: "CelulaFuncionario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "matricula_funcionario",
                table: "CelulaFuncionario",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 15, 43, 3, 458, DateTimeKind.Local).AddTicks(8572),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 76, DateTimeKind.Local).AddTicks(3096));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 13, 15, 43, 3, 458, DateTimeKind.Local).AddTicks(8126),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 13, 17, 53, 6, 76, DateTimeKind.Local).AddTicks(2793));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CelulaFuncionario_codigo_matricula_funcionario_criado_em",
                table: "CelulaFuncionario",
                columns: new[] { "codigo", "matricula_funcionario", "criado_em" });
        }
    }
}
