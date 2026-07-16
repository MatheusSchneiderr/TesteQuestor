using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TesteQuestor.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bancos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_banco = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    codigo_banco = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    percentual_juros = table.Column<decimal>(type: "numeric(9,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bancos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "boletos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_pagador = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    cpf_cnpj_pagador = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    nome_beneficiario = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    cpf_cnpj_beneficiario = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    valor = table.Column<decimal>(type: "numeric(14,2)", nullable: false),
                    data_vencimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    observacao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    banco_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boletos", x => x.id);
                    table.ForeignKey(
                        name: "FK_boletos_bancos_banco_id",
                        column: x => x.banco_id,
                        principalTable: "bancos",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_bancos_codigo_banco",
                table: "bancos",
                column: "codigo_banco",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_boletos_banco_id",
                table: "boletos",
                column: "banco_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "boletos");

            migrationBuilder.DropTable(
                name: "bancos");
        }
    }
}
