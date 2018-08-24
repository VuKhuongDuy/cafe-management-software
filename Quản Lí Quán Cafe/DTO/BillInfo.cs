using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_Lí_Quán_Cafe.DTO
{
    public class BillInfo
    {
        private BillInfo() { }

        private BillInfo(int id, int billId,int foodId,int count)
        {
            this.ID = id;
            this.BillID = billId;
            this.FoodID = foodID;
            this.Count = count;
        }

        public BillInfo(DataRow row)
        {
            this.ID = (int)row["id"];
            this.BillID = (int)row["IDbill"];
            this.FoodID = (int)row["IDfood"];
            this.Count = (int)row["count"];
        }

        private int count;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        private int billID;
        public int BillID
        {
            get { return billID; }
            set { billID = value; }
        }

        private int foodID;
        public int FoodID
        {
            get { return foodID; }
            set { foodID = value; }
        }

        private int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        private static BillInfo instance;
        public static BillInfo Instance
        {
            get { if (instance == null) instance = new BillInfo();  return BillInfo.instance; }
            private set { BillInfo.instance = value; }
        }
    }
}
