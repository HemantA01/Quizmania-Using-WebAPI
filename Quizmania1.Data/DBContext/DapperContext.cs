using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmania1.Data.DBContext
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connString = _configuration.GetConnectionString("DbConn");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connString);
    }
}
