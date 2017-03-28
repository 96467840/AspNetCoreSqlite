using AspNetCoreComponentLibrary.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using AspNetCoreComponentLibrary;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AspNetCoreSqlite.DBModels;

namespace AspNetCoreSqlite
{
    public class SiteRepository : ISiteRepository
    {
        private StorageContext storageContext;
        private DbSet<Sites> dbSet;

        public void SetStorageContext(IStorageContext storageContext)
        {
            this.storageContext = storageContext as StorageContext;
            this.dbSet = this.storageContext.Set<Sites>();
        }

        public IEnumerable<Site> All()
        {
            return this.dbSet.OrderBy(i => i.Id).Select(i=>new Site { Id=i.Id, Name=i.Name});
        }
    }
}
