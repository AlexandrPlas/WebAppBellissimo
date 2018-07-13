using DbClassesBell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppBellissimo_1._0
{
    public partial class Main : System.Web.UI.MasterPage
    {
        SqlRepository Repository = new SqlRepository(); 

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
            if ( ((User)Session["ActiveUser"]).Status == "guest")
            {
                logout.Visible = false;
                Adminka.Visible = false;
                logi.Text = "Войти"; logi.NavigateUrl = "~/Page/Autorization.aspx"; logi.Visible = true;
                regi.Text = "Регистрация"; regi.NavigateUrl="~/Page/Regestrate.aspx";
            }
            else
            {
                logout.Visible = true; logout.Text = "Выход";
                Adminka.Visible = false;
                if (((User)Session["ActiveUser"]).Status == "admin") Adminka.Visible = true;
                logi.Text = "Выход"; logi.NavigateUrl = "~/Default.aspx"; logi.Visible = false;
                regi.Text = "Личный кабинет"; regi.NavigateUrl = "~/Page/LK.aspx";
            }
            Order actord = CheckOrders;
            this.DataBind();
        }

        protected User UserAct
        {
            get
            {
                return (User)Session["ActiveUser"];
            }
        }

        protected Order CheckOrders
        {
            get
            {
                Order res = new Order();
                if (UserAct.Status == "guest" || UserAct != null) if (Session["OrderUser"] != null) res = (Order)Session["OrderUser"];
                    else if (UserAct.UserId != 0 && Repository.Orders.Where(p => p.UserId == UserAct.UserId && p.State == "Check").Any())
                        res = Repository.Orders.Where(p => p.UserId == UserAct.UserId && p.State == "Check").Single();
                return res;
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            if (Session != null) { 
            Session.Abandon();
            
            }
        }
    }
}