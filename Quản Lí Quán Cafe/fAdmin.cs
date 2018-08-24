using Quản_Lí_Quán_Cafe.DAO;
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

namespace Quản_Lí_Quán_Cafe
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();

            //LoadAccountList();

            //LoadFoodList();
        }

        //void LoadAccountList()
        //{
        //    string query = "exec dbo.usp_GetAccountByUserName @userName ";
            
        //    dtgvAccount.DataSource = DataProvider.Instance.ExecuteQuery(query,new object[] {"staff"});
        //}

        //void LoadFoodList()
        //{
        //    string query = "select * from Food";

        //    dtgvFood.DataSource = DataProvider.Instance.ExecuteQuery(query);
        //}
    }
}
