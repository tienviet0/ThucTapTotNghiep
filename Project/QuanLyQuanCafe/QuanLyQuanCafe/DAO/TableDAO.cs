using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        public static int TableWidth = 100;
        public static int TableHeight = 100;
        private TableDAO() { }

        public List<Table> LoadTableList()
        {
            List<Table> tablelist = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tablelist.Add(table);
            }

            return tablelist;
        }

        public List<Table> GetListTable()
        {
            List<Table> tablelist = new List<Table>();

            string query = "select * from TableFood";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tablelist.Add(table);
            }

            return tablelist;
        }

        public bool InsertTable(string name, string status)
        {
            string query = string.Format("INSERT dbo.TableFood (name, status)VALUES (  N'{0}', N'{1}')", name, status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateTable(int id, string name, string status)
        {
            string query = string.Format("UPDATE dbo.TableFood SET name = N'{1}', status = N'{2}' WHERE id = {0}", id, name, status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteTable(int id)
        {
            string query = string.Format("Delete TableFood where id = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
