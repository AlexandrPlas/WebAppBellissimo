using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbClassesBell;

namespace WebAppBellissimo_1._0.Page
{
    public partial class ReceptView : System.Web.UI.Page
    {
        SqlRepository Repository = new SqlRepository();

        protected String GetKind(int Id)
        {
            var asd = Repository.Kinds.Where(p => p.KindId == Id);
            String res = "";
            foreach (Kind aw in asd)
                res = aw.Name;
            return res;
        }

        protected List<String> GetMultiImageUrl
        {
        get{
            IQueryable<ImageForDish> re = Repository.ImageForDishs.Where(p => p.DishId == Convert.ToInt32(Request.QueryString["DishId"]));
            List<String> res = new List<string>();
            foreach(ImageForDish ass in re)
                res.Add(ass.Image);
            return res;}
        }
        
        protected String GetUser(int Id)
        {
            var asd = Repository.Users.Where(p => p.UserId == Id);
            String res = "";
            foreach (User aw in asd)
                res = aw.FirstName;
            return res;
        }
        protected Dish DishPage
        {
            get
            {
                return Repository.Dishs.Where(p => p.DishId == Convert.ToInt32(Request.QueryString["DishId"])).Single();
            }
        }

        protected String ReceptPage
        {
            get
            {
                return Repository.Recepts.Where(p => p.DishId == Convert.ToInt32(Request.QueryString["DishId"])).Single().Specific;
            }
        }

        protected IQueryable<Recall> RecallDish
        {
            get
            {
                return Repository.Recalls.Where(p => p.DishId == Convert.ToInt32(Request.QueryString["DishId"]));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DataBind();
            imageRepeat.DataSource = GetMultiImageUrl;
            imageRepeat.DataBind();
            RepeatRecall.DataSource= RecallDish;
            RepeatRecall.DataBind();

            if (((User)Session["ActiveUser"]).Status == "guest")
            {
                RecallButton.Visible=false;
                RecallTextbox.Visible=false;
                ButtonCheck.Visible = true;
                RecallLabel.Text="Вы должны войти в систему, чтобы оставить отзыв";
            }
            else
            {
                RecallButton.Visible = true;
                RecallTextbox.Visible = true;
                ButtonCheck.Visible = true;
                RecallLabel.Text = "Напишите отзыв";
            }
        }

        protected void RecallButton_Click(object sender, EventArgs e)
        {
            Recall newRecall = new Recall();
            newRecall.UserId = UserAct.UserId;
            newRecall.DishId = DishPage.DishId;
            newRecall.Text = RecallTextbox.Text;
            Repository.CreateRecall(newRecall);
            Response.Redirect(Request.RawUrl);
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
                OrderDish add = new OrderDish();
                if (Session["OrderUser"] == null)
                {
                    neworder.State = "Check";
                    neworder.Price = (decimal)Repository.Dishs.Where(p => p.DishId == Convert.ToInt32(Request.QueryString["DishId"])).FirstOrDefault().Price * _count;
                    Session["OrderUser"] = neworder;
                }
                else
                {
                    neworder =(Order)Session["OrderUser"];
                    neworder.Price += (decimal)Repository.Dishs.Where(p => p.DishId == Convert.ToInt32(Request.QueryString["DishId"])).FirstOrDefault().Price * _count;
                    Session["OrderUser"] = neworder;
                }
                List<OrderDish> reqdish = new List<OrderDish>();
                if (Session["OrderDishUser"]!=null) reqdish =(List<OrderDish>)Session["OrderDishUser"];
                if (reqdish.Where(p => p.DishId == Convert.ToInt32(Request.QueryString["DishId"])).Any())
                {
                    reqdish.Where(p => p.DishId == Convert.ToInt32(Request.QueryString["DishId"])).FirstOrDefault().Count += _count;
                }
                else
                {
                    add.DishId = Convert.ToInt32(Request.QueryString["DishId"]);
                    add.Count = _count;
                    reqdish.Add(add);
                }
                Session["OrderDishUser"] = reqdish;
            }
            else
            {
                OrderDish add = new OrderDish();
                if (!Repository.Orders.Where(p => (p.UserId == UserAct.UserId && p.State == "Check")).Any()) 
                {
                    Order neword = new Order();
                    neword.State = "Check";
                    neword.UserId = UserAct.UserId;
                    Repository.CreateOrder(neword);
                }
                Order saveord = Repository.Orders.Where(p => (p.UserId == UserAct.UserId && p.State == "Check")).FirstOrDefault();
                saveord.Price += (decimal)Repository.Dishs.Where(p => p.DishId == Convert.ToInt32(Request.QueryString["DishId"])).FirstOrDefault().Price * _count;
                Repository.UpdateOrder(saveord);
                if (Repository.OrderDishs.Where(p => p.DishId == Convert.ToInt32(Request.QueryString["DishId"]) && p.OrderId == saveord.OrderId).Any())
                {
                    add = Repository.OrderDishs.Where(p => p.DishId == Convert.ToInt32(Request.QueryString["DishId"]) && p.OrderId == saveord.OrderId).FirstOrDefault();
                    add.Count += _count;
                    Repository.UpdateOrderDish(add);
                }
                else
                {
                    add.OrderId = saveord.OrderId;
                    add.Count = _count;
                    add.DishId = Convert.ToInt32(Request.QueryString["DishId"]);
                    Repository.CreateOrderDish(add);
                }
            }
        }

    }
}