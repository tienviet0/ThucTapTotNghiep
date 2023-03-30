using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Bill
    {
        public Bill(int id, DateTime? dateCheckin, DateTime? dateCheckOut, int status, int discount = 0)
        {
            this.ID = id;
            this.dateCheckIn = dateCheckin;
            this.dateCheckOut = dateCheckOut;
            this.Status = status;
            this.Discount = discount; 
        }

        public Bill(DataRow row)
        {
            this.ID = (int)row["id"];
            this.dateCheckIn = (DateTime?)row["dateCheckin"];
            var dateCheckOutTemp = row["dateCheckOut"];
            if(dateCheckOutTemp.ToString() != "")
                this.dateCheckOut = (DateTime?)dateCheckOutTemp;
            this.Status = (int)row["status"];
            if (row["discount"].ToString() != "") 
                this.Discount = (int)row["discount"];
        }

        private int discount;
        private int status;
        private DateTime? dateCheckOut;
        private DateTime? dateCheckIn;
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        public DateTime? DateCheckIn 
        { 
            get { return dateCheckIn; }
            set { dateCheckIn = value; }
        }

        public int Status 
        { 
            get { return status; }
            set { status = value; }
        }

        public DateTime? DateCheckOut 
        { 
            get { return dateCheckOut; }
            set { dateCheckOut = value; }
        }

        public int Discount 
        {
            get { return discount; }
            set { discount = value; }
        }
    }
}
