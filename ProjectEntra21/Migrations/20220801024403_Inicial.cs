using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectEntra21.Migrations
{
    public partial class Inicial : Migration
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
                    criado_em = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 7, 31, 23, 44, 2, 870, DateTimeKind.Local).AddTicks(8236)),
                    ultima_modificao_em = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 7, 31, 23, 44, 2, 870, DateTimeKind.Local).AddTicks(8556))
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
                    codigo = table.Column<int>(type: "int", nullable: false),
                    CellId = table.Column<long>(type: "bigint", nullable: true),
                    criado_em = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 7, 31, 23, 44, 2, 872, DateTimeKind.Local).AddTicks(4937)),
                    ultima_modificao_em = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 7, 31, 23, 44, 2, 872, DateTimeKind.Local).AddTicks(5414))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelulaFuncionario", x => x.id);
                    table.UniqueConstraint("AK_CelulaFuncionario_codigo", x => x.codigo);
                    table.ForeignKey(
                        name: "FK_CelulaFuncionario_Celula_CellId",
                        column: x => x.CellId,
                        principalTable: "Celula",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                    CellEmployeerId = table.Column<long>(type: "bigint", nullable: true),
                    criado_em = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 7, 31, 23, 44, 2, 859, DateTimeKind.Local).AddTicks(8767)),
                    ultima_modificao_em = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 7, 31, 23, 44, 2, 864, DateTimeKind.Local).AddTicks(84))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.id);
                    table.UniqueConstraint("AK_Funcionario_matricula", x => x.matricula);
                    table.ForeignKey(
                        name: "FK_Funcionario_CelulaFuncionario_CellEmployeerId",
                        column: x => x.CellEmployeerId,
                        principalTable: "CelulaFuncionario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                    EmployeerId = table.Column<long>(type: "bigint", nullable: true),
                    criado_em = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 7, 31, 23, 44, 2, 873, DateTimeKind.Local).AddTicks(3257)),
                    ultima_modificao_em = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 7, 31, 23, 44, 2, 873, DateTimeKind.Local).AddTicks(3838))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.id);
                    table.UniqueConstraint("AK_Produto_codigo_produto", x => x.codigo_produto);
                    table.ForeignKey(
                        name: "FK_Produto_Funcionario_EmployeerId",
                        column: x => x.EmployeerId,
                        principalTable: "Funcionario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ordem",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo_ordem = table.Column<long>(type: "bigint", nullable: false),
                    data_ordem = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 7, 31, 23, 44, 2, 875, DateTimeKind.Local).AddTicks(4804)),
                    EmployeerId = table.Column<long>(type: "bigint", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CellId = table.Column<long>(type: "bigint", nullable: true),
                    quantidade_entrada = table.Column<int>(type: "int", nullable: false),
                    quantidade_saida = table.Column<int>(type: "int", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 7, 31, 23, 44, 2, 874, DateTimeKind.Local).AddTicks(6945)),
                    ultima_modificao_em = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 7, 31, 23, 44, 2, 874, DateTimeKind.Local).AddTicks(7276))
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
                name: "IX_CelulaFuncionario_CellId",
                table: "CelulaFuncionario",
                column: "CellId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_CellEmployeerId",
                table: "Funcionario",
                column: "CellEmployeerId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Produto_EmployeerId",
                table: "Produto",
                column: "EmployeerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ordem");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "CelulaFuncionario");

            migrationBuilder.DropTable(
                name: "Celula");
        }
    }
}
