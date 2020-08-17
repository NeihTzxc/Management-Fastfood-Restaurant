using QLCHTAN_v2.DAO;
using QLCHTAN_v2.DTO;
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

namespace QLCHTAN_v2
{
    public partial class fAdmin : Form
    {
        BindingSource foodList = new BindingSource();

       
        public fAdmin()
        {
            InitializeComponent();
            
            LoadData();
            
        }
        void LoadData()
        {
            dtgvFood.DataSource=foodList;
            LoadDateTimePickerBill();
            LoadListBillByDate(dtpkFromDay.Value, dtpkToDate.Value);
            LoadListFood();
            LoadCategoryFood();
            LoadListTable();
            LoadCategoryIntoCombobox(cbFoodCategory);
            addComboboxTable();//thêm giá trị cho tình trạng của bàn
            AddFoodBinding();
            AddCategoryBinding();
            AddTableBinding();
            LoadAccountList();
        }
        private void tbTable_Click(object sender, EventArgs e)
        {

        }
       private void LoadAccountList()
        {
            

            string query = "EXEC dbo.USP_GetAccountUserName @userName=N'admin'"  ;
            //DataProvider provider = new DataProvider();loadlistbillbydate
            dtgvAccount.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        List<Food> SearchFoodByName(string name)
        {
            List<Food> listFood = FoodDAO.Instance.SearchFoodByName(name);

            return listFood;
        }
        void LoadFoodList()
        {
            string query = "SELECT * FROM dbo.Food";
            dtgvFood.DataSource= DataProvider.Instance.ExecuteQuery(query);
        }
        private void fAdmin_Load(object sender, EventArgs e)
        {
           this.USP_GetTableListTableAdapter.Fill(this.DataSet1.USP_GetTableList);
           
            this.reportViewer2.RefreshReport();
        }
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvBill.DataSource=BillDAO.Instance.GetBillListByDate(checkIn,checkOut);

        }
         private void ShowSumTotalPrice(DateTime checkIn, DateTime checkOut)
        {
            //checkIn = dtpkFromDay.Value;
            //checkOut = dtpkToDate.Value;
            string query = "SELECT SUM(totalPrice) as N'Tổng doanh thu' FROM dbo.Bill WHERE DateCheckIn BETWEEN '"+checkIn+"' and '"+checkOut+"'";
           dtgvSumTotalPrice.DataSource =DataProvider.Instance.ExecuteQuery(query);

        }
        void LoadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }
        void LoadCategoryFood()
        {
            dtgvFoodCategory.DataSource = CategoryDAO.Instance.GetListCategory();
        }
        void LoadListTable()
        {
            dtgvTable.DataSource = TableDAO.Instance.LoadTableList();
        }
        void AddFoodBinding()
        {
            txbFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txbFoodID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nmFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }
        void AddCategoryBinding()
        {
            txbCategory.DataBindings.Add(new Binding("Text",dtgvFoodCategory.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txbCategoryID.DataBindings.Add(new Binding("Text", dtgvFoodCategory.DataSource, "id", true, DataSourceUpdateMode.Never));
        }
        void AddTableBinding()
        {
            txbTableID.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "id", true, DataSourceUpdateMode.Never));
            txbTableName.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "name", true, DataSourceUpdateMode.Never));
            cbStatus.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "status", true, DataSourceUpdateMode.Never));
        }
        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }
        

        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDay.Value = new DateTime(today.Year, today.Month, 1);
            //dtpkFromDay.Value = new DateTime(1998,1,1);
            dtpkToDate.Value = dtpkFromDay.Value.AddMonths(1).AddDays(-1);
        }
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            //string checkIn = dtpkFromDay.Value.ToString("yyyy-MM-dd");
            //string checkOut = dtpkToDate.Value.ToString("yyyy-MM-dd");
            
            LoadListBillByDate(dtpkFromDay.Value.Date,dtpkToDate.Value.Date);
            
        }

        private void txbFoodID_TextChanged(object sender, EventArgs e)
        {
            
            
               try
            {
                if (dtgvFood.SelectedCells.Count > 0)
                {
                    int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            float price =(float) nmFoodPrice.Value;
            if(FoodDAO.Instance.InsertFood(name,categoryID,price))
            {
                MessageBox.Show("Thêm món thành công!");
                LoadListFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Thêm món không thành công!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;
            int id =Convert.ToInt32( txbFoodID.Text);
            if (FoodDAO.Instance.UpdateFood(id,name, categoryID, price))
            {
                MessageBox.Show("Chỉnh sửa thành công!");
                LoadListFood();
                
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Chỉnh sửa không thành công!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbFoodID.Text);
            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món thành công!");
                LoadListFood();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Xóa món không thành công!");
            }

        }
        #region 
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

        private void btnSeach_Click(object sender, EventArgs e)
        {
            foodList.DataSource = SearchFoodByName(txbSeach.Text);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }
        void addComboboxTable()
        {
            cbStatus.Items.Add("Trống");
            cbStatus.Items.Add("Có người");
        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string name = txbCategory.Text;
            if (CategoryDAO.Instance.InsertCategory(name))
            {
                MessageBox.Show("Thêm danh mục thành công!");
                LoadCategoryFood();
               
            }
            else
            {
                MessageBox.Show("Thêm danh mục không thành công!");
            }
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            string name = txbTableName.Text;
            string status = cbStatus.Text;
            if (TableDAO.Instance.InsertTable(name, status))
            {
                MessageBox.Show("Thêm bàn thành công!");
                LoadListTable();
            }
            else
            {
                MessageBox.Show("Thêm bàn không thành công!");
            }
        }

        private void txbCategory_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            string name = txbCategory.Text;
            int categoryID = (int)Convert.ToInt32(txbCategoryID.Text);
            if (CategoryDAO.Instance.UpdateCategory(categoryID,name))
            {
                MessageBox.Show("Chỉnh sửa thành công!");
                LoadCategoryFood();
            }
            else
            {
                MessageBox.Show("Chỉnh sửa không thành công!");
            }

        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            string name =txbTableName.Text;
            int tableID = (int)Convert.ToInt32(txbTableID.Text);
            string status = cbStatus.Text;
            if (TableDAO.Instance.UpdateTable(tableID,name,status))
            {
                MessageBox.Show("Chỉnh sửa thành công!");
                LoadListTable();
            }
            else
            {
                MessageBox.Show("Chỉnh sửa không thành công!");
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbCategoryID.Text);
            if (CategoryDAO.Instance.DeleteCategory(id))
            {
                MessageBox.Show("Xóa danh mục thành công!");
                LoadCategoryFood();
               
            }
            else
            {
                MessageBox.Show("Xóa danh mục không thành công!");
            }

        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(txbCategoryID.Text);
            if (TableDAO.Instance.DeleteTable(id))
            {
                MessageBox.Show("Xóa bàn thành công!");
                LoadListTable();

            }
            else
            {
                MessageBox.Show("Xóa bàn không thành công!");
            }
        }

        private void btnSumTotalPrice_Click(object sender, EventArgs e)
        {
            ShowSumTotalPrice(dtpkFromDay.Value,dtpkToDate.Value);
            //ShowSumTotalPrice();
        }

        private void dtpkToDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txbSeach_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();

        }
    }
}
