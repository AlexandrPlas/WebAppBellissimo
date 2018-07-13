using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbClassesBell;

namespace WebAppBellissimo_1._0.Page.LKView
{
    public partial class BasketPage : System.Web.UI.Page
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
            get {
                Order res = new Order();
                if (UserAct.Status == "guest" || UserAct != null) if (Session["OrderUser"]!=null) res = (Order)Session["OrderUser"];
                    else if (UserAct.UserId != 0 && Repository.Orders.Where(p => p.UserId == UserAct.UserId && p.State == "Check").Any()) 
                    res = Repository.Orders.Where(p => p.UserId == UserAct.UserId && p.State == "Check").Single();
                return res;
            }
        }

        protected List<Dish> DishInOrders
        {
            get
            {   
                List<Dish> res = new List<Dish>();
                    if (UserAct.Status == "guest")
                    {
                        if (Session["OrderDishUser"] != null) { 
                    List<OrderDish> temp = (List<OrderDish>)Session["OrderDishUser"];
                    foreach (OrderDish i in temp)
                    {
                        res.Add(Repository.Dishs.Where(p => p.DishId == i.DishId).Single());
                    }}
                    }
                else {
                var md = Repository.OrderDishs.Where(p => p.OrderId == CheckOrders.OrderId);
                
                foreach (OrderDish i in md)
                {
                    res.Add(Repository.Dishs.Where(p => p.DishId == i.DishId).Single());
                }}
                return res;
            }
        }

        protected List<DbClassesBell.Menu> MenuInOrders
        {
            get
            {
                List<DbClassesBell.Menu> res = new List<DbClassesBell.Menu>();
                if (UserAct.Status == "guest")
                {
                    if (Session["OrderMenuUser"] != null)
                    {
                        List<OrderMenu> temp = (List<OrderMenu>)Session["OrderMenuUser"];
                        foreach (OrderMenu i in temp)
                        {
                            res.Add(Repository.Menus.Where(p => p.MenuId == i.MenuId).Single());
                        }
                    }
                }
                else
                {
                    var md = Repository.OrderMenus.Where(p => p.OrderId == CheckOrders.OrderId);

                    foreach (OrderMenu i in md)
                    {
                        res.Add(Repository.Menus.Where(p => p.MenuId == i.MenuId).Single());
                    }
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

        protected String GetMenuDish(int Id)
        {
            var asd = Repository.MenuDishs.Where(p => p.MenuId == Id);
            List<MenuDish> res = new List<MenuDish>();
            foreach (MenuDish aw in asd)
                res.Add(aw);
            String Dishss = ""; int i = 0;
            foreach (var qw in res)
            {
                if (i < 4)
                {
                    Dishss += Repository.Dishs.Where(p => p.DishId == qw.DishId).Single().Name;
                    Dishss += "<br/>";
                    i++;
                }
            }

            return Dishss;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ActiveUser"] == null)
            {
                User guest = new User();
                guest.FirstName = "guest";
                guest.LastName = "guest";
                guest.email = "guest";
                guest.password = "guest";
                guest.Status = "guest";

                Session["ActiveUser"] = guest;
            }

            if (CheckOrders.Price == 0)
            {
                HeadBasket.Text = "Ваша корзина пуста";
                ButtonCheck.Visible = false;
                basket.Visible = false;

            }
            else
            {
                HeadBasket.Text = "";
                ButtonCheck.Visible = true;
                basket.Visible = true;
            }
            this.DataBind();

            
            Repeater1.DataSource = DishInOrders;
            Repeater1.DataBind();

            Repeater2.DataSource = MenuInOrders;
            Repeater2.DataBind();
        }

        protected void ButtonRemOrder_Click(object sender, EventArgs e)
        {
            if (UserAct.Status == "guest")
            {
                Session.Remove("OrderDishUser");
                Session.Remove("OrderUser");
                Session.Remove("OrderMenuUser");
            }else  Repository.RemoveOrder(CheckOrders.OrderId);
            Response.Redirect("~/Page/BasketPage.aspx");
        }

        protected void dell_OrderDish(int Id)//удаление рецепта из заказа
        {

            if (UserAct.Status == "guest")
            {
                List<OrderDish> asd = (List<OrderDish>)Session["OrderDishUser"];
                OrderDish od = asd.Where(p=>p.DishId == Id).FirstOrDefault();
                Order curord = (Order)Session["OrderUser"];
                curord.Price -= (decimal)Repository.Dishs.Where(p => (p.DishId == Id)).FirstOrDefault().Price * od.Count;
                asd.Remove(od);
                Session["OrderUser"] = curord;
                Session["OrderDishUser"] =asd;
            }
            else {
                OrderDish delord = Repository.OrderDishs.Where(p => (p.OrderId == CheckOrders.OrderId && p.DishId == Id)).FirstOrDefault();
                Order curord = Repository.Orders.Where(p => p.OrderId == CheckOrders.OrderId).FirstOrDefault();
                curord.Price -= (decimal)Repository.Dishs.Where(p => (p.DishId == Id)).FirstOrDefault().Price * delord.Count;
                Repository.UpdateOrder(curord);
                Repository.RemoveOrderDish(delord.OrderDishId);
            }
            Response.Redirect("~/Page/BasketPage.aspx");
        }

        protected void dell_OrderMenu(int Id)//удаление menu из заказа
        {
            if (UserAct.Status == "guest")
            {
                List<OrderMenu> asd = (List<OrderMenu>)Session["OrderMenuUser"];
                OrderMenu od = asd.Where(p => p.MenuId == Id).FirstOrDefault();
                Order curord = (Order)Session["OrderUser"];
                curord.Price -= (decimal)Repository.Menus.Where(p => (p.MenuId == Id)).FirstOrDefault().Price * od.Count;
                asd.Remove(od);
                Session["OrderUser"] = curord;
                Session["OrderMenuUser"] = asd;
            }
            else {
                OrderMenu delord = Repository.OrderMenus.Where(p => (p.OrderId == CheckOrders.OrderId && p.MenuId == Id)).FirstOrDefault();
                Order curord = Repository.Orders.Where(p => p.OrderId == CheckOrders.OrderId).FirstOrDefault();
                curord.Price -= (decimal)Repository.Menus.Where(p => (p.MenuId == Id)).FirstOrDefault().Price * delord.Count;
                Repository.UpdateOrder(curord);
                Repository.RemoveOrderMenu(delord.OrderMenuId);
            }
            Response.Redirect("~/Page/BasketPage.aspx");
        }

        protected void DeleteDish_Click(object sender, EventArgs e)
        {
            Button sd = (Button)sender;
            int Id = Convert.ToInt32(sd.CommandArgument);
            dell_OrderDish(Id);
        }

        protected void DeleteMenu_Click(object sender, EventArgs e)
        {
            Button sd = (Button)sender;
            int Id = Convert.ToInt32(sd.CommandArgument);
            dell_OrderMenu(Id);
        }

        protected int CountDish(int Id)
        {
            int res;
            if (UserAct.Status == "guest")
            {
                List<OrderDish> asd = (List<OrderDish>)Session["OrderDishUser"];
                res = asd.Where(p => p.DishId == Id).FirstOrDefault().Count;
            }
            else
            {
                res = Repository.OrderDishs.Where(p => p.DishId == Id && p.OrderId == CheckOrders.OrderId).FirstOrDefault().Count;
            }

            return res;
        }

        protected int CountMenu(int Id)
        {
            int res;
            if (UserAct.Status == "guest")
            {
                List<OrderMenu> asd = (List<OrderMenu>)Session["OrderMenuUser"];
                res = asd.Where(p => p.MenuId == Id).FirstOrDefault().Count;
            }
            else
            {
                res = Repository.OrderMenus.Where(p => p.MenuId == Id && p.OrderId == CheckOrders.OrderId).FirstOrDefault().Count;
            }

            return res;
        }
    }
}