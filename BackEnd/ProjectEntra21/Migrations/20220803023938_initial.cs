using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectEntra21.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Celula",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo_celula = table.Column<int>(type: "int", nullable: false),
                    status_celula = table.Column<int>(type: "int", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 42, DateTimeKind.Local).AddTicks(7960)),
                    ultima_modificao_em = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 42, DateTimeKind.Local).AddTicks(8279))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Celula", x => x.id);
                    table.UniqueConstraint("AK_Celula_codigo_celula", x => x.codigo_celula);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CelulaFuncionario",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<long>(type: "bigint", nullable: false),
                    codigo_celula = table.Column<int>(type: "int", nullable: false),
                    matricula_funcionario = table.Column<long>(type: "bigint", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 44, DateTimeKind.Local).AddTicks(4563)),
                    ultima_modificao_em = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 44, DateTimeKind.Local).AddTicks(5013))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelulaFuncionario", x => x.id);
                    table.UniqueConstraint("AK_CelulaFuncionario_codigo_matricula_funcionario", x => new { x.codigo, x.matricula_funcionario });
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    matricula = table.Column<long>(type: "bigint", nullable: false),
                    nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    documento = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data_nascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    funcao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nivel_funcionario = table.Column<int>(type: "int", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 32, DateTimeKind.Local).AddTicks(8755)),
                    ultima_modificao_em = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 36, DateTimeKind.Local).AddTicks(6910))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.id);
                    table.UniqueConstraint("AK_Funcionario_matricula", x => x.matricula);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo_produto = table.Column<long>(type: "bigint", nullable: false),
                    nome_produto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tipo_produto = table.Column<int>(type: "int", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 45, DateTimeKind.Local).AddTicks(9352)),
                    ultima_modificao_em = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 45, DateTimeKind.Local).AddTicks(9800))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.id);
                    table.UniqueConstraint("AK_Produto_codigo_produto", x => x.codigo_produto);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ordem",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo_ordem = table.Column<long>(type: "bigint", nullable: false),
                    data_ordem = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 49, DateTimeKind.Local).AddTicks(1706)),
                    EmployeerId = table.Column<long>(type: "bigint", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CellId = table.Column<long>(type: "bigint", nullable: true),
                    quantidade_entrada = table.Column<int>(type: "int", nullable: false),
                    quantidade_saida = table.Column<int>(type: "int", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 48, DateTimeKind.Local).AddTicks(2942)),
                    ultima_modificao_em = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 8, 2, 23, 39, 38, 48, DateTimeKind.Local).AddTicks(3512))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordem", x => x.id);
                    table.UniqueConstraint("AK_Ordem_codigo_ordem", x => x.codigo_ordem);
                    table.ForeignKey(
                        name: "FK_Ordem_Celula_CellId",
                        column: x => x.CellId,
                        principalTable: "Celula",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ordem_Funcionario_EmployeerId",
                        column: x => x.EmployeerId,
                        principalTable: "Funcionario",
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
                name: "IX_Ordem_CellId",
                table: "Ordem",
                column: "CellId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordem_EmployeerId",
                table: "Ordem",
                column: "EmployeerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordem_ProductId",
                table: "Ordem",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CelulaFuncionario");

            migrationBuilder.DropTable(
                name: "Ordem");

            migrationBuilder.DropTable(
                name: "Celula");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
