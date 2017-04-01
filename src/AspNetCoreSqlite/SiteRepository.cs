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

namespace AspNetCoreSqlite
{
    public class SiteRepository : BaseRepositorySQLite<long, Sites>, ISiteRepository//<long, Sites>
    {

        /*public IEnumerable<Sites> All()
        {
            //(Storage as Storage)._logger.LogInformation("try get All");
            return this.dbSet.OrderBy(i => i.Id);//.Select(i=>i.ToDC(Storage));
        }*/

        /*public Sites Get(long id)
        {
            return dbSet.Where(i => i.Id == id)
            //.Select(i=>i.ToDC(Storage))
            .FirstOrDefault();
        }/**/

    }
}
