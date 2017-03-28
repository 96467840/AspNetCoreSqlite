using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AspNetCoreSqlite.DBModels
{
    public partial class StorageContext : DbContext
    {
        public virtual DbSet<Sites> Sites { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sites>(entity =>
            {
                entity.Property(e => e.Created)
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name).HasColumnType("varchar(255)");
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

                entity.Property(e => e.FbExpires)
                    .HasColumnName("fbExpires")
                    .HasColumnType("datetime");

                entity.Property(e => e.FbId)
                    .IsRequired()
                    .HasColumnName("fbId")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FbToken)
                    .HasColumnName("fbToken")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Name).HasColumnType("varchar(255)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.VkExpires)
                    .HasColumnName("vkExpires")
                    .HasColumnType("datetime");

                entity.Property(e => e.VkId)
                    .IsRequired()
                    .HasColumnName("vkId")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.VkToken)
                    .HasColumnName("vkToken")
                    .HasColumnType("varchar(255)");
            });
        }
    }
}