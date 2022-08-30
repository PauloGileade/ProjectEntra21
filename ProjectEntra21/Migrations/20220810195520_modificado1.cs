using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectEntra21.Migrations
{
    public partial class modificado1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_CelulaFuncionario_codigo_matricula_funcionario",
                table: "CelulaFuncionario");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 230, DateTimeKind.Local).AddTicks(4918),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 45, DateTimeKind.Local).AddTicks(9800));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 230, DateTimeKind.Local).AddTicks(4432),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 45, DateTimeKind.Local).AddTicks(9352));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 217, DateTimeKind.Local).AddTicks(763),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 36, DateTimeKind.Local).AddTicks(6910));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 211, DateTimeKind.Local).AddTicks(5473),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 32, DateTimeKind.Local).AddTicks(8755));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 228, DateTimeKind.Local).AddTicks(3498),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 44, DateTimeKind.Local).AddTicks(5013));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 228, DateTimeKind.Local).AddTicks(2675),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 44, DateTimeKind.Local).AddTicks(4563));

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
                oldDefaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 42, DateTimeKind.Local).AddTicks(8279));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 226, DateTimeKind.Local).AddTicks(2286),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 42, DateTimeKind.Local).AddTicks(7960));

            migrationBuilder.AlterColumn<long>(
                name: "codigo_celula",
                table: "Celula",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CelulaFuncionario_codigo_matricula_funcionario_data",
                table: "CelulaFuncionario",
                columns: new[] { "codigo", "matricula_funcionario", "data" });

            migrationBuilder.CreateTable(
                name: "Ordem",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo_ordem = table.Column<long>(type: "bigint", nullable: false),
                    data_ordem = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 233, DateTimeKind.Local).AddTicks(4405)),
                    CellEmployeerId = table.Column<long>(type: "bigint", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    quantidade_entrada = table.Column<int>(type: "int", nullable: false),
                    quantidade_saida = table.Column<int>(type: "int", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 232, DateTimeKind.Local).AddTicks(2796)),
                    ultima_modificao_em = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 232, DateTimeKind.Local).AddTicks(3377))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordem", x => x.id);
                    table.UniqueConstraint("AK_Ordem_codigo_ordem", x => x.codigo_ordem);
                    table.ForeignKey(
                        name: "FK_Ordem_CelulaFuncionario_CellEmployeerId",
                        column: x => x.CellEmployeerId,
                        principalTable: "CelulaFuncionario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ordem_Produto_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Ordem_CellEmployeerId",
                table: "Ordem",
                column: "CellEmployeerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordem_ProductId",
                table: "Ordem",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ordem");

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
                defaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 45, DateTimeKind.Local).AddTicks(9800),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 230, DateTimeKind.Local).AddTicks(4918));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 45, DateTimeKind.Local).AddTicks(9352),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 230, DateTimeKind.Local).AddTicks(4432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 36, DateTimeKind.Local).AddTicks(6910),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 217, DateTimeKind.Local).AddTicks(763));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 32, DateTimeKind.Local).AddTicks(8755),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 211, DateTimeKind.Local).AddTicks(5473));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 44, DateTimeKind.Local).AddTicks(5013),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 228, DateTimeKind.Local).AddTicks(3498));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 44, DateTimeKind.Local).AddTicks(4563),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 228, DateTimeKind.Local).AddTicks(2675));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 42, DateTimeKind.Local).AddTicks(8279),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 226, DateTimeKind.Local).AddTicks(2722));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 42, DateTimeKind.Local).AddTicks(7960),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 10, 16, 55, 20, 226, DateTimeKind.Local).AddTicks(2286));

            migrationBuilder.AlterColumn<int>(
                name: "codigo_celula",
                table: "Celula",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CelulaFuncionario_codigo_matricula_funcionario",
                table: "CelulaFuncionario",
                columns: new[] { "codigo", "matricula_funcionario" });
        }
    }
}
