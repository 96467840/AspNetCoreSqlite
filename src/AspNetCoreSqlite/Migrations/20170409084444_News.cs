using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreSqlite.Migrations
{
    public partial class News : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Description = table.Column<string>(type: "varchar(1024)", nullable: false, defaultValueSql: "''"),
                    ExternalId = table.Column<string>(type: "varchar(100)", nullable: true, defaultValueSql: "NULL"),
                    Image = table.Column<string>(type: "varchar(255)", nullable: false, defaultValueSql: "''"),
                    InFb = table.Column<bool>(type: "tinyint", nullable: false, defaultValueSql: "1"),
                    InVk = table.Column<bool>(type: "tinyint", nullable: false, defaultValueSql: "1"),
                    InWWW = table.Column<bool>(type: "tinyint", nullable: false, defaultValueSql: "1"),
                    IsBlocked = table.Column<bool>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    Name = table.Column<string>(type: "varchar(512)", nullable: false, defaultValueSql: "''"),
                    Page = table.Column<string>(type: "varchar(255)", nullable: false, defaultValueSql: "''"),
                    Search = table.Column<string>(type: "text", nullable: true),
                    SeoDescription = table.Column<string>(type: "varchar(1024)", nullable: true, defaultValueSql: "''"),
                    SeoKeywords = table.Column<string>(type: "varchar(1024)", nullable: true, defaultValueSql: "''"),
                    SeoTitle = table.Column<string>(type: "varchar(255)", nullable: true, defaultValueSql: "''"),
                    SiteId = table.Column<long>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "News_Date",
                table: "News",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "News_ExternalId",
                table: "News",
                column: "ExternalId");

            migrationBuilder.CreateIndex(
                name: "News_IsBlocked",
                table: "News",
                column: "IsBlocked");

            migrationBuilder.CreateIndex(
                name: "News_Page",
                table: "News",
                column: "Page");

            migrationBuilder.CreateIndex(
                name: "News_SiteId",
                table: "News",
                column: "SiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");
        }
    }
}
