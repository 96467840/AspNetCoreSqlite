using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreSqlite.Migrations
{
    public partial class Languages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExternalId = table.Column<string>(type: "varchar(100)", nullable: true, defaultValueSql: "NULL"),
                    IsBlocked = table.Column<bool>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    IsDefault = table.Column<bool>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    Json = table.Column<string>(type: "text", nullable: true),
                    Lang = table.Column<string>(type: "varchar(17)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: true, defaultValueSql: "NULL"),
                    SiteId = table.Column<long>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "Languages_ExternalId",
                table: "Languages",
                column: "ExternalId");

            migrationBuilder.CreateIndex(
                name: "Languages_IsBlocked",
                table: "Languages",
                column: "IsBlocked");

            migrationBuilder.CreateIndex(
                name: "Languages_IsDefault",
                table: "Languages",
                column: "IsDefault");

            migrationBuilder.CreateIndex(
                name: "Languages_Lang",
                table: "Languages",
                column: "Lang");

            migrationBuilder.CreateIndex(
                name: "Languages_SiteId",
                table: "Languages",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "Languages_SiteLang",
                table: "Languages",
                columns: new[] { "SiteId", "Lang" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
