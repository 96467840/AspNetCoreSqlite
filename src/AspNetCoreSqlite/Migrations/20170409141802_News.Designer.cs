using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AspNetCoreSqlite.DBModels;

namespace AspNetCoreSqlite.Migrations
{
    [DbContext(typeof(StorageContext))]
    [Migration("20170409141802_News")]
    partial class News
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("AspNetCoreComponentLibrary.Menus", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BodyCss")
                        .HasColumnName("BodyCSS")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TIMESTAMP")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Css")
                        .HasColumnName("CSS")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(1024)")
                        .HasDefaultValueSql("''");

                    b.Property<string>("ExternalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(100)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("ImageLogo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("ImageLogoRight")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("ImageOnMain")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)")
                        .HasDefaultValueSql("NULL");

                    b.Property<bool>("InFb")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("1");

                    b.Property<bool>("InVk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("1");

                    b.Property<bool>("InWww")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("InWWW")
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("1");

                    b.Property<bool>("IsBlocked")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("IsSeparatedFaqs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("IsShowOnMain")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Lang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(17)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Layout")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(128)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)")
                        .HasDefaultValueSql("''");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)")
                        .HasDefaultValueSql("''");

                    b.Property<string>("Page")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)")
                        .HasDefaultValueSql("''");

                    b.Property<long?>("ParentId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NULL");

                    b.Property<int>("Priority")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("SMALLINT")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Search")
                        .HasColumnType("text");

                    b.Property<string>("SeoDescription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(1024)")
                        .HasDefaultValueSql("''");

                    b.Property<string>("SeoKeywords")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(1024)")
                        .HasDefaultValueSql("''");

                    b.Property<string>("SeoTitle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)")
                        .HasDefaultValueSql("''");

                    b.Property<string>("ShortContent")
                        .HasColumnType("text");

                    b.Property<bool>("ShowInBottom")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("ShowInMenu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("1");

                    b.Property<bool>("ShowInTop")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("1");

                    b.Property<bool>("ShowLeftMenu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("1");

                    b.Property<bool>("ShowNews")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("ShowSubmenu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("0");

                    b.Property<long>("SiteId");

                    b.Property<string>("Url")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("URL")
                        .HasColumnType("varchar(512)")
                        .HasDefaultValueSql("''");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .HasName("Menus_ExternalId");

                    b.HasIndex("IsBlocked")
                        .HasName("Menus_IsBlocked");

                    b.HasIndex("IsShowOnMain")
                        .HasName("Menus_IsShowOnMain");

                    b.HasIndex("Page")
                        .HasName("Menus_Page");

                    b.HasIndex("ParentId")
                        .HasName("Menus_ParentId");

                    b.HasIndex("Priority")
                        .HasName("Menus_Priority");

                    b.HasIndex("SiteId")
                        .HasName("Menus_SiteId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("AspNetCoreComponentLibrary.News", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(1024)")
                        .HasDefaultValueSql("''");

                    b.Property<string>("ExternalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(100)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Image")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)")
                        .HasDefaultValueSql("''");

                    b.Property<bool>("InFb")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("1");

                    b.Property<bool>("InVk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("1");

                    b.Property<bool>("InWww")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("InWWW")
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("1");

                    b.Property<bool>("IsBlocked")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(512)")
                        .HasDefaultValueSql("''");

                    b.Property<string>("Page")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)")
                        .HasDefaultValueSql("''");

                    b.Property<string>("Search")
                        .HasColumnType("text");

                    b.Property<string>("SeoDescription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(1024)")
                        .HasDefaultValueSql("''");

                    b.Property<string>("SeoKeywords")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(1024)")
                        .HasDefaultValueSql("''");

                    b.Property<string>("SeoTitle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)")
                        .HasDefaultValueSql("''");

                    b.Property<long>("SiteId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Date")
                        .HasName("News_Date");

                    b.HasIndex("ExternalId")
                        .HasName("News_ExternalId");

                    b.HasIndex("IsBlocked")
                        .HasName("News_IsBlocked");

                    b.HasIndex("Page")
                        .HasName("News_Page");

                    b.HasIndex("SiteId")
                        .HasName("News_SiteId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("AspNetCoreComponentLibrary.Sites", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Contacts")
                        .HasColumnType("text");

                    b.Property<string>("ContactsShort")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TIMESTAMP")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<long?>("E404pageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("E404PageId")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("ExternalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(100)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Favicon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("FbAppId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("FbAppSecret")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("FbNamespace")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("GoogleanAlytics")
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Hosts")
                        .HasColumnType("text");

                    b.Property<bool>("IsDefault")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("IsVisible")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Layout")
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<long?>("OrderPageId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("RecaptchaSecretKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("RecaptchaSiteKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)")
                        .HasDefaultValueSql("NULL");

                    b.Property<bool>("Share42")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Template")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(50)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("VkAppId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("VkAppSecret")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("YandexMetrika")
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .HasName("Sites_ExternalId");

                    b.HasIndex("FbAppId")
                        .HasName("Sites_FbAppId");

                    b.HasIndex("VkAppId")
                        .HasName("Sites_VkAppId");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("AspNetCoreComponentLibrary.Users", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TIMESTAMP")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FbExpires")
                        .HasColumnType("datetime");

                    b.Property<string>("FbId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FbToken")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("VkExpires")
                        .HasColumnType("datetime");

                    b.Property<string>("VkId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("VkToken")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("Users_Email");

                    b.HasIndex("FbId")
                        .IsUnique()
                        .HasName("Users_FbId");

                    b.HasIndex("Token")
                        .IsUnique()
                        .HasName("UsersToken");

                    b.HasIndex("VkId")
                        .IsUnique()
                        .HasName("Users_VkId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AspNetCoreComponentLibrary.UserSites", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<long>("SiteId");

                    b.Property<bool>("IsAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Rights")
                        .HasColumnType("text");

                    b.HasKey("UserId", "SiteId")
                        .HasName("sqlite_autoindex_UserSites_1");

                    b.HasIndex("IsAdmin")
                        .HasName("UserSites_IsAdmin");

                    b.HasIndex("SiteId")
                        .HasName("IX_UserSites_SiteId");

                    b.ToTable("UserSites");
                });

            modelBuilder.Entity("AspNetCoreComponentLibrary.Menus", b =>
                {
                    b.HasOne("AspNetCoreComponentLibrary.Menus", "Parent")
                        .WithMany("InverseParent")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("AspNetCoreComponentLibrary.UserSites", b =>
                {
                    b.HasOne("AspNetCoreComponentLibrary.Sites", "Site")
                        .WithMany("UserSites")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AspNetCoreComponentLibrary.Users", "User")
                        .WithMany("UserSites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
