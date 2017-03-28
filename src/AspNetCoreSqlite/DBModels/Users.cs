using System;
using System.Collections.Generic;

namespace AspNetCoreSqlite.DBModels
{
    public partial class Users
    {
        public long Id { get; set; }
        public string Created { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string VkId { get; set; }
        public string VkToken { get; set; }
        public string VkExpires { get; set; }
        public string FbId { get; set; }
        public string FbToken { get; set; }
        public string FbExpires { get; set; }
    }
}
