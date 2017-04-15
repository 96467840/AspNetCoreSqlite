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
        public override void AfterSave(Sites item) {
            //Logger.LogInformation("SiteRepository AfterSave for {0}", item.Id);
            (Storage.GetContextForSite(item.Id.Value) as StorageContext).Database.Migrate();
        }
    }
}
