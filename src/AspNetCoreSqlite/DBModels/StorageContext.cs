using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AspNetCoreComponentLibrary;

namespace AspNetCoreSqlite.DBModels
{
    public partial class StorageContext : DbContext
    {
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Sites> Sites { get; set; }
        public virtual DbSet<UserSites> UserSites { get; set; }
        public virtual DbSet<Users> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menus>(entity =>
            {
                entity.HasIndex(e => e.ExternalId)
                    .HasName("Menus_ExternalId");

                entity.HasIndex(e => e.IsBlocked)
                    .HasName("Menus_IsBlocked");

                entity.HasIndex(e => e.IsShowOnMain)
                    .HasName("Menus_IsShowOnMain");

                entity.HasIndex(e => e.Page)
                    .HasName("Menus_Page");

                entity.HasIndex(e => e.ParentId)
                    .HasName("Menus_ParentId");

                entity.HasIndex(e => e.Priority)
                    .HasName("Menus_Priority");

                entity.HasIndex(e => e.SiteId)
                    .HasName("Menus_SiteId");

                entity.Property(e => e.BodyCss)
                    .HasColumnName("BodyCSS")
                    .HasColumnType("text");

                entity.Property(e => e.Content).HasColumnType("text");

                entity.Property(e => e.Created)
                    .IsRequired()
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Css)
                    .HasColumnName("CSS")
                    .HasColumnType("text");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(1024)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ExternalId)
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.ImageLogo)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.ImageLogoRight)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.ImageOnMain)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.InFb)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.InVk)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.InWww)
                    .HasColumnName("InWWW")
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.IsBlocked)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IsSeparatedFaqs)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IsShowOnMain)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Lang)
                    .HasColumnType("varchar(17)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Layout)
                    .HasColumnType("varchar(128)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.MenuName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Page)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ParentId).HasDefaultValueSql("NULL");

                entity.Property(e => e.Priority)
                    .HasColumnType("SMALLINT")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Search).HasColumnType("text");

                entity.Property(e => e.SeoDescription)
                    .HasColumnType("varchar(1024)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SeoKeywords)
                    .HasColumnType("varchar(1024)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SeoTitle)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ShortContent).HasColumnType("text");

                entity.Property(e => e.ShowInBottom)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ShowInMenu)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.ShowInTop)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.ShowLeftMenu)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.ShowNews)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ShowSubmenu)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL")
                    .HasColumnType("varchar(512)")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.HasIndex(e => e.Date)
                    .HasName("News_Date");

                entity.HasIndex(e => e.ExternalId)
                    .HasName("News_ExternalId");

                entity.HasIndex(e => e.IsBlocked)
                    .HasName("News_IsBlocked");

                entity.HasIndex(e => e.Page)
                    .HasName("News_Page");

                entity.HasIndex(e => e.SiteId)
                    .HasName("News_SiteId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Content).HasColumnType("text");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(1024)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ExternalId)
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.InFb)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.InVk)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.InWww)
                    .HasColumnName("InWWW")
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.IsBlocked)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(512)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Page)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Search).HasColumnType("text");

                entity.Property(e => e.SeoDescription)
                    .HasColumnType("varchar(1024)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SeoKeywords)
                    .HasColumnType("varchar(1024)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SeoTitle)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SiteId).HasColumnType("integer");
            });

            modelBuilder.Entity<Sites>(entity =>
            {
                entity.HasIndex(e => e.ExternalId)
                    .HasName("Sites_ExternalId");

                entity.HasIndex(e => e.FbAppId)
                    .HasName("Sites_FbAppId");

                entity.HasIndex(e => e.VkAppId)
                    .HasName("Sites_VkAppId");

                entity.Property(e => e.Contacts).HasColumnType("text");

                entity.Property(e => e.ContactsShort).HasColumnType("text");

                entity.Property(e => e.Created)
                    .IsRequired()
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.E404pageId)
                    .HasColumnName("E404PageId")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.ExternalId)
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Favicon)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.FbAppId)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.FbAppSecret)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.FbNamespace)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.GoogleanAlytics).HasColumnType("varchar(128)");

                entity.Property(e => e.Hosts).HasColumnType("text");

                entity.Property(e => e.IsDefault)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IsDeleted)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IsVisible)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Layout).HasColumnType("varchar(128)");

                entity.Property(e => e.Name).HasColumnType("varchar(255)");

                entity.Property(e => e.OrderPageId).HasDefaultValueSql("NULL");

                entity.Property(e => e.RecaptchaSecretKey)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.RecaptchaSiteKey)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Share42)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Template)
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.VkAppId)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.VkAppSecret)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.YandexMetrika).HasColumnType("varchar(128)");
            });

            modelBuilder.Entity<UserSites>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.SiteId })
                    .HasName("sqlite_autoindex_UserSites_1");

                entity.HasIndex(e => e.IsAdmin)
                    .HasName("UserSites_IsAdmin");

                entity.HasIndex(e => e.SiteId)
                    .HasName("IX_UserSites_SiteId");

                entity.Property(e => e.IsAdmin)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Rights).HasColumnType("text");

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.UserSites)
                    .HasForeignKey(d => d.SiteId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSites)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("Users_Email")
                    .IsUnique();

                entity.HasIndex(e => e.FbId)
                    .HasName("Users_FbId")
                    .IsUnique();

                entity.HasIndex(e => e.Token)
                    .HasName("UsersToken")
                    .IsUnique();

                entity.HasIndex(e => e.VkId)
                    .HasName("Users_VkId")
                    .IsUnique();

                entity.Property(e => e.Created)
                    .IsRequired()
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FbExpires).HasColumnType("datetime");

                entity.Property(e => e.FbId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FbToken).HasColumnType("varchar(255)");

                entity.Property(e => e.Name).HasColumnType("varchar(255)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.VkExpires).HasColumnType("datetime");

                entity.Property(e => e.VkId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.VkToken).HasColumnType("varchar(255)");
            });
        }
    }
}