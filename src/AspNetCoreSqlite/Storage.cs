﻿using AspNetCoreComponentLibrary;
using AspNetCoreComponentLibrary.Abstractions;
using AspNetCoreSqlite.DBModels;
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
        public readonly ILogger<StorageContext> _logger;
        public StorageContext StorageContext { get; private set; }

        public Storage(ILogger<StorageContext> logger, IOptions<SQLiteConfigure> optionsAccessor)
        {
            _logger = logger;
            try
            {
                LogInformation("Connection string={0}", optionsAccessor.Value.ConnectionString);
                //this.StorageContext = new StorageContext("Data Source=..\\..\\..\\db.sqlite");
                this.StorageContext = new StorageContext(optionsAccessor.Value.ConnectionString);
            }
            catch (Exception e)
            {
                _logger.LogCritical("Can't connect to DB: {0}", e);
            }
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public T GetRepository<T>() where T : IRepositorySetStorageContext

        {
            foreach (Type type in this.GetType().GetTypeInfo().Assembly.GetTypes())
            {
                if (typeof(T).GetTypeInfo().IsAssignableFrom(type) && type.GetTypeInfo().IsClass)
                {
                    T repository = (T)Activator.CreateInstance(type);

                    repository.SetStorageContext(this.StorageContext, this);
                    return repository;
                }
            }
            _logger.LogCritical("Can't find repository {0}", typeof(T).FullName);
            return default(T);
        }

        public int Save()
        {
            return this.StorageContext.SaveChanges();
        }
    }
}
