using AspNetCoreComponentLibrary.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using AspNetCoreComponentLibrary;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AspNetCoreSqlite.DBModels;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq.Expressions;


namespace AspNetCoreSqlite
{
    public class SiteRepository : SiteRepositoryProto, ISiteRepository
    {
        public override void AfterSave(Sites item, bool isnew) {
            Logger.LogTrace("SiteRepository AfterSave for {0}; isnew = {1}", item.Id, isnew);
            if (!isnew) return;
            (Storage.GetContextForSite(item.Id.Value) as StorageContext).Database.Migrate();
        }
    }
}
