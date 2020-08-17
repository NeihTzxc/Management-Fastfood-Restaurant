using QLCHTAN_v2.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHTAN_v2.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;
        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }
        private BillDAO() { }

        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Bill WHERE idTable=" + id + " AND status=0");
            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }
        public void CheckOut(int id, int discount, float totalPrice)
        {
            //string query = "UPDATE dbo.Bill SET STATUS =1, " +"discount"+discount+" WHERE id="+id;
            string query = "UPDATE dbo.Bill SET dateCheckOut = GETDATE(), status = 1, " + "discount = " + discount + ", totalPrice = " + totalPrice + " WHERE id = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery(" EXEC dbo.USP_InsertBill @idTable =  " + id);
        }
        public DataTable GetBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC dbo.USP_GetListBillByDate @checkIn = '" + checkIn + "', @checkout = '" + checkOut + "'");

        }
        public void DeleteBillByTableID(int id)
        {
            DataProvider.Instance.ExecuteQuery("DELETE dbo.Bill WHERE idTable=''  " + id);
        }


        public int GetMaxIDBill()
        {
            try
            { return (int)DataProvider.Instance.ExecuteScalar(" SELECT MAX(id) FROM dbo.Bill"); }
            catch
            {
                return 1;

            }

        }
        //public void SumTotalPrice(DateTime checkIn, DateTime checkOut)
        //{
        //    DataProvider.Instance.ExecuteQuery("SELECT SUM(totalPrice) FROM dbo.Bill WHERE DateCheckIn BETWEEN '"+checkIn+"' and '"+checkOut+"'");
        //}

    }
}
