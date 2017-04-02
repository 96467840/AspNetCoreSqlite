using AspNetCoreComponentLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AspNetCoreSqlite.DBModels;
using AspNetCoreComponentLibrary.Abstractions;

namespace AspNetCoreSqlite
{
    public class RepositorySQLite<K, T> : Repository<K, T>, IEnumerable<T> where T : BaseDM<K> where K : struct
    {
        // одно хреново в архитектуре это копирование вот этих 2 свойств
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
            }
        }

        public T this[K? index]
        {
            get
            {
                if (index == null) return default(T);
                return dbSet.FirstOrDefault(i => i.Id.ToString() == index.ToString());
            }
        }

        public override void Remove(K id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> StartQuery()
        {
            //(Storage as Storage)._logger.LogInformation("AllFromDB");
            return this.dbSet;//.OrderBy(i => i.Id);//.Select(i=>i.ToDC(Storage));
        }/**/

        #region [   IEnumerable<T>   ]

        public IEnumerator<T> GetEnumerator()
        {
            //return dbSet.AsEnumerable().GetEnumerator();
            return ((IEnumerable<T>)dbSet).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
