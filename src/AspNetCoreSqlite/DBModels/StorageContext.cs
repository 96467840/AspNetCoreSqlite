using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AspNetCoreComponentLibrary;

namespace AspNetCoreSqlite.DBModels
{
    public partial class StorageContext : DbContext
    {
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<Sites> Sites { get; set; }
        public virtual DbSet<UserSites> UserSites { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menus>(entity =>
            {
                entity.Property(e => e.BodyCss)
                    .HasColumnName("BodyCSS")
                    .HasColumnType("text");

                entity.Property(e => e.Content).HasColumnType("text");

                entity.Property(e => e.Created)
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
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.SiteId);
            });

            modelBuilder.Entity<Sites>(entity =>
            {
                entity.Property(e => e.Contacts).HasColumnType("text");

                entity.Property(e => e.ContactsShort).HasColumnType("text");

                entity.Property(e => e.Created)
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.E404pageId).HasColumnName("E404PageId");

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

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasColumnType("varchar(512)");

                entity.Property(e => e.VkAppId)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.VkAppSecret)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.YandexMetrika).HasColumnType("varchar(128)");

                entity.HasOne(d => d.E404page)
                    .WithMany(p => p.SitesE404page)
                    .HasForeignKey(d => d.E404pageId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.OrderPage)
                    .WithMany(p => p.SitesOrderPage)
                    .HasForeignKey(d => d.OrderPageId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<UserSites>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.SiteId })
                    .HasName("sqlite_autoindex_UserSites_1");

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
                    .HasName("sqlite_autoindex_Users_1")
                    .IsUnique();

                entity.HasIndex(e => e.FbId)
                    .HasName("sqlite_autoindex_Users_4")
                    .IsUnique();

                entity.HasIndex(e => e.Token)
                    .HasName("sqlite_autoindex_Users_2")
                    .IsUnique();

                entity.HasIndex(e => e.VkId)
                    .HasName("sqlite_autoindex_Users_3")
                    .IsUnique();

                entity.Property(e => e.Created)
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