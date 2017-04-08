using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AspNetCoreComponentLibrary;

namespace AspNetCoreSqlite.DBModels
{
    public partial class StorageContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}