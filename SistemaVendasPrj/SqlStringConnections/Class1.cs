using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SqlStringConnections
{
    public class Utilidade
    {
        public static DataSet Executar(string cmd)
        {
            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=BDLOJA;Integrated Security=True");
            con.Open();

            DataSet DS = new DataSet();
            SqlDataAdapter DP = new SqlDataAdapter(cmd, con);
            
            DP.Fill(DS);
            con.Close();

            return DS;
        }
    }
}
