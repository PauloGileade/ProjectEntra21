using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectEntra21.Migrations
{
    public partial class modificado11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 0, 45, 39, 803, DateTimeKind.Local).AddTicks(632),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 6, 0, 38, 53, 860, DateTimeKind.Local).AddTicks(9371));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 0, 45, 39, 803, DateTimeKind.Local).AddTicks(381),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 6, 0, 38, 53, 860, DateTimeKind.Local).AddTicks(8956));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 0, 45, 39, 804, DateTimeKind.Local).AddTicks(278),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 6, 0, 38, 53, 862, DateTimeKind.Local).AddTicks(1333));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 0, 45, 39, 803, DateTimeKind.Local).AddTicks(9976),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 6, 0, 38, 53, 862, DateTimeKind.Local).AddTicks(1014));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 0, 45, 39, 796, DateTimeKind.Local).AddTicks(3915),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 6, 0, 38, 53, 850, DateTimeKind.Local).AddTicks(4471));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 0, 45, 39, 791, DateTimeKind.Local).AddTicks(7936),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 6, 0, 38, 53, 846, DateTimeKind.Local).AddTicks(3932));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 0, 45, 39, 802, DateTimeKind.Local).AddTicks(1194),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 6, 0, 38, 53, 859, DateTimeKind.Local).AddTicks(1596));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 0, 45, 39, 802, DateTimeKind.Local).AddTicks(908),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 6, 0, 38, 53, 859, DateTimeKind.Local).AddTicks(1205));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 0, 45, 39, 801, DateTimeKind.Local).AddTicks(2001),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 6, 0, 38, 53, 857, DateTimeKind.Local).AddTicks(8930));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 0, 45, 39, 801, DateTimeKind.Local).AddTicks(1773),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 6, 0, 38, 53, 857, DateTimeKind.Local).AddTicks(8503));

            migrationBuilder.CreateTable(
                name: "TotalParcial",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    total_saida = table.Column<int>(type: "int", nullable: false),
                    fase = table.Column<int>(type: "int", nullable: false),
                    CellId = table.Column<long>(type: "bigint", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    criado_em = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 9, 6, 0, 45, 39, 805, DateTimeKind.Local).AddTicks(408)),
                    ultima_modificao_em = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 9, 6, 0, 45, 39, 805, DateTimeKind.Local).AddTicks(665))
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
                    table.ForeignKey(
                        name: "FK_TotalParcial_Produto_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TotalParcial_CellId",
                table: "TotalParcial",
                column: "CellId");

            migrationBuilder.CreateIndex(
                name: "IX_TotalParcial_ProductId",
                table: "TotalParcial",
                column: "ProductId");
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
                defaultValue: new DateTime(2022, 9, 6, 0, 38, 53, 860, DateTimeKind.Local).AddTicks(9371),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 6, 0, 45, 39, 803, DateTimeKind.Local).AddTicks(632));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Produto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 0, 38, 53, 860, DateTimeKind.Local).AddTicks(8956),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 6, 0, 45, 39, 803, DateTimeKind.Local).AddTicks(381));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 0, 38, 53, 862, DateTimeKind.Local).AddTicks(1333),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 6, 0, 45, 39, 804, DateTimeKind.Local).AddTicks(278));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Ordem",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 0, 38, 53, 862, DateTimeKind.Local).AddTicks(1014),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 6, 0, 45, 39, 803, DateTimeKind.Local).AddTicks(9976));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 0, 38, 53, 850, DateTimeKind.Local).AddTicks(4471),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 6, 0, 45, 39, 796, DateTimeKind.Local).AddTicks(3915));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Funcionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 0, 38, 53, 846, DateTimeKind.Local).AddTicks(3932),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 6, 0, 45, 39, 791, DateTimeKind.Local).AddTicks(7936));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 0, 38, 53, 859, DateTimeKind.Local).AddTicks(1596),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 6, 0, 45, 39, 802, DateTimeKind.Local).AddTicks(1194));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "CelulaFuncionario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 0, 38, 53, 859, DateTimeKind.Local).AddTicks(1205),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 6, 0, 45, 39, 802, DateTimeKind.Local).AddTicks(908));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ultima_modificao_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 0, 38, 53, 857, DateTimeKind.Local).AddTicks(8930),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 6, 0, 45, 39, 801, DateTimeKind.Local).AddTicks(2001));

            migrationBuilder.AlterColumn<DateTime>(
                name: "criado_em",
                table: "Celula",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 0, 38, 53, 857, DateTimeKind.Local).AddTicks(8503),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 9, 6, 0, 45, 39, 801, DateTimeKind.Local).AddTicks(1773));
        }
    }
}
