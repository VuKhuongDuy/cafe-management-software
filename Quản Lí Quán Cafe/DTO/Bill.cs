using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_Lí_Quán_Cafe.DTO
{
    public class Bill
    {
        public Bill(int id, DateTime? dateCheckOut,DateTime? dateCheckIn,int idTable, int status)
        {
            this.ID = id;
            this.DateCheckOut = dateCheckOut;
            this.DateCheckIn = dateCheckIn;
            this.IDTable = idTable;
            this.Status = status;
        }

        public Bill(DataRow row)
        {
            this.ID = (int)row["id"];
            this.DateCheckIn = (DateTime?)row["DateCheckIn"];

            var dateCheckOutTemp = row["DateCheckOut"];
            if (dateCheckOutTemp.ToString() != "")
                this.DateCheckOut = (DateTime?)dateCheckOutTemp;
            this.IDTable = (int)row["idtable"];
            this.Status = (int)row["status"];
        }

        private int status;
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        private int iDTable;
        public int IDTable
        {
            get { return iDTable; }
            set { iDTable = value; }
        }


        private DateTime? dateCheckOut;
        public DateTime? DateCheckOut
        {
            get { return dateCheckOut; }
            set { dateCheckOut = value; }
        }

        private DateTime? dateCheckIn; // dấu chấm hỏi cho phép kiểu dữ liệu này có thể null
        public DateTime? DateCheckIn
        {
            get { return dateCheckIn; }
            set { dateCheckIn = value; }
        }

        private int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }


    }
}
