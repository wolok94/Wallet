using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Sql
{
    interface IDataAccess
    {
        public SqlCommand Connect(string queryString);
    }
}
