using HotChoculate.Infrastructure.Core.Configuration;
using HotChoculate.Infrastructure.Core.Interfaces;
using Microsoft.Extensions.Options;
using System;

namespace HotChoculate.Infrastructure.Core.Managers
{
    public class ConnectionManager : IConnectionManager
    {
        private readonly IDatabaseNameProvider _databaseNameProvider;
        private readonly DatabaseConfig _settings;
        private string _strConnectionString;

        public ConnectionManager(IOptions<DatabaseConfig> config, IDatabaseNameProvider databaseNameProvider)
        {
            if (databaseNameProvider is null)
            {
                throw new ArgumentNullException(nameof(databaseNameProvider));
            }

            if (config is null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            _settings = config.Value;
            _databaseNameProvider = databaseNameProvider;
            _strConnectionString = GetConnectionString();
        }

        public string ConnectionString
        {
            get
            {
                return _strConnectionString;
            }
        }

        private string GetConnectionString()
        {
            var strConnectionString =
                       $"Data Source={_settings.DataSource};" +
                       $"Initial Catalog={_databaseNameProvider.GetDatabaseName()}; " +
                       $"User Id={_settings.DataSourceUserID};" +
                       $"Password={_settings.DataSourcePassword};" +
                       "Integrated Security=False;";

            return strConnectionString;
        }
    }
}
