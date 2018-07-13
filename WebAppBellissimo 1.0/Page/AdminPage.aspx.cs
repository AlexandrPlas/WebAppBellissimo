using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbClassesBell;

namespace WebAppBellissimo_1._0.Page
{
    public partial class AdminPage : System.Web.UI.Page
    {
        SqlRepository Repository = new SqlRepository();

        protected IQueryable<Order> UserCheckOrders
        {
            get { return Repository.Orders.Where(p => (p.State == "Check")); }
        }

        private int pageSize = 10;



        protected int CurrentPage
        {
            get
            {
                int page;
                page = int.TryParse(Request.QueryString["page"], out page) ? page : 1;
                return page > MaxPage ? MaxPage : page;
            }
        }


        protected int MaxPage
        {
            get
            {
                return (int)Math.Ceiling((decimal)Repository.Orders.Count() / pageSize);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DataBind();

            Repeater1.DataSource = UserCheckOrders.Skip((CurrentPage - 1) * pageSize).Take(pageSize);
            Repeater1.DataBind();
        }
    }
}