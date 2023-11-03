using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projet_dev_backend.Migrations
{
    public partial class M02_Endereco_Vaga_Image2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagemNome",
                table: "Endereco_Vaga",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemNome",
                table: "Endereco_Vaga");
        }
    }
}
