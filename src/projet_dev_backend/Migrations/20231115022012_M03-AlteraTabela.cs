using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projet_dev_backend.Migrations
{
    public partial class M03AlteraTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Vaga_Eventos_EventoIdEvento",
                table: "Endereco_Vaga");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Endereco_Vaga_Endereco_VagaId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_Endereco_VagaId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_Vaga_EventoIdEvento",
                table: "Endereco_Vaga");

            migrationBuilder.DropColumn(
                name: "Endereco_VagaId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "EventoIdEvento",
                table: "Endereco_Vaga");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Endereco_VagaId",
                table: "Eventos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventoIdEvento",
                table: "Endereco_Vaga",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_Endereco_VagaId",
                table: "Eventos",
                column: "Endereco_VagaId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_Vaga_EventoIdEvento",
                table: "Endereco_Vaga",
                column: "EventoIdEvento");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Vaga_Eventos_EventoIdEvento",
                table: "Endereco_Vaga",
                column: "EventoIdEvento",
                principalTable: "Eventos",
                principalColumn: "IdEvento");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Endereco_Vaga_Endereco_VagaId",
                table: "Eventos",
                column: "Endereco_VagaId",
                principalTable: "Endereco_Vaga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
