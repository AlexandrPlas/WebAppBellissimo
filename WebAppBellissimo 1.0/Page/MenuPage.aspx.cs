using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbClassesBell;

namespace WebAppBellissimo_1._0.Page
{
    public partial class MenuPage : System.Web.UI.Page
    {

        SqlRepository Repository = new SqlRepository();

        protected DbClassesBell.Menu MenuPage1
        {
            get
            {
                return Repository.Menus.Where(p => p.MenuId == Convert.ToInt32(Request.QueryString["MenuId"])).Single();
            }
        }

        protected List<Dish> DishInMenu
        {
            get
            {   
                var md = Repository.MenuDishs.Where(p => p.MenuId == Convert.ToInt32(Request.QueryString["MenuId"]));
                List<Dish> res = new List<Dish>();
                foreach(MenuDish i in md)
                {
                    res.Add(Repository.Dishs.Where(p => p.DishId == i.DishId).Single());
                }
                return res;
            }
        }

        protected String GetKind(int Id)
        {
            var asd = Repository.Kinds.Where(p => p.KindId == Id);
            String res = "";
            foreach (Kind aw in asd)
                res = aw.Name;
            return res;
        }

        protected decimal GetPrice(List<Dish> dd)
        {
            decimal res =0;
            foreach (Dish  i in dd)
            {
                res+=(decimal)i.Price;
            }
            return res;
        }

        protected String GetImageUrl(int DishId)
        {
            ImageForDish re = Repository.ImageForDishs.Where(p => p.DishId == DishId).FirstOrDefault();
            if (re != null)
                return Repository.ImageForDishs.Where(p => p.DishId == DishId).FirstOrDefault().Image;
            else
                return "~/PictureDish/null_image.png";
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            this.DataBind();

            Repeater1.DataSource = DishInMenu;
            Repeater1.DataBind();

        }

        protected User UserAct
        {
            get
            {
                return (User)Session["ActiveUser"];
            }
        }

        protected void ButtonCheck_Click(object sender, EventArgs e)
        {
            int _count = Convert.ToInt32(CountDish.Text);
            if (UserAct.Status == "guest")
            {
                Order neworder = new Order();
                OrderMenu add = new OrderMenu();
                if (Session["OrderUser"] == null)
                {
                    neworder.State = "Check";
                    neworder.Price = (decimal)Repository.Menus.Where(p => p.MenuId == Convert.ToInt32(Request.QueryString["MenuId"])).FirstOrDefault().Price * _count;
                    Session["OrderUser"] = neworder;
                }
                else
                {
                    neworder = (Order)Session["OrderUser"];
                    neworder.Price += (decimal)Repository.Menus.Where(p => p.MenuId == Convert.ToInt32(Request.QueryString["MenuId"])).FirstOrDefault().Price * _count;
                    Session["OrderUser"] = neworder;
                }
                
                List<OrderMenu> reqdish = new List<OrderMenu>();
                if (Session["OrderMenuUser"] != null) reqdish = (List<OrderMenu>)Session["OrderMenuUser"];
                if (reqdish.Where(p => p.MenuId == Convert.ToInt32(Request.QueryString["MenuId"])).Any())
                {
                    reqdish.Where(p => p.MenuId == Convert.ToInt32(Request.QueryString["MenuId"])).FirstOrDefault().Count += _count;
                }
                else
                {
                    add.MenuId = Convert.ToInt32(Request.QueryString["MenuId"]);
                    add.Count = _count;
                    reqdish.Add(add);
                }
                
                Session["OrderMenuUser"] = reqdish;
            }
            else
            {
                OrderMenu add = new OrderMenu();
                if (!Repository.Orders.Where(p => (p.UserId == UserAct.UserId && p.State == "Check")).Any())
                {
                    Order neword = new Order();
                    neword.State = "Check";
                    neword.UserId = UserAct.UserId;
                    Repository.CreateOrder(neword);
                }
                Order saveord = Repository.Orders.Where(p => (p.UserId == UserAct.UserId && p.State == "Check")).FirstOrDefault();
                saveord.Price += (decimal)Repository.Menus.Where(p => p.MenuId == Convert.ToInt32(Request.QueryString["MenuId"])).FirstOrDefault().Price * _count;                
                Repository.UpdateOrder(saveord);
                if (Repository.OrderMenus.Where(p => p.MenuId == Convert.ToInt32(Request.QueryString["MenuId"]) && p.OrderId == saveord.OrderId).Any())
                {
                    add = Repository.OrderMenus.Where(p => p.MenuId == Convert.ToInt32(Request.QueryString["MenuId"]) && p.OrderId == saveord.OrderId).FirstOrDefault();
                    add.Count += _count;
                    Repository.UpdateOrderMenu(add);
                }
                else
                {
                    add.OrderId = saveord.OrderId;
                    add.MenuId = Convert.ToInt32(Request.QueryString["MenuId"]);
                    add.Count = _count;
                    Repository.CreateOrderMenu(add);
                }
            }
        }
    }
}