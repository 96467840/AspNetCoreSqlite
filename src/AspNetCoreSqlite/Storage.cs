using AspNetCoreComponentLibrary;
using AspNetCoreComponentLibrary.Abstractions;
using AspNetCoreSqlite.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreSqlite
{
    public class Storage : IStorage
    {
        public readonly ILogger<Storage> _logger;
        private readonly IOptions<SQLiteConfigure> _optionsAccessor;
        private readonly ILoggerFactory _loggerFactory;

        public StorageContext StorageContext { get; private set; }
        public StorageContext StorageContextSite { get; private set; }

        public Storage(ILogger<Storage> logger, ILoggerFactory loggerFactory, IOptions<SQLiteConfigure> optionsAccessor)
        {
            _logger = logger;
            _optionsAccessor = optionsAccessor;
            _loggerFactory = loggerFactory;
            try
            {
                //LogInformation("Connection string={0}", optionsAccessor.Value.ConnectionString);
                StorageContext = new StorageContext(_optionsAccessor.Value.ConnectionString, loggerFactory);
            }
            catch (Exception e)
            {
                _logger.LogCritical("Can't connect to DB: {0}", e);
            }
        }

        /*public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }/**/

        public void ConnectToSiteDB(long siteid)
        {
            try
            {
                //LogInformation("Connection string={0}", optionsAccessor.Value.ConnectionString);
                StorageContextSite = new StorageContext(string.Format(_optionsAccessor.Value.ConnectionStringSite, siteid), _loggerFactory);
            }
            catch (Exception e)
            {
                _logger.LogCritical("Can't connect to DB: {0}", e);
            }
        }

        public T GetRepository<T>(bool SiteStorage) where T : IRepositorySetStorageContext

        {
            foreach (Type type in this.GetType().GetTypeInfo().Assembly.GetTypes())
            {
                if (typeof(T).GetTypeInfo().IsAssignableFrom(type) && type.GetTypeInfo().IsClass)
                {
                    T repository = (T)Activator.CreateInstance(type);
                    if (SiteStorage)
                    {
                        repository.SetStorageContext(this.StorageContextSite, this);
                    }
                    else
                    {
                        repository.SetStorageContext(this.StorageContext, this);
                    }
                    return repository;
                }
            }
            _logger.LogCritical("Can't find repository {0}", typeof(T).FullName);
            return default(T);
        }

        public void Save()
        {
            this.StorageContext.SaveChangesAsync().Wait();
        }

        // данный код выполняется при запуске сайта и обновляет все БД сайтов
        public void UpdateDBs()
        {

            StorageContext.Database.Migrate();
            // теперь можем получить список сайтов и обновить все БД
            // ...

        }
    }
}
