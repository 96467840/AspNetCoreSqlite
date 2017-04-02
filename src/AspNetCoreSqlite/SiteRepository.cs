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
    public class SiteRepository : RepositorySQLite<long, Sites>, ISiteRepository
    {
    }
}
