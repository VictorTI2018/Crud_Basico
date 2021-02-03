using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Crud.Infra.Data.Migrations
{
    public partial class CreateTableLivro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategoria = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Autor = table.Column<string>(nullable: true),
                    Editora = table.Column<string>(nullable: true),
                    DataPublicacao = table.Column<DateTime>(nullable: false),
                    ISBN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livro_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livro_IdCategoria",
                table: "Livro",
                column: "IdCategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livro");
        }
    }
}
