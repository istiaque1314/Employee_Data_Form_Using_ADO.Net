using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeDataForm
{
    internal class ConnectionHelper
    {
        public static SqlConnection GetConnection()
        {
            string strconn = ConfigurationManager.ConnectionStrings["EmployeeCon"].ConnectionString;
            SqlConnection conn = new SqlConnection(strconn);
            return conn;
        }
    }
}
