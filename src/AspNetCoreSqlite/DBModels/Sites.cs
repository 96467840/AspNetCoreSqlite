using System;
using System.Collections.Generic;

namespace AspNetCoreSqlite.DBModels
{
    public partial class Sites
    {
        public long Id { get; set; }
        public string Created { get; set; }
        public string Name { get; set; }
    }
}
