using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseImplement.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Авторы",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIO = table.Column<string>(nullable: false),
                    Rabota = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    DateR = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Авторы", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Статьи",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Tema = table.Column<string>(nullable: false),
                    DateCreate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Статьи", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AvtorStatias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AId = table.Column<int>(nullable: false),
                    SId = table.Column<int>(nullable: false),
                    АвторId = table.Column<int>(nullable: false),
                    СтатьяId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvtorStatias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvtorStatias_Авторы_АвторId",
                        column: x => x.АвторId,
                        principalTable: "Авторы",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvtorStatias_Статьи_СтатьяId",
                        column: x => x.СтатьяId,
                        principalTable: "Статьи",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvtorStatias_АвторId",
                table: "AvtorStatias",
                column: "АвторId");

            migrationBuilder.CreateIndex(
                name: "IX_AvtorStatias_СтатьяId",
                table: "AvtorStatias",
                column: "СтатьяId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvtorStatias");

            migrationBuilder.DropTable(
                name: "Авторы");

            migrationBuilder.DropTable(
                name: "Статьи");
        }
    }
}
