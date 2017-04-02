using AspNetCoreComponentLibrary;
using AspNetCoreComponentLibrary.Abstractions;
using AspNetCoreSqlite.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetCoreSqlite
{
    public class RepositoryWithCacheSQLite<K,T> : RepositoryWithCache<K, T> where K : struct where T: BaseDM<K>
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

        public override void LoadFromDB()
        {
            (Storage as Storage)._logger.LogInformation("LoadFromDB");
            Coll =  this.dbSet.ToDictionary(i=>i.Id.Value, i=>i);
        }

        /*public IEnumerable<T> AllFromDB()
        {
            (Storage as Storage)._logger.LogInformation("AllFromDB");
            return this.dbSet.OrderBy(i => i.Id);//.Select(i=>i.ToDC(Storage));
        }*/

        public IQueryable<T> StartQuery()
        {
            //(Storage as Storage)._logger.LogInformation("AllFromDB");
            return this.dbSet;//.OrderBy(i => i.Id);//.Select(i=>i.ToDC(Storage));
        }/**/

        public override K Save(T item)
        {
            if (item == null) throw new ArgumentNullException();
            if (item.Id.HasValue)
            {
                dbSet.Update(item);
            }
            else
            {
                dbSet.Add(item);
            }
            Storage.Save();

            CheckColl();
            if (item.Id.HasValue) Coll[item.Id.Value] = item;

            return item.Id.Value;
        }/**/

        public override void SetBlock(K id, bool value)
        {
            if (typeof(T) is IBlockable)
            {
                T item = (T)Activator.CreateInstance(typeof(T));
                item.Id = id;
                ((IBlockable)item).IsBlocked = value;
                dbSet.Update(item);
                Storage.Save();

                CheckColl();
                Coll[id] = item;
            }
        }

        public override void Remove(K id)
        {
            throw new NotImplementedException();
        }

    }
}
