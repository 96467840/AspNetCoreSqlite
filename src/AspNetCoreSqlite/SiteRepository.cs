using AspNetCoreComponentLibrary.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using AspNetCoreComponentLibrary;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AspNetCoreSqlite
{
    public class SiteRepository : ISiteRepository
    {
        private StorageContext storageContext;
        private DbSet<Site> dbSet;

        public void SetStorageContext(IStorageContext storageContext)
        {
            this.storageContext = storageContext as StorageContext;
            this.dbSet = this.storageContext.Set<Site>();
        }

        public IEnumerable<Site> All()
        {
            return this.dbSet.OrderBy(i => i.Id);
        }
    }
}
