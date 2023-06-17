using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System
{
    class DBConnection
    {
        SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=IMSDB;Integrated Security=True");

        public SqlConnection getConnection()
        {
            return connection;
        }
        
    }
}
