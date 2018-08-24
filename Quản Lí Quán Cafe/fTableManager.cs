using Quản_Lí_Quán_Cafe.DAO;
using Quản_Lí_Quán_Cafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_Lí_Quán_Cafe
{
    public partial class fTableManager : Form
    {
        public fTableManager()
        {
            InitializeComponent();

            LoadTable();

            LoadCategory();
        }

        #region Method

        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "Name";  //hiển thị ở combo box name của category
        }

        void LoadFoodListByCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);

            cbFood.DataSource = listFood;

            cbFood.DisplayMember = "Name";
        }

        void LoadTable()
        {
            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach(Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine ;
                btn.Click += btn_Click;
                btn.Tag = item;
                switch(item.Status)
                {
                    case "trống":
                        btn.BackColor = Color.LightBlue;
                        break;
                    default:
                        btn.BackColor = Color.Red;
                        break;
                }

                flpTable.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {
            lsvBill.Items.Clear();

            List<Quản_Lí_Quán_Cafe.DTO.Menu> listMenu = MenuDAO.Instance.GetListMenuByTable(id); // tại đặt tên trùng
            float totalPrice = 0;
            foreach(Quản_Lí_Quán_Cafe.DTO.Menu item in listMenu)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(lsvItem);
            }

            // chuyển từ tiền đô sang tiền việt. thực tế là chuyển culture anh --> việt
            CultureInfo culture = new CultureInfo("vi-VN");

            // Bài hiển thị tổng tiền ở howKteam. quản lí quán cà phê    
            // làm thay đổi culture của cái thread main này
            Thread.CurrentThread.CurrentCulture = culture;

            txbTotalPrice.Text = totalPrice.ToString("c");            
        }

        #endregion

        #region Events

        void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void thôngTinCáNhanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile();
            f.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.ShowDialog();
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            Category selected = cb.SelectedItem as Category;

            id = selected.ID;
             
            LoadFoodListByCategoryID(id);
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;

            int idBill = BillDAO.Instance.GetUncheckBillIdByTableID(table.ID);
            int foodID = (cbFood.SelectedItem as Food).ID;
            int count = (int)nmFoodCount.Value;

            if(idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
                 
            }
            ShowBill(table.ID);
        }
        #endregion

    }
}
