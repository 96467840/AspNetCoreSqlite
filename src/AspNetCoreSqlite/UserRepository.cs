using AspNetCoreComponentLibrary;
using AspNetCoreComponentLibrary.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreSqlite
{
    // реализуем частичное кеширование. в кеше храним тока последних юзеров (за 1 день)
    public class UserRepository : RepositoryWithCache<long, Users>, IUserRepository
    {

    }
}
