using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbClassesBell;

namespace WebAppBellissimo_1._0.Page.LKView
{
    public partial class OrderUser : System.Web.UI.Page
    {
        SqlRepository Repository = new SqlRepository();

        protected User UserAct
        {
            get
            {
                return (User)Session["ActiveUser"];
            }
        }

        protected IQueryable<Order> UserCheckOrders
        {
            get { return Repository.Orders.Where(p => (p.UserId == UserAct.UserId && (p.State == "Check" || p.State == "Ready"))); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DataBind();

            Repeater1.DataSource = UserCheckOrders;
            Repeater1.DataBind();
        }
    }
}