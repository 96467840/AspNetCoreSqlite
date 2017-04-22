using AspNetCoreComponentLibrary;
using AspNetCoreComponentLibrary.Abstractions;
using AspNetCoreSqlite.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public StorageContext StorageContextContent { get; private set; }

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

        public IStorageContext GetContextForSite(long siteid)
        {
            try
            {
                //LogInformation("Connection string={0}", optionsAccessor.Value.ConnectionString);
                return new StorageContext(string.Format(_optionsAccessor.Value.ConnectionStringSite, siteid), _loggerFactory);
            }
            catch (Exception e)
            {
                _logger.LogCritical("Can't connect to DB: {0}", e);
                return null;
            }
        }

        public void ConnectToSiteDB(long siteid)
        {
            StorageContextContent = GetContextForSite(siteid) as StorageContext;
        }

        public T GetRepository<T>(EnumDB db) where T : IRepositorySetStorageContext

        {
            foreach (Type type in this.GetType().GetTypeInfo().Assembly.GetTypes())
            {
                if (typeof(T).GetTypeInfo().IsAssignableFrom(type) && type.GetTypeInfo().IsClass)
                {
                    T repository = (T)Activator.CreateInstance(type);
                    if (db == EnumDB.Content)
                    {
                        repository.SetStorageContext(this.StorageContextContent, this, _loggerFactory);
                    }
                    else
                    {
                        repository.SetStorageContext(this.StorageContext, this, _loggerFactory);
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
        public async void UpdateDBs()
        {
            _logger.LogInformation("UpdateDBs ...");
            StorageContext.Database.Migrate();
            // теперь можем получить список сайтов и обновить все БД
            var sites = GetRepository<ISiteRepository>(EnumDB.Content);
            foreach (var siteid in sites.StartQuery().Select(i=>i.Id.Value))
            {
                _logger.LogInformation("UpdateDBs for {0}...", siteid);
                await (GetContextForSite(siteid) as StorageContext).Database.MigrateAsync();
            }

        }
    }
}
