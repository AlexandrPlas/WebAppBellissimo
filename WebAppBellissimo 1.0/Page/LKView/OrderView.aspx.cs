using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbClassesBell;

namespace WebAppBellissimo_1._0.Page.LKView
{
    public partial class OrderView : System.Web.UI.Page
    {
        SqlRepository Repository = new SqlRepository();

        protected User UserAct
        {
            get
            {
                return (User)Session["ActiveUser"];
            }
        }

        protected Order CheckOrders
        {
            get { return Repository.Orders.Where(p => p.OrderId == Convert.ToInt32(Request.QueryString["OrderId"])).Single(); }
        }

        protected List<Dish> DishInOrders
        {
            get
            {
                var md = Repository.OrderDishs.Where(p => p.OrderId == Convert.ToInt32(Request.QueryString["OrderId"]));
                List<Dish> res = new List<Dish>();
                foreach (OrderDish i in md)
                {
                    res.Add(Repository.Dishs.Where(p => p.DishId == i.DishId).Single());
                }
                return res;
            }
        }

        protected int CountDish(int Id)
        {
                return Repository.OrderDishs.Where(p=>p.DishId == Id && p.OrderId == CheckOrders.OrderId).FirstOrDefault().Count;
        }

        protected String GetKind(int Id)
        {
            var asd = Repository.Kinds.Where(p => p.KindId == Id);
            String res = "";
            foreach (Kind aw in asd)
                res = aw.Name;
            return res;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DataBind();

            Repeater1.DataSource = DishInOrders;
            Repeater1.DataBind();
        }

        protected void ButtonRemOrder_Click(object sender, EventArgs e)
        {
            Repository.RemoveOrder(CheckOrders.OrderId);
            Response.Redirect("~/Page/LKView/OrderUser.aspx");
        }

        protected void dell_OrderDish(OrderDish od)//удаление рецепта из заказа
        {
            Repository.RemoveOrderDish(od.OrderDishId);
            Response.Redirect(Request.RawUrl);
        }


    }
}