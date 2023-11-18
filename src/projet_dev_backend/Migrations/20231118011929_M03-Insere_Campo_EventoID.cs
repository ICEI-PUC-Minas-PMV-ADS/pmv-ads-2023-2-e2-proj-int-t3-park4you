using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projet_dev_backend.Migrations
{
    public partial class M03Insere_Campo_EventoID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEvento",
                table: "Endereco_Vaga",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_Vaga_IdEvento",
                table: "Endereco_Vaga",
                column: "IdEvento");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Vaga_Eventos_IdEvento",
                table: "Endereco_Vaga",
                column: "IdEvento",
                principalTable: "Eventos",
                principalColumn: "IdEvento",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Vaga_Eventos_IdEvento",
                table: "Endereco_Vaga");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_Vaga_IdEvento",
                table: "Endereco_Vaga");

            migrationBuilder.DropColumn(
                name: "IdEvento",
                table: "Endereco_Vaga");
        }
    }
}
