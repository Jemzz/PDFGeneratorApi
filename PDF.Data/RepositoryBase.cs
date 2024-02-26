using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace PDF.Data
{
    public class RepositoryBase
    {
        private readonly IOptions<RepositoryOptions> _configuration;

        protected string ConnectionString => _configuration.Value.ConnectionString;
        protected string MrConnectionString => _configuration.Value.MrConnectionString;

        public RepositoryBase(IOptions<RepositoryOptions> configuration)
        {
            _configuration = configuration;
        }

        internal IDbConnection Connection => new SqlConnection(ConnectionString);
        internal IDbConnection MrDbConnection => new SqlConnection(MrConnectionString);
    }
}
