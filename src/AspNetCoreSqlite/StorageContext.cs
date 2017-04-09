using AspNetCoreComponentLibrary;
using AspNetCoreComponentLibrary.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreSqlite.DBModels
{
    public partial class StorageContext : DbContext, IStorageContext
    {
        private string connectionString;
        private readonly ILoggerFactory loggerFactory;

        // конструктор для миграций
        public StorageContext()
        {
            this.connectionString = "Data Source=D:\\sqlite\\_db.sqlite";
        }/**/

        public StorageContext(string connectionString, ILoggerFactory loggerFactory)
        {
            this.connectionString = connectionString;
            this.loggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLoggerFactory(loggerFactory);

            optionsBuilder.UseSqlite(this.connectionString);
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Site>(etb =>
            {
                etb.HasKey(e => e.Id);
                etb.Property(e => e.Id);
                etb.ForSqliteToTable("Sites");
            }
            );
        }*/
    }
}
