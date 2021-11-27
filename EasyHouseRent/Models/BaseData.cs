using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHouseRent.Model
{
    public class BaseData
    {
        MySqlConnection connection;
    

        public BaseData()
        {
            connection = new MySqlConnection("datasource = localhost; port = 3306; username = root; password= Juan67927; database = easyhouserent ; SSLMode = none");
        }
        public string executeSql(string sql)
        {
            string result = "";
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                int rows = cmd.ExecuteNonQuery();

                if (rows > -1)
                {
                    result = "Correct";
                }
                else
                {
                    result = "Incorrect";
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                result = ex.Message;

            }
            return result;
        }

        public DataTable getTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                adapter.Fill(dt);
                connection.Close();
                adapter.Dispose();
            }
            catch
            {
                dt = null;
            }
            return dt;
        }
    }
}
