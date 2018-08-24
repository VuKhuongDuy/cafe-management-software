using Quản_Lí_Quán_Cafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_Lí_Quán_Cafe.DAO
{
    class BillDAO
    {
        private static BillDAO instance;

        internal static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }

        private BillDAO() { }

        /// <summary>
        /// Thành công : bill ID
        /// Thất bại : id =-1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetUncheckBillIdByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.Bill where bill.id = " + id + " and status =0");
            if(data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;  
        }

        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBill @idTable ", new object[] { id });
        }

        public int GetMaxIDBill()
        {
             try
            {
                return (int)DataProvider.Instance.ExecuteScalar("select Max(id) from dbo.bill");
            }
            catch
            {
                return 1;
            }
        }
    }
}
