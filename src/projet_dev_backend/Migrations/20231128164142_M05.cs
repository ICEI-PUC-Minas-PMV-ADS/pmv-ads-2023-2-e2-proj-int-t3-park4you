using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projet_dev_backend.Migrations
{
    public partial class M05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gestor",
                columns: table => new
                {
                    GestorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gestor", x => x.GestorId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_GestorId",
                table: "Eventos",
                column: "GestorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Gestor_GestorId",
                table: "Eventos",
                column: "GestorId",
                principalTable: "Gestor",
                principalColumn: "GestorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Gestor_GestorId",
                table: "Eventos");

            migrationBuilder.DropTable(
                name: "Gestor");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_GestorId",
                table: "Eventos");
        }
    }
}
