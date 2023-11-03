using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projet_dev_backend.Migrations
{
    public partial class M02_Endereco_Vaga_Imagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Endereco_Vaga");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Imagem",
                table: "Endereco_Vaga",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
