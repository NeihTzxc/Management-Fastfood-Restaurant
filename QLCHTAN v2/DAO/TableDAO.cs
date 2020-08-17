using QLCHTAN_v2.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHTAN_v2.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;
        public static  TableDAO  Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }
        public static int TableWidth = 90;
        public static int TableHeight = 90;
        private TableDAO() { }
        public void SwitchTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwitchTable @idTable1="+id1+" , @idTable2="+id2);
        }
        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();
            DataTable data =  DataProvider.Instance.ExecuteQuery("EXEC dbo.USP_GetTableList");

            foreach(DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            return tableList;
        }
        public bool InsertTable(string name, string status)
        {
            string query = string.Format(" INSERT INTO dbo.TableFood( name, status ) VALUES  ( N'{0}', N'{1}'  )", name,status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateTable(int id, string name,string status)
        {
            string query = string.Format("UPDATE dbo.TableFood SET name='{0}',status='{1}' WHERE id={2}", name, status,id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteTable(int idTable)
        {
            BillDAO.Instance.DeleteBillByTableID(idTable);
            string query = string.Format("DELETE dbo.TableFood WHERE id={0}", idTable);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        
    }
}
