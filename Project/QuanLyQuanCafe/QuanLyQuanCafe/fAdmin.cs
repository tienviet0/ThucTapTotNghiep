using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fAdmin : Form
    {
        BindingSource foodList = new BindingSource();
        BindingSource accountList = new BindingSource();
        BindingSource categoryList = new BindingSource();
        BindingSource tableList = new BindingSource();


        public Account loginAccount;

        public fAdmin()
        {
            InitializeComponent();

            Load();
        }

        #region methods

        List<Food> SearchFoodByName(string name)
        {
            List<Food> listFood = FoodDAO.Instance.SearchFoodByName(name);
            return listFood;
        }
        void Load()
        {
            dtgFood.DataSource = foodList;
            dgvAccount.DataSource = accountList;
            dgvCategory.DataSource = categoryList;
            dgvTable.DataSource = tableList;

            LoadDateTimePickerBill();
            LoadListBillByDate(dtpFormDate.Value, dtpTodate.Value);
            LoadListFood();
            LoadAccount();
            LoadCategoryIntoCombobox(cbFoodCategory);
            AddFoodBinding();
            AddAccountBinding();
            AddCategoryBinding();
            AddTableBinDing();
            LoadListCategory();
            LoadListTable();
            
        }

        void AddTableBinDing()
        {
            tbTableID.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "id", true, DataSourceUpdateMode.Never));
            tbTableName.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "Name", true, DataSourceUpdateMode.Never));
            tbTableStatus.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "status", true, DataSourceUpdateMode.Never));
            
        }

        
        void AddAccountBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            numericUpDown1.DataBindings.Add(new Binding("Value", dgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }

        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }

       
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpFormDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpTodate.Value = dtpFormDate.Value.AddMonths(1).AddDays(-1);
        }
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dgvBill.DataSource = BillDAO.Instance.GetBillListlByDate(checkIn, checkOut);
        }

        void AddFoodBinding()
        {
            txbFoodName.DataBindings.Add(new Binding("Text", dtgFood.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txbFoodID.DataBindings.Add(new Binding("Text", dtgFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nmFoodPrice.DataBindings.Add(new Binding("Value", dtgFood.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }

        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();

            cb.DisplayMember = "Name";
        }

        void LoadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }


        void AddAccount(string userName, string displayName, int type)
        {
            if(AccountDAO.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }

            LoadAccount();
        }

        void EditAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại");
            }

            LoadAccount();
        }

        void DeleteAccount(string userName)
        {
            if (loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Không thể xóa tài khoản hiện tại!");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }

            LoadAccount();
        }


        void ResetPass(string userName)
        {
            if (AccountDAO.Instance.ResetPassword(userName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu thất bại");
            }

        }

        void LoadListCategory()
        {
            categoryList.DataSource = CategoryDAO.Instance.GetListCategory();
        }

        void AddCategoryBinding()
        {
            txbCategoryID.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "ID", true, DataSourceUpdateMode.Never));
            tbCategoryName.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "Name", true, DataSourceUpdateMode.Never));
        }

        void AddCategory(string name)
        {
            if(CategoryDAO.Instance.InsertCategory(name))
            {
                MessageBox.Show("Thêm loại món ăn thành công!");
            }
            else
            {
                MessageBox.Show("Thêm loại món ăn thất bại");
            }
            LoadListCategory();
        }

        void EditCategory(int id, string name)
        {
            if (CategoryDAO.Instance.UpdateCategory(id, name))
            {
                MessageBox.Show("Cập nhật loại món ăn thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật loại món ăn thất bại");
            }
            LoadListCategory();
        }

        void DeleteCategory(int id)
        {
            if (CategoryDAO.Instance.DeleteCategory(id))
            {
                MessageBox.Show("Xóa loại món ăn thành công!");
            }
            else
            {
                MessageBox.Show("Xóa loại món ăn thất bại");
            }
            LoadListCategory();
        }

        
        void LoadListTable()
        {
           tableList.DataSource = TableDAO.Instance.GetListTable();
        }

        void AddTable( string name, string status)
        {
            if (TableDAO.Instance.InsertTable(name, status))
            {
                MessageBox.Show("Thêm bàn thành công!");
            }
            else
            {
                MessageBox.Show("Thêm bàn thất bại!");
            }

            LoadListTable();
        }

        void EditTable(int id, string name, string status)
        {
            if (TableDAO.Instance.UpdateTable(id, name, status))
            {
                MessageBox.Show("Cập nhật bàn thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật bàn thất bại!");
            }

            LoadListTable();
        }

        void DeleteTable(int id)
        {
            if (TableDAO.Instance.DeleteTable(id))
            {
                MessageBox.Show("Xóa bàn thành công!");
            }
            else
            {
                MessageBox.Show("Xóa nhật bàn thất bại!");
            }

            LoadListTable();
        }
        #endregion





        #region events


        private void btnShowTable_Click(object sender, EventArgs e)
        {
            LoadListTable();
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbTableID.Text);

            DeleteTable(id);
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbTableID.Text);
            string name = tbTableName.Text;
            string status = tbTableStatus.Text;

            EditTable(id, name, status);
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            //int id = Convert.ToInt32(tbTableID.Text);
            string name = tbTableName.Text;
            string status = tbTableStatus.Text;

            AddTable(name, status);
        }

        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            LoadListCategory();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string name = tbCategoryName.Text;

            AddCategory(name);
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbCategoryID.Text);

            DeleteCategory(id);
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            string name = tbCategoryName.Text;
            int id = Convert.ToInt32(txbCategoryID.Text);

            EditCategory(id, name);
        }




        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)numericUpDown1.Value;

            AddAccount(userName, displayName, type);
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            DeleteAccount(userName);
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)numericUpDown1.Value;

            EditAccount(userName, displayName, type);
        }

        private void btnResetAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            ResetPass(userName);
        }

        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            foodList.DataSource = SearchFoodByName(txbSearchFoodName.Text);
        }

        private void btnShowFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpFormDate.Value, dtpTodate.Value);
        }


        private void txbFoodID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgFood.SelectedCells.Count > 0)
                {
                    int id = (int)dtgFood.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;

                    Category category = CategoryDAO.Instance.GetCategoryByID(id);

                    cbFoodCategory.SelectedItem = category;

                    int index = -1;
                    int i = 0;
                    foreach (Category item in cbFoodCategory.Items)
                    {
                        if (item.ID == category.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    cbFoodCategory.SelectedIndex = index;
                }
            }
            catch { }

        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;

            if (FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm món thành công");
                LoadListFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm thức ăn");
            }
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;
            int id = Convert.ToInt32(txbFoodID.Text);

            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành công");
                LoadListFood();
                if (updateFood != null)
                    updateFood(this,new EventArgs());  
                        
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa thức ăn");
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbFoodID.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món thành công");
                LoadListFood();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa thức ăn");
            }
        }

        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }

        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }

        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }

        }

        




        #endregion


    }
}
