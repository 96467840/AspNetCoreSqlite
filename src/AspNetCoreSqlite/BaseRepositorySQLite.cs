using AspNetCoreComponentLibrary;
using AspNetCoreSqlite.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetCoreSqlite
{
    public class BaseRepositorySQLite<K,T> : BaseRepository<K, T> where K : struct where T: BaseDM<K>
    {
        protected DbSet<T> _dbSet = null;
        protected DbSet<T> dbSet
        {
            get
            {
                //(Storage as Storage)._logger.LogInformation("try get dbSet...");
                if (_dbSet != null) return _dbSet;
                _dbSet = (StorageContext as StorageContext).Set<T>();
                return _dbSet;
            }
        }

        public IEnumerable<T> AllFromDB()
        {
            //(Storage as Storage)._logger.LogInformation("try get All");
            return this.dbSet.OrderBy(i => i.Id);//.Select(i=>i.ToDC(Storage));
        }

        public override K? Save(T site)
        {
            if (site == null) throw new ArgumentNullException();
            if (site.Id.HasValue)
            {
                dbSet.Update(site);
            }
            else
            {
                dbSet.Add(site);
            }
            Storage.Save();

            return site.Id;
        }/**/
    }
}
