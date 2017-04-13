using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreSqlite.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BodyCSS = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CSS = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "varchar(1024)", nullable: false, defaultValueSql: "''"),
                    ExternalId = table.Column<string>(type: "varchar(100)", nullable: true, defaultValueSql: "NULL"),
                    ImageLogo = table.Column<string>(type: "varchar(255)", nullable: true, defaultValueSql: "NULL"),
                    ImageLogoRight = table.Column<string>(type: "varchar(255)", nullable: true, defaultValueSql: "NULL"),
                    ImageOnMain = table.Column<string>(type: "varchar(255)", nullable: true, defaultValueSql: "NULL"),
                    InFb = table.Column<bool>(type: "tinyint", nullable: false, defaultValueSql: "1"),
                    InVk = table.Column<bool>(type: "tinyint", nullable: false, defaultValueSql: "1"),
                    InWWW = table.Column<bool>(type: "tinyint", nullable: false, defaultValueSql: "1"),
                    IsBlocked = table.Column<bool>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    IsSeparatedFaqs = table.Column<bool>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    IsShowOnMain = table.Column<bool>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    Lang = table.Column<string>(type: "varchar(17)", nullable: true, defaultValueSql: "NULL"),
                    Layout = table.Column<string>(type: "varchar(128)", nullable: true, defaultValueSql: "NULL"),
                    MenuName = table.Column<string>(type: "varchar(255)", nullable: false, defaultValueSql: "''"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false, defaultValueSql: "''"),
                    Page = table.Column<string>(type: "varchar(255)", nullable: false, defaultValueSql: "''"),
                    ParentId = table.Column<long>(nullable: true, defaultValueSql: "NULL")
                        .Annotation("Sqlite:Autoincrement", true),
                    Priority = table.Column<int>(type: "SMALLINT", nullable: false, defaultValueSql: "0")
                        .Annotation("Sqlite:Autoincrement", true),
                    Search = table.Column<string>(type: "text", nullable: true),
                    SeoDescription = table.Column<string>(type: "varchar(1024)", nullable: true, defaultValueSql: "''"),
                    SeoKeywords = table.Column<string>(type: "varchar(1024)", nullable: true, defaultValueSql: "''"),
                    SeoTitle = table.Column<string>(type: "varchar(255)", nullable: true, defaultValueSql: "''"),
                    ShortContent = table.Column<string>(type: "text", nullable: true),
                    ShowInBottom = table.Column<bool>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    ShowInMenu = table.Column<bool>(type: "tinyint", nullable: false, defaultValueSql: "1"),
                    ShowInTop = table.Column<bool>(type: "tinyint", nullable: false, defaultValueSql: "1"),
                    ShowLeftMenu = table.Column<bool>(type: "tinyint", nullable: false, defaultValueSql: "1"),
                    ShowNews = table.Column<bool>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    ShowSubmenu = table.Column<bool>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    SiteId = table.Column<long>(nullable: false),
                    URL = table.Column<string>(type: "varchar(512)", nullable: false, defaultValueSql: "''")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Menus_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Contacts = table.Column<string>(type: "text", nullable: true),
                    ContactsShort = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Description = table.Column<string>(type: "text", nullable: true),
                    E404PageId = table.Column<long>(nullable: true, defaultValueSql: "NULL")
                        .Annotation("Sqlite:Autoincrement", true),
                    ExternalId = table.Column<string>(type: "varchar(100)", nullable: true, defaultValueSql: "NULL"),
                    Favicon = table.Column<string>(type: "varchar(255)", nullable: true, defaultValueSql: "NULL"),
                    FbAppId = table.Column<string>(type: "varchar(255)", nullable: true, defaultValueSql: "NULL"),
                    FbAppSecret = table.Column<string>(type: "varchar(255)", nullable: true, defaultValueSql: "NULL"),
                    FbNamespace = table.Column<string>(type: "varchar(255)", nullable: true, defaultValueSql: "NULL"),
                    GoogleanAlytics = table.Column<string>(type: "varchar(128)", nullable: true),
                    Hosts = table.Column<string>(type: "text", nullable: true),
                    IsDefault = table.Column<bool>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    IsDeleted = table.Column<bool>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    IsVisible = table.Column<bool>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    Layout = table.Column<string>(type: "varchar(128)", nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", nullable: true),
                    OrderPageId = table.Column<long>(nullable: true, defaultValueSql: "NULL")
                        .Annotation("Sqlite:Autoincrement", true),
                    RecaptchaSecretKey = table.Column<string>(type: "varchar(255)", nullable: true, defaultValueSql: "NULL"),
                    RecaptchaSiteKey = table.Column<string>(type: "varchar(255)", nullable: true, defaultValueSql: "NULL"),
                    Share42 = table.Column<bool>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    Template = table.Column<string>(type: "varchar(50)", nullable: true, defaultValueSql: "NULL"),
                    VkAppId = table.Column<string>(type: "varchar(255)", nullable: true, defaultValueSql: "NULL"),
                    VkAppSecret = table.Column<string>(type: "varchar(255)", nullable: true, defaultValueSql: "NULL"),
                    YandexMetrika = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    FbExpires = table.Column<string>(type: "datetime", nullable: true),
                    FbId = table.Column<string>(type: "varchar(255)", nullable: true),
                    FbToken = table.Column<string>(type: "varchar(255)", nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", nullable: true),
                    Password = table.Column<string>(type: "varchar(255)", nullable: false),
                    Token = table.Column<string>(type: "varchar(255)", nullable: true),
                    VkExpires = table.Column<string>(type: "datetime", nullable: true),
                    VkId = table.Column<string>(type: "varchar(255)", nullable: true),
                    VkToken = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSites",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    SiteId = table.Column<long>(nullable: false),
                    IsAdmin = table.Column<bool>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    Rights = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sqlite_autoindex_UserSites_1", x => new { x.UserId, x.SiteId });
                    table.ForeignKey(
                        name: "FK_UserSites_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "Menus_ExternalId",
                table: "Menus",
                column: "ExternalId");

            migrationBuilder.CreateIndex(
                name: "Menus_IsBlocked",
                table: "Menus",
                column: "IsBlocked");

            migrationBuilder.CreateIndex(
                name: "Menus_IsShowOnMain",
                table: "Menus",
                column: "IsShowOnMain");

            migrationBuilder.CreateIndex(
                name: "Menus_Page",
                table: "Menus",
                column: "Page");

            migrationBuilder.CreateIndex(
                name: "Menus_ParentId",
                table: "Menus",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "Menus_Priority",
                table: "Menus",
                column: "Priority");

            migrationBuilder.CreateIndex(
                name: "Menus_SiteId",
                table: "Menus",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "Sites_ExternalId",
                table: "Sites",
                column: "ExternalId");

            migrationBuilder.CreateIndex(
                name: "Sites_FbAppId",
                table: "Sites",
                column: "FbAppId");

            migrationBuilder.CreateIndex(
                name: "Sites_VkAppId",
                table: "Sites",
                column: "VkAppId");

            migrationBuilder.CreateIndex(
                name: "Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Users_FbId",
                table: "Users",
                column: "FbId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UsersToken",
                table: "Users",
                column: "Token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Users_VkId",
                table: "Users",
                column: "VkId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserSites_IsAdmin",
                table: "UserSites",
                column: "IsAdmin");

            migrationBuilder.CreateIndex(
                name: "IX_UserSites_SiteId",
                table: "UserSites",
                column: "SiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "UserSites");

            migrationBuilder.DropTable(
                name: "Sites");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
