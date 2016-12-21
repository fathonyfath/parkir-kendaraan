using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Util
{
    public class SqlConnectionHelper
    {
        private static SqlConnectionHelper instance;

        public static SqlConnectionHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SqlConnectionHelper();
                }
                return instance;
            }
        }

        private SqlConnection connection;

        public SqlConnection Connection
        {
            get { return connection; }
        }

        private SqlConnectionHelper()
        {
            String connString = @"Server=localhost;
                                Integrated Security=True;
                                Database=parkir;";

            connection = new SqlConnection(connString);
            connection.Open();
        }

        public SqlCommand CreateSqlCommand(String query)
        {
            return new SqlCommand(query, connection);
        }
    }
}
