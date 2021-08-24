using System;
using System.Collections.Generic;
using System.Text;

namespace HotChoculate.Infrastructure.Core.Configuration
{
    public class DatabaseConfig
    {
        public string ConnectionString { get; set; }
        public string DataSource { get; set; }
        public string DataSourceUserID { get; set; }
        public string DataSourcePassword { get; set; }
    }
}
