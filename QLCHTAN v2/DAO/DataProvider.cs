using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHTAN_v2.DAO
{
    public class DataProvider
    {
        private string strConnect = "SERVER=DESKTOP-6GU614T;Database=QuanLyQuanCafe;User Id=sa;pwd=123456";
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get {  if (instance == null) instance = new DataProvider(); return DataProvider.instance; }

            private set{DataProvider.instance = value; }
        }
        private DataProvider() { }

        public DataTable ExecuteQuery(string query)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
            
        }
        public int ExecuteNonQuery(string query)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }
        public object ExecuteScalar(string query)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
    }
}
