using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projet_dev_backend.Migrations
{
    public partial class M03_TableEvento1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventoIdEvento",
                table: "Endereco_Vaga",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    IdEvento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEvento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GestorId = table.Column<int>(type: "int", nullable: false),
                    Endereco_VagaId = table.Column<int>(type: "int", nullable: false),
                    ImagemEvento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.IdEvento);
                    table.ForeignKey(
                        name: "FK_Eventos_Endereco_Vaga_Endereco_VagaId",
                        column: x => x.Endereco_VagaId,
                        principalTable: "Endereco_Vaga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_Vaga_EventoIdEvento",
                table: "Endereco_Vaga",
                column: "EventoIdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_Endereco_VagaId",
                table: "Eventos",
                column: "Endereco_VagaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Vaga_Eventos_EventoIdEvento",
                table: "Endereco_Vaga",
                column: "EventoIdEvento",
                principalTable: "Eventos",
                principalColumn: "IdEvento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Vaga_Eventos_EventoIdEvento",
                table: "Endereco_Vaga");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_Vaga_EventoIdEvento",
                table: "Endereco_Vaga");

            migrationBuilder.DropColumn(
                name: "EventoIdEvento",
                table: "Endereco_Vaga");
        }
    }
}
