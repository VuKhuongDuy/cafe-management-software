using Quản_Lí_Quán_Cafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_Lí_Quán_Cafe.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }
        }

        private MenuDAO() { }

        public List<Menu> GetListMenuByTable(int id)
        {
            List<Menu> listMenu = new List<Menu>();

            string query = "select f.name, bi.count,f.price,f.price*bi.count as totalPrice from dbo.BillInfo as bi,dbo.bill as b,dbo.food as f where bi.idBill=b.id and bi.idfood=f.id and b.status=0 and b.idtable="+id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach(DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);

                listMenu.Add(menu);
            }

            return listMenu;
        }
    }
}
