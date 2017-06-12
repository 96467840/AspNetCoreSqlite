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
        public readonly ILogger<Storage> Logger;
        protected ILogger LoggerMEF;
        private readonly IOptions<SQLiteConfigure> OptionsAccessor;
        private readonly ILoggerFactory LoggerFactory;
        private readonly ILocalizer2Garin Localizer2Garin;

        public StorageContext StorageContext { get; private set; }
        public StorageContext StorageContextContent { get; private set; }

        public Storage(ILogger<Storage> logger, ILoggerFactory loggerFactory, IOptions<SQLiteConfigure> optionsAccessor, ILocalizer2Garin localizer2Garin)
        {
            Logger = logger;
            Logger.LogTrace("Sqlite Storage::Constructor");
            OptionsAccessor = optionsAccessor;
            LoggerFactory = loggerFactory;
            LoggerMEF = loggerFactory.CreateLogger(Utils.MEFNameSpace);
            Localizer2Garin = localizer2Garin;
            try
            {
                //LogInformation("Connection string={0}", optionsAccessor.Value.ConnectionString);
                StorageContext = new StorageContext(OptionsAccessor.Value.ConnectionString, loggerFactory);
            }
            catch (Exception e)
            {
                Logger.LogCritical("Can't connect to DB: {0}", e);
            }
        }

        public IStorageContext GetContextForSite(long siteid)
        {
            try
            {
                //LogInformation("Connection string={0}", optionsAccessor.Value.ConnectionString);
                return new StorageContext(string.Format(OptionsAccessor.Value.ConnectionStringSite, siteid), LoggerFactory);
            }
            catch (Exception e)
            {
                Logger.LogCritical("Can't connect to DB: {0}", e);
                return null;
            }
        }

        public void ConnectToSiteDB(long siteid)
        {
            StorageContextContent = GetContextForSite(siteid) as StorageContext;
        }

        // кеш репозиториев. не делаем его статиком -> на каждый запрос будет своя копия
        // для оптимизации рефлексии можно ее закешировать, но пока не будем так глубоко
        private Dictionary<string, IRepositorySetStorageContext> _cacheRepos = new Dictionary<string, IRepositorySetStorageContext>();
        public T GetRepository<T>(EnumDB db, bool enableCache=true) where T : IRepositorySetStorageContext
        {
            var cacheKey = db + " " + typeof(T).FullName;
            Logger.LogTrace("Storage::GetRepository incache={cache} type={type} key=[{key}]", _cacheRepos.ContainsKey(cacheKey), typeof(T).FullName, cacheKey);
            if (enableCache && _cacheRepos.ContainsKey(cacheKey)) return (T)_cacheRepos[cacheKey];

            foreach (Type type in this.GetType().GetTypeInfo().Assembly.GetTypes())
            {
                if (typeof(T).GetTypeInfo().IsAssignableFrom(type) && type.GetTypeInfo().IsClass)
                {
                    T repository = (T)Activator.CreateInstance(type);
                    if (db == EnumDB.Content)
                    {
                        if (StorageContextContent == null)
                        {
                            Logger.LogCritical("Запрашиваемый репозиторий ({0}) не может быть получен до подключения к БД с контентом! Для начала надо выполнить подключение к БД сайта ConnectToSiteDB(siteid)", typeof(T).FullName);
                            throw new Exception("Could't recive content Repository before connect to DB!");
                        }
                        repository.SetStorageContext(StorageContextContent, this, LoggerFactory, Localizer2Garin);
                    }
                    else
                    {
                        repository.SetStorageContext(StorageContext, this, LoggerFactory, Localizer2Garin);
                    }
                    // в кеш помещаем тока если разрешено брать из кеша. 
                    if (enableCache) _cacheRepos[cacheKey] = repository;
                    return repository;
                }
            }
            Logger.LogCritical("Can't find repository {0}", typeof(T).FullName);
            return default(T);
        }

        public void Save()
        {
            using (new BLog(LoggerMEF, "Save", "::::::::::>"))
            {
                //StorageContext.SaveChangesAsync().Wait();
                StorageContext.SaveChanges();
            }
        }

        // данный код выполняется при запуске сайта и обновляет все БД сайтов
        public async void UpdateDBs()
        {
            Logger.LogInformation("UpdateDBs ...");
            StorageContext.Database.Migrate();
            // теперь можем получить список сайтов и обновить все БД
            var sites = GetRepository<ISiteRepository>(EnumDB.UserSites);
            foreach (var siteid in sites.StartQuery(0).Select(i=>i.Id))
            {
                Logger.LogInformation("UpdateDBs for {0}...", siteid);
                await (GetContextForSite(siteid) as StorageContext).Database.MigrateAsync();
            }

        }
    }
}
