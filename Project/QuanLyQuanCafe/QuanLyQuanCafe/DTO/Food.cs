using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Food
    {
        public Food(int id, string name, int categoryID, float price) 
        { 
            ID = id;
            Name = name;
            CategoryID = categoryID;
            Price = price;
        }

        public Food(DataRow row)
        {
            ID = (int)row["id"];
            Name = row["name"].ToString();
            CategoryID = (int)row["idcategory"];
            Price = (float)Convert.ToDouble(row["price"].ToString());
        }

        private int iD;
        private string name;
        private int categoryID;
        private float price;

        public float Price 
        { 
            get {return price;}
            set {price = value;}
        }
        public int ID 
        {
            get { return iD; } 
            set {iD = value;}
        }
        public string Name 
        { 
            get { return name;}           
            set {name = value;}
        }
        public int CategoryID 
        {
            get { return categoryID; } 
            set {categoryID = value;}
        }
    }
}
